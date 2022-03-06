using HorasExtrasAPI.Context;
using HorasExtrasAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorasExtrasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HorasExtrasDbContext _context;
       

        public LoginController( IConfiguration configuration, HorasExtrasDbContext context) 
        {
            _configuration = configuration;
            _context = context;
        }


        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            if(ModelState.IsValid)
            {

            }
            else
            {

            }
        }

    }
}
