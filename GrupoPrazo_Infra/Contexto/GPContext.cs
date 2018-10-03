using GrupoPrazo_Infra.Entidades;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace GrupoPrazo_Infra.Data
{
    public class GPContext : DbContext
    {
        public GPContext() 
            : base("GpContext_Est")
        {

        }

        public DbSet<Usuario> Ususario { get; set; }

        public DbSet<Tarefa> Tarefa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}