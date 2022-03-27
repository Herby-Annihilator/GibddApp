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
    public class SuperVehicleController : ControllerBase
    {
        private IRepository<Vehicle> _vehicleRepository;
        private IRepository<Color> _colorRepository;
        private IRepository<Mark> _markRepository;
        private IRepository<Model> _modelRepository;
        private IRepository<Category> _categoryRepository;

        public SuperVehicleController(IRepository<Vehicle> vehicleRepository, IRepository<Color> colorRepository,
            IRepository<Mark> markRepository, IRepository<Model> modelRepository, IRepository<Category> categoryRepository)
        {
            _vehicleRepository = vehicleRepository;
            _colorRepository = colorRepository;
            _markRepository = markRepository;
            _modelRepository = modelRepository;
            _categoryRepository = categoryRepository;
        }

        #region SuperVehicle
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomVehicle>> GetSuperVehicle(int id)
        {
            CustomVehicle customVehicle = await GetSuperVehicleById(id);
            if (customVehicle == null)
            {
                return NotFound("Vehicle was not found!");
            }

            if (customVehicle.ColorName == null)
            {
                return NotFound("Color was not found!");
            }
            else if (customVehicle.ModelName == null)
            {
                return NotFound("Model was not found!");
            }
            else if (customVehicle.CategoryName == null)
            {
                return NotFound("Catgory was not found!");
            }

            return Ok(customVehicle);
        }

        protected virtual async Task<CustomVehicle> GetSuperVehicleById(int id)
        {
            CustomVehicle customVehicle;
            Vehicle vehicle = await _vehicleRepository.GetById(id);
            if (vehicle == null)
                return null;
            Color color = await _colorRepository.GetById(vehicle.ColorId);
            Model model = await _modelRepository.GetById(vehicle.ModelId);
            Category category = await _categoryRepository.GetById(vehicle.CategoryId);
            customVehicle = CustomVehicle.FromVehicle(vehicle);
            customVehicle.ModelName = model?.Name;
            customVehicle.ColorName = color?.Name;
            customVehicle.CategoryName = category?.Name;
            return customVehicle;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CustomVehicle>>> GetAllSuperVehicles()
        {
            IEnumerable<Vehicle> vehicles = await _vehicleRepository.GetAll();
            if (vehicles == null || vehicles.Count() == 0)
                return NotFound("Collection is null or empty");

            List<CustomVehicle> customVehicles = new List<CustomVehicle>();
            foreach (Vehicle vehicle in vehicles)
            {
                customVehicles.Add(await GetSuperVehicleById(vehicle.Id));
            }
            return Ok(customVehicles);
        }
        #endregion

    }
}
