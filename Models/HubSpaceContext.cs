using System.Data.Entity;

namespace HubSpace.Web.Models
{
    public class HubSpaceContext : DbContext
    {
        
        public HubSpaceContext() : base("name=HubSpaceContext")
        {
        }

        // Isso avisa para criar as tabelas baseada na classe acima
        public DbSet<Espaco> Espacos { get; set; }
        
        public DbSet<Usuario> Usuarios { get; set; }
    }
}