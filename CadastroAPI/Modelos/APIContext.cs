using Microsoft.EntityFrameworkCore;

namespace CadastroAPI
{
    public class APIContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Cargo> Cargos { get; set; }

        // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
        // For Mac or Linux, change this to `/tmp/blogging.db` or any other absolute path.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=C:\Projetos\BancoDeDados.db");

        protected override void OnModelCreating(ModelBuilder builder)
        {
               base.OnModelCreating(builder);
        }
    }
}