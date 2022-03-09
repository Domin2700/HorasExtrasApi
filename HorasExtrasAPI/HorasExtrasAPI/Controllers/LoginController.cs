using HorasExtrasAPI.Context;
using HorasExtrasAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
                var usuario = await _context.Usuario
                    .AnyAsync(usuario => 
                        usuario.User.ToLower() == userLogin.User.ToLower() && usuario.Enable == true );

                if(usuario)
                {
                     BuildToken(userLogin.User.Trim().ToLower());
                }
                else
                {
                    ModelState.AddModelError("Messaje","Usuario o contraseña incorrecta");
                    return BadRequest(ModelState);
                }
            }
            else
            {

            }

            return Ok();
        }


        //En este metodo  genera y envia al token al cliente
        private IActionResult BuildToken(string usuario)
        {

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };




            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);



            DateTime expiration = DateTime.UtcNow.AddHours(8);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: _configuration["Jwt:Issuer"],
               audience: _configuration["Jwt:Issuer"],
               claims: claims,
               expires: expiration,
               signingCredentials: creds);


            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration


            });



        }
    }
}
