using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using GibddApp.API.Data;
using GibddApp.API.Services.Base;

namespace GibddApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryController : ControllerBase
    {
        private IRepository<Color> _colorRepository;
        public DirectoryController(IRepository<Color> repository)
        {
            _colorRepository = repository;
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Color>> GetColor(int id)
        {
            Color color = await _colorRepository.GetById(id);
            if (color != null)
                return Ok(color);
            else
                return NotFound();
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Color>>> GetAll()
        {
            IEnumerable<Color> colors = await _colorRepository.GetAll();
            if (colors != null)
                return Ok(colors);
            else
                return NotFound();
        }
    }
}
