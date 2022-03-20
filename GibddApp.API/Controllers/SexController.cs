using GibddApp.API.Data;
using GibddApp.API.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GibddApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SexController : TemplateController<Sex>
    {
        public SexController(IRepository<Sex> repository) : base(repository)
        {
        }
    }
}
