using GibddApp.API.Data;
using GibddApp.API.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GibddApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessCategoryController : TemplateController<AccessCategory>
    {
        public AccessCategoryController(IRepository<AccessCategory> repository) : base(repository)
        {
        }
    }
}
