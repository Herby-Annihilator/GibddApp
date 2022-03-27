using GibddApp.API.Data;
using GibddApp.API.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace GibddApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperProtocolController : ControllerBase
    {
        protected IRepository<Protocol> _protocolRepository;
        protected IRepository<Citizen> _citizenRepository;
        protected IRepository<Vehicle> _vehicleRepository;
        protected IRepository<ProtocolAppendix> _protocolAppendixRepository;
        protected IRepository<Address> _addressRepository;
        protected IRepository<RoleInRoadAccident> _roleRepository;
        protected IRepository<Employee> _employeeRepository;
        protected IRepository<Participant> _participantRepository;
        protected IRepository<Passport> _passportRepository;
        protected IRepository<DriverLicense> _driverLicenseRepository;
        protected IRepository<Color> _colorRepository;
        protected IRepository<Model> _modelRepository;
        protected IRepository<Mark> _markRepository;
        protected IRepository<Category> _categoryRepository;

        public SuperProtocolController(IRepository<Protocol> protocolRepository, IRepository<Citizen> citizenRepository,
            IRepository<Vehicle> vehicleRepository, IRepository<ProtocolAppendix> protocolAppendixRepository,
            IRepository<Address> addressRepository, IRepository<RoleInRoadAccident> roleRepository,
            IRepository<Employee> employeeRepository, IRepository<Participant> participantRepository,
            IRepository<Passport> passportRepository, IRepository<DriverLicense> driverLicenseRepository, 
            IRepository<Color> colorRepository, IRepository<Model> modelRepository, IRepository<Mark> markRepository,
            IRepository<Category> categoryRepository)
        {
            _protocolRepository = protocolRepository;
            _citizenRepository = citizenRepository;
            _vehicleRepository = vehicleRepository;
            _protocolAppendixRepository = protocolAppendixRepository;
            _addressRepository = addressRepository;
            _roleRepository = roleRepository;
            _employeeRepository = employeeRepository;
            _participantRepository = participantRepository;
            _passportRepository = passportRepository;
            _driverLicenseRepository = driverLicenseRepository;
            _colorRepository = colorRepository;
            _modelRepository = modelRepository;
            _markRepository = markRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SuperProtocol>> GetSuperProtocol(int id)
        {
            try
            {
                SuperProtocol protocol = await GetSuperProtocolById(id);
                return Ok(protocol);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        protected async Task<SuperProtocol> GetSuperProtocolById(int id)
        {
            Protocol protocol = await _protocolRepository.GetById(id);
            if (protocol == null)
                throw new Exception($"Protocol was not found. Invalid id = {id}");
            SuperProtocol superProtocol = SuperProtocol.FromProtocol(protocol);

            Address address = await _addressRepository.GetById(protocol.RoadAccidentAddressId);
            if (address == null)
                throw new Exception($"RoadAccidentAddress was not found. RoadAccidentAddressId = {protocol.RoadAccidentAddressId}");
            superProtocol.RoadAccidentAddress = address;

            address = await _addressRepository.GetById(protocol.CreationPalceAddressId);
            if (address == null)
                throw new Exception($"CreationPalceAddressId was not found. CreationPalceAddressId = {protocol.CreationPalceAddressId}");
            superProtocol.CreationPalceAddress = address;

            Employee employee = await _employeeRepository.GetById(protocol.EmployeeId);
            if (employee == null)
                throw new Exception($"There is no such employee with id = {protocol.EmployeeId}");
            superProtocol.Creator = employee;

            IEnumerable<SuperParticipant> superParticipants = await GetSuperParticipants(protocol.Id);
            if (superParticipants == null)
                throw new Exception($"There is no any participants in road accident with id = {id}");
            superProtocol.Participants = superParticipants;

            IEnumerable<SuperProtocolAppendix> superProtocolAppendices = await GetSuperProtocolAppendices(protocol.Id);
            if (superProtocolAppendices == null)
                throw new Exception($"There is no any appendices in road accident with id = {id}");
            superProtocol.ProtocolAppendices = superProtocolAppendices;

            return superProtocol;
        }

        protected async Task<IEnumerable<SuperParticipant>> GetSuperParticipants(int protocolId)
        {

            IEnumerable<Participant> allParticipants = await _participantRepository.GetAll();
            if (allParticipants == null)
                throw new Exception("Participants were not found");

            List<Participant> participants = new List<Participant>();
            foreach (Participant participant in allParticipants)
            {
                if (participant.ProtocolId == protocolId)
                    participants.Add(participant);
            }
            
            SuperParticipant superParticipant;
            SuperUser superUser;
            RoleInRoadAccident roleInRoadAccident;
            List<SuperParticipant> superParticipants = new List<SuperParticipant>();
            foreach (Participant participant in participants)
            {
                superParticipant = SuperParticipant.FromParticipant(participant);

                superUser = await GetSuperUserById(participant.CitizenId);
                if (superUser == null)
                    throw new Exception($"Citizen with id = {participant.CitizenId} was not found");
                superParticipant.SuperUser = superUser;

                roleInRoadAccident = await _roleRepository.GetById(participant.RoleInRoadAccidentId);
                if (roleInRoadAccident == null)
                    throw new Exception($"Invalid role id = {participant.RoleInRoadAccidentId}");
                superParticipant.Role = roleInRoadAccident;

                superParticipants.Add(superParticipant);
            }
            return superParticipants;
        }

        protected async Task<SuperUser> GetSuperUserById(int id)
        {
            SuperUser superUser = new SuperUser();
            Citizen citizen = await _citizenRepository.GetById(id);
            if (citizen == null)
                return null;
            superUser.CustomCitizen = CustomCitizen.FromCitizen(citizen);

            Address address = await _addressRepository.GetById(citizen.ResidentialAddressId);
            superUser.CustomCitizen.ResidentialAddress = address;

            address = await _addressRepository.GetById(citizen.RegistrationAddressId);
            superUser.CustomCitizen.RegistrationAddress = address;

            address = await _addressRepository.GetById(citizen.WorkPlaceAddressId);
            superUser.CustomCitizen.WorkPlaceAddress = address;

            IEnumerable<Passport> passports = await _passportRepository.GetAll();
            foreach (Passport passport in passports)
            {
                if (passport.OwnerId == citizen.Id && passport.IsValid)
                {
                    superUser.Passport = passport;
                    break;
                }
            }
            IEnumerable<DriverLicense> driverLicenses = await _driverLicenseRepository.GetAll();
            foreach (DriverLicense license in driverLicenses)
            {
                if (license.OwnerId == citizen.Id && license.IsValid)
                {
                    superUser.DriverLicense = license;
                    break;
                }
            }
            return superUser;
        }

        protected async Task<IEnumerable<SuperProtocolAppendix>> GetSuperProtocolAppendices(int protocolId)
        {
            IEnumerable<ProtocolAppendix> protocolAppendices = await _protocolAppendixRepository.GetAll();
            if (protocolAppendices == null)
                throw new Exception("There is no any protocol appendices in database");

            List<ProtocolAppendix> appendices = new List<ProtocolAppendix>();
            foreach (ProtocolAppendix appendix in protocolAppendices)
            {
                if (appendix.ProtocolId == protocolId)
                    appendices.Add(appendix);
            }

            List<SuperProtocolAppendix> superProtocolAppendices = new List<SuperProtocolAppendix>();
            SuperProtocolAppendix superProtocolAppendix;
            foreach (ProtocolAppendix appendix in appendices)
            {
                superProtocolAppendix = SuperProtocolAppendix.FromProtocolAppendix(appendix);
                superProtocolAppendix.Vehicle = await GetSuperVehicleById(appendix.VehicleId);
                superProtocolAppendices.Add(superProtocolAppendix);
            }
            return superProtocolAppendices;
        }

        protected virtual async Task<CustomVehicle> GetSuperVehicleById(int id)
        {
            CustomVehicle customVehicle;
            Vehicle vehicle = await _vehicleRepository.GetById(id);
            if (vehicle == null)
                throw new Exception($"Invalid vehicle id = {id}");
            Color color = await _colorRepository.GetById(vehicle.ColorId);
            if (color == null)
                throw new Exception($"Invalid color id = {vehicle.ColorId}");
            Model model = await _modelRepository.GetById(vehicle.ModelId);
            if (model == null)
                throw new Exception($"Invalid model id = {vehicle.ModelId}");
            Category category = await _categoryRepository.GetById(vehicle.CategoryId);
            if (category == null)
                throw new Exception($"Invalid category id = {vehicle.CategoryId}");
            customVehicle = CustomVehicle.FromVehicle(vehicle);
            customVehicle.ModelName = model?.Name;
            customVehicle.ColorName = color?.Name;
            customVehicle.CategoryName = category?.Name;
            return customVehicle;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SuperProtocol>>> GetAllProtocols()
        {
            try
            {
                IEnumerable<Protocol> protocols = await _protocolRepository.GetAll();
                if (protocols == null)
                    throw new Exception("There is no any protocol in database!");
                List<SuperProtocol> superProtocols = new List<SuperProtocol>();
                SuperProtocol superProtocol;
                foreach (Protocol protocol in protocols)
                {
                    superProtocol = await GetSuperProtocolById(protocol.Id);
                    if (superProtocol != null)
                        superProtocols.Add(superProtocol);
                }
                return Ok(superProtocols);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSuperProtocol(SuperProtocol superProtocol)
        {
            try
            {
                superProtocol.CreationPalceAddressId = await GetOrCreateAddress(superProtocol.CreationPalceAddress);
                superProtocol.RoadAccidentAddressId = await GetOrCreateAddress(superProtocol.RoadAccidentAddress);

                superProtocol.EmployeeId = await GetOrCreateEmplyee(superProtocol.Creator);

                await _protocolRepository.CreateEntity(superProtocol);
                IEnumerable<Protocol> protocols = await _protocolRepository.GetAll();
                int protocolId = protocols.OrderBy((protocol) => protocol.Id).Last().Id;

                foreach (SuperParticipant superParticipant in superProtocol.Participants)
                {
                    await GetOrCreateSuperParticipant(superParticipant, protocolId);
                }

                foreach (var item in superProtocol.ProtocolAppendices)
                {
                    await CreateSuperProtocolAppendix(item, protocolId);
                }
                
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected async Task<int> GetOrCreateEmplyee(Employee employee)
        {
            IEnumerable<Employee> employees = await _employeeRepository.GetAll();
            foreach (var item in employees)
            {
                if (item.EqualNotById(employee))
                    return item.Id;
            }
            await _employeeRepository.CreateEntity(employee);
            employees = await _employeeRepository.GetAll();
            return employees.OrderBy((emp) => emp.Id).Last().Id;
        }

        protected async Task CreateSuperProtocolAppendix(SuperProtocolAppendix appendix, int protocolId)
        {
            int vehicleId = await CreateCustomVehicle(appendix.Vehicle);
            appendix.VehicleId = vehicleId;
            appendix.ProtocolId = protocolId;
            await _protocolAppendixRepository.CreateEntity(appendix);
        }

        protected async Task<int> CreateCustomVehicle(CustomVehicle customVehicle)
        {
            IEnumerable<Vehicle> vehicles = await _vehicleRepository.GetAll();
            foreach (var item in vehicles)
            {
                if (item.EqualNotById(customVehicle))
                    return item.Id;
            }
            //
            // Марки, модели, категория и цвет по имени не создаются
            //
            await _vehicleRepository.CreateEntity(customVehicle);
            vehicles = await _vehicleRepository.GetAll();
            return vehicles.OrderBy((vehicle) => vehicle.Id).Last().Id;
        }

        protected async Task GetOrCreateSuperParticipant(SuperParticipant superParticipant, int protocolId)
        {
            int ctitzenId = await CreateSuperUser(superParticipant.SuperUser);
            int roleId = await CreateRole(superParticipant.Role);
            superParticipant.CitizenId = ctitzenId;
            superParticipant.ProtocolId = protocolId;
            superParticipant.RoleInRoadAccidentId = roleId;
            await _participantRepository.CreateEntity(superParticipant);
        }

        protected async Task<int> CreateRole(RoleInRoadAccident roleInRoadAccident)
        {
            IEnumerable<RoleInRoadAccident> roles = await _roleRepository.GetAll();
            foreach (RoleInRoadAccident role in roles)
            {
                if (role.RoleName == roleInRoadAccident.RoleName)
                    return role.Id;
            }
            await _roleRepository.CreateEntity(roleInRoadAccident);
            roles = await _roleRepository.GetAll();
            return roles.OrderBy((role) => role.Id).Last().Id;
        }

        protected async Task<int> CreateSuperUser(SuperUser superUser)
        {
            int citizenId = await CreateCustomCitizen(superUser.CustomCitizen);
            superUser.Passport.OwnerId = citizenId;
            int passportId = await CreatePassport(superUser.Passport);
            superUser.DriverLicense.OwnerId = citizenId;
            int licenseId = await CreateDriverLicense(superUser.DriverLicense);
            return citizenId;
        }

        protected async Task<int> CreateDriverLicense(DriverLicense driverLicense)
        {
            IEnumerable<DriverLicense> licences = await _driverLicenseRepository.GetAll();
            foreach (var item in licences)
            {
                if (driverLicense.EqualNotById(item))
                    return item.Id;
            }
            await _driverLicenseRepository.CreateEntity(driverLicense);
            licences = await _driverLicenseRepository.GetAll();
            return licences.OrderBy((license) => license.Id).Last().Id;
        }

        protected async Task<int> CreatePassport(Passport passport)
        {
            IEnumerable<Passport> passports = await _passportRepository.GetAll();
            foreach (var item in passports)
            {
                if (passport.EqualNotById(item))
                    return item.Id;
            }
            await _passportRepository.CreateEntity(passport);
            passports = await _passportRepository.GetAll();
            return passports.OrderBy((pass) => pass.Id).Last().Id;
        }

        protected async Task<int> CreateCustomCitizen(CustomCitizen customCitizen)
        {
            IEnumerable<Citizen> citizens = await _citizenRepository.GetAll();
            customCitizen.RegistrationAddressId = await GetOrCreateAddress(customCitizen.RegistrationAddress);
            customCitizen.ResidentialAddressId = await GetOrCreateAddress(customCitizen.ResidentialAddress);
            customCitizen.WorkPlaceAddressId = await GetOrCreateAddress(customCitizen.WorkPlaceAddress);
            foreach (Citizen citizen in citizens)
            {
                if (citizen.EqualNotById(customCitizen))
                    return citizen.Id;
            }
            await _citizenRepository.CreateEntity(customCitizen);
            citizens = await _citizenRepository.GetAll();
            return citizens.OrderBy((citizen) => citizen.Id).Last().Id;
        }

        protected async Task<int> GetOrCreateAddress(Address address)
        {
            IEnumerable<Address> addresses = await _addressRepository.GetAll();
            foreach (Address addr in addresses)
            {
                if (address.EqualNotById(addr))
                {
                    return addr.Id;
                }
            }
            await _addressRepository.CreateEntity(address);
            addresses = await _addressRepository.GetAll();
            return addresses.OrderBy((addr) => addr.Id).Last().Id;
        }
    }
}
