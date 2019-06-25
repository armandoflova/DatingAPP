using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IAuthRepositorio
    {
         Task<Usuario> Registro(Usuario usuario, string password);
         Task<Usuario> Login(string nombre, string password);
         Task<bool> UsarioExistente(string nombre);
        
            
    }
}