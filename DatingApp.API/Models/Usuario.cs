namespace DatingApp.API.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public byte[] Password { get; set; }

        public byte[] PasswordConfirmado {get; set;} 
    }
}