using GibddApp.API.Data;
using GibddApp.API.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GibddApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleInRoadAccidentController : TemplateController<RoleInRoadAccident>
    {
        public RoleInRoadAccidentController(IRepository<RoleInRoadAccident> repository) : base(repository)
        {
        }
    }
}
