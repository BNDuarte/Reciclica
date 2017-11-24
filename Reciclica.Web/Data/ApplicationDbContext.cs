using Microsoft.EntityFrameworkCore;
using Reciclica.Web.Empresas;
using Reciclica.Web.Materiais;
using Reciclica.Web.Pontos;

namespace Reciclica.Web.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


        public DbSet<Material> Material { get; set; }

        public DbSet<Empresa> Empresa{ get; set; }

        public DbSet<Ponto> Ponto { get; set; }
    }
}
