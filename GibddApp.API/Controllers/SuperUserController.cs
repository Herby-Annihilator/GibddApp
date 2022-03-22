using GibddApp.API.Data;
using GibddApp.API.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GibddApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperUserController : ControllerBase
    {
        private IRepository<Citizen> _citizenRepository;
        private IRepository<Passport> _passportRepository;
        private IRepository<DriverLicense> _driverLicenseRepository;
        private IRepository<Address> _addressRepository;

        public SuperUserController(IRepository<Citizen> citizenRepository, IRepository<Passport> passportRepository,
            IRepository<DriverLicense> driverLicenseRepository, IRepository<Address> addressRepository)
        {
            _citizenRepository = citizenRepository;
            _passportRepository = passportRepository;
            _driverLicenseRepository = driverLicenseRepository;
            _addressRepository = addressRepository;
        }

        [HttpGet("id:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SuperUser>> GetSuperUser(int id)
        {
            SuperUser superUser = await GetSuperUserById(id);
            if (superUser == null)
                return NotFound("User was not found!");
            if (superUser.Passport == null)
                return NotFound("User has no passport!");
            if (superUser.CustomCitizen.WorkPlaceAddress == null)
                return NotFound("Work place address was not found");
            if (superUser.CustomCitizen.ResidentialAddress == null)
                return NotFound("ResidentialAddress was not found");
            if (superUser.CustomCitizen.RegistrationAddress == null)
                return NotFound("Registration address was not found");
            //
            // надо бы как то обработать отсутствие водительского удостоверения
            //
            return Ok(superUser);
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SuperUser>>> GetAll()
        {
            IEnumerable<Citizen> citizens = await _citizenRepository.GetAll();
            if (citizens == null || citizens.Count() == 0)
                return NotFound("Collection is null or empty");
            List<SuperUser> superUsers = new List<SuperUser>();
            foreach (Citizen citizen in citizens)
            {
                superUsers.Add(await GetSuperUserById(citizen.Id));
            }
            return Ok(superUsers);
        }
    }
}
