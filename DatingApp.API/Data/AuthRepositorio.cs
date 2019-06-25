using System;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{


    public class AuthRepositorio : IAuthRepositorio
    {
        public DataContext _Context { get; }

        public AuthRepositorio(DataContext context)
        {
            _Context = context;


        }
        public async Task<Usuario> Login(string nombre, string password)
        {
            var usuario= await _Context.Usuario.FirstOrDefaultAsync(x => x.Nombre == nombre);
            if(usuario==null)
                return null;
            if(!VerificarPasswordHash(password, usuario.Password, usuario.PasswordConfirmado))
                return null;

            return usuario;
        }

        private bool VerificarPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
             using ( var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
           {
              var ComputeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
              for (int i =0 ; i< ComputeHash.Length; i++)
              {
                if(ComputeHash[i] != passwordHash[i]) return false;
              }
              return true;
           }
        }

        public async Task<Usuario> Registro(Usuario usuario, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password,out passwordHash,out passwordSalt);

            usuario.Password = passwordHash;
            usuario.PasswordConfirmado = passwordSalt;

            await _Context.Usuario.AddAsync(usuario);
            await _Context.SaveChangesAsync();

            return usuario;
        }

        private void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
           using ( var hmac = new System.Security.Cryptography.HMACSHA512())
           {
               passwordSalt = hmac.Key;
               passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
           }
        }

        public async Task<bool> UsarioExistente(string nombre)
        {
            if(await _Context.Usuario.AnyAsync(x=> x.Nombre == nombre))
            return true;
        
        return false;
        }
    }
}