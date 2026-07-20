using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HubSpace.Web.Repositorio.Interface
{
    
    public interface IRepositorioPadrao<TEntity> where TEntity : class
    {
        TEntity ObterPorId(int id);
        Task<TEntity> ObterPorIdAsync(int id);

        IEnumerable<TEntity> ObterTodos();
        Task<List<TEntity>> ObterTodosAsync();

        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicado);
        Task<List<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicado);

        TEntity ObterPrimeiro(Expression<Func<TEntity, bool>> predicado);
        Task<TEntity> ObterPrimeiroAsync(Expression<Func<TEntity, bool>> predicado);

        void Adicionar(TEntity entidade);
        void AdicionarVarios(IEnumerable<TEntity> entidades);

        void Atualizar(TEntity entidade);

        void Remover(TEntity entidade);
        void RemoverVarios(IEnumerable<TEntity> entidades);

        IQueryable<TEntity> Consultar();

        void Salvar();
        Task SalvarAsync();
    }
}