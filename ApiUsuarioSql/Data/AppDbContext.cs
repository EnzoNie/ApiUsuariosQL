using Microsoft.EntityFrameworkCore;
using ApiUsuarioSql.Models;

namespace ApiUsuarioSql.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");//Aqui vai a CONNECTION STRING
        }
    }
}
