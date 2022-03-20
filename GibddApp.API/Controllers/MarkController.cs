using GibddApp.API.Data;
using GibddApp.API.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GibddApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : TemplateController<Mark>
    {
        public MarkController(IRepository<Mark> repository) : base(repository)
        {
        }
    }
}
