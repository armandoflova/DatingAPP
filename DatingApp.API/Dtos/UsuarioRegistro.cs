using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UsuarioRegistro
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage= "Contraseña debe contener entre 8 y 4 caracteres")]
        public string Password { get; set; } 
    }
}