using GibddApp.API.Data;
using GibddApp.API.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GibddApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : TemplateController<Position>
    {
        public PositionController(IRepository<Position> repository) : base(repository)
        {
        }
    }
}
