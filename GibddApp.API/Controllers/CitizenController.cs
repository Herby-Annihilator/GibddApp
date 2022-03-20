using GibddApp.API.Data;
using GibddApp.API.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GibddApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizenController : TemplateController<Citizen>
    {
        public CitizenController(IRepository<Citizen> repository) : base(repository)
        {
        }
    }
}
