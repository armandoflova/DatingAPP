using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthRepositorioController : Controller
    {
        private readonly IAuthRepositorio _repo ;
        public AuthRepositorioController(IAuthRepositorio repo)
        {
            _repo = repo;
        }

    [HttpPost("Registro")]
    public async Task<IActionResult> Registro(UsuarioRegistro usuarioregistro)
    {
        //validar usuario
        usuarioregistro.Nombre =usuarioregistro.Nombre.ToLower();
        if(await _repo.UsarioExistente(usuarioregistro.Nombre))
            return BadRequest("Usuario ya existe");
        var nombreCreado = new Usuario
        {
            Nombre = usuarioregistro.Nombre
        };
        var usuarioCreado = await _repo.Registro(nombreCreado, usuarioregistro.Password);

        return StatusCode(201);
    }

    }
}