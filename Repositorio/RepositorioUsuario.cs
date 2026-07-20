using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks; // Importante para usar Task e async/await
using HubSpace.Web.Models;

namespace HubSpace.Web.Repositorio
{
    
    public class RepositorioUsuario : RepositorioPadrao<Usuario>
    {
        //recebe o DbContext e passa pra base
        public RepositorioUsuario(DbContext contextoo) : base(contextoo) {}
        
        // metodo p buscar pelo Nome
        public Usuario ObterPorNome(string nome) => _dbSet.FirstOrDefault(u => u.Nome == nome);
        
        //busca assíncrona focada no E-mail
        public async Task<Usuario> ObterPorEmailAsync(string email) 
            => await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
    }
}