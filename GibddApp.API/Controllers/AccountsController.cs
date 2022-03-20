using GibddApp.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Text.Json;
using GibddApp.API.Services.Base;

namespace GibddApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : TemplateController<Account>
    {
        public AccountsController(IRepository<Account> repository) : base(repository)
        {
        }
    }
}
