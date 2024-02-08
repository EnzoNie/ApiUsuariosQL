using Microsoft.EntityFrameworkCore;
using ApiUsuarioSql.Models;

namespace ApiUsuarioSql.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ListaTarefas> ListaTarefas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=TesteAPI;Data Source=ENZO\\SQLEXPRESS;Encrypt=True;TrustServerCertificate=True");//Aqui vai a CONNECTION STRING
        }
    }
}
