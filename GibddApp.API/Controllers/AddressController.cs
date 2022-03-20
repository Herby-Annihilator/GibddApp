using GibddApp.API.Data;
using GibddApp.API.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GibddApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : TemplateController<Address>
    {
        public AddressController(IRepository<Address> repository) : base(repository)
        {
        }
    }
}
