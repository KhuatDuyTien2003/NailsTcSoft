using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NailTcSoft.Data;

namespace NailTcSoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ThuctapKtktcnNail2025Context _context;
        private readonly IConfiguration _configuration;
        public AccountController(ThuctapKtktcnNail2025Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public IActionResult Login()
        {
            return null;
        }
    }
}
