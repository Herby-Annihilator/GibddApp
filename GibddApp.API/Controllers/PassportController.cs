using GibddApp.API.Data;
using GibddApp.API.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GibddApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassportController : TemplateController<Passport>
    {
        public PassportController(IRepository<Passport> repository) : base(repository)
        {
        }
    }
}
