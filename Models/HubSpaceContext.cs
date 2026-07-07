using System.Data.Entity;

namespace HubSpace.Web.Models
{
    public class HubSpaceContext : DbContext
    {
        // O construtor lê a connectionString chamada "HubSpaceContext" lá do Web.config
        public HubSpaceContext() : base("name=HubSpaceContext")
        {
        }

        // Isso avisa ao EF para criar uma tabela chamada "Espacos" baseada na classe acima
        public DbSet<Espaco> Espacos { get; set; }
    }
}