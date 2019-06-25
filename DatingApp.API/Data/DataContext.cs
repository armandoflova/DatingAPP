using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DataContext: DbContext
    {
       public DataContext(DbContextOptions<DataContext> options) : base(options){}

       public DbSet<Valores> Valores{ get; set;}
       public DbSet<Usuario> Usuario{ get; set;}

    }
}