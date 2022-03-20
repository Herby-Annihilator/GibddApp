using GibddApp.API.Data;
using GibddApp.API.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GibddApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : TemplateController<Color>
    {
        public ColorController(IRepository<Color> repository) : base(repository)
        {
        }
    }
}
