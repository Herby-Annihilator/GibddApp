using GibddApp.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Text.Json;

namespace GibddApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        [HttpPut]
        [Route("create")]
        public async Task<IActionResult> CreateAccount(Citizen userData)
        {
            http://address:5000/Account/create
            if (Request.HasJsonContentType())
            {
                Citizen userData1 = await Request.ReadFromJsonAsync<Citizen>(new JsonSerializerOptions(JsonSerializerDefaults.Web) { WriteIndented = true});
                await Response.WriteAsJsonAsync<Citizen>(userData);
                return Ok(userData);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetDafaultUser()
        {
            
            return Ok();
        }
    }
}
