using GibddApp.API.Data;
using GibddApp.API.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GibddApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : TemplateController<Model>
    {
        public ModelController(IRepository<Model> repository) : base(repository)
        {
        }
    }
}
