using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthRepositorioController : Controller
    {
        private readonly IAuthRepositorio _repo;
        public IConfiguration _Config ;
        public AuthRepositorioController(IAuthRepositorio repo, IConfiguration config)
        {
             _Config = config;
            _repo = repo;
        }

        [HttpPost("Registro")]
        public async Task<IActionResult> Registro(UsuarioRegistro usuarioregistro)
        {
            try{
                 //validar usuario
            usuarioregistro.Nombre = usuarioregistro.Nombre.ToLower();
            if (await _repo.UsarioExistente(usuarioregistro.Nombre))
                return BadRequest("Usuario ya existe");
            var nombreCreado = new Usuario
            {
                Nombre = usuarioregistro.Nombre
            };
            var usuarioCreado = await _repo.Registro(nombreCreado, usuarioregistro.Password);

            return StatusCode(201);

            }catch{
                return StatusCode(500 ,"Ocurrio un error");
            }
           
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login(UsuarioLogin usuariologin)
        {
            try{    
                var usuarioRepo = await _repo.Login(usuariologin.Nombre.ToLower(), usuariologin.Password);
            if (usuarioRepo == null)
                return Unauthorized();

            var claims = new[]
            {
             new Claim(ClaimTypes.NameIdentifier, usuarioRepo.Id.ToString()),
             new Claim(ClaimTypes.Name , usuarioRepo.Nombre)
         };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Config.GetSection("AppSettings:Token").Value));

            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var TokenDescripcion = new SecurityTokenDescriptor()
            {
                Subject =  new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credenciales
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(TokenDescripcion);

            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });
            }
            catch{
                return StatusCode(500, "Ocurrio un error");
            }
            
        }
    }
}