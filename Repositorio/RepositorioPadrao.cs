using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HubSpace.Web.Repositorio.Interface;


namespace HubSpace.Web.Repositorio
{


public class RepositorioPadrao<TEntity> : IRepositorioPadrao<TEntity> where TEntity : class
{
    protected readonly DbContext _contexto;
    protected readonly DbSet<TEntity> _dbSet;

    public RepositorioPadrao(DbContext contexto)
    {
        _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        _dbSet = _contexto.Set<TEntity>();
    }

    public TEntity ObterPorId(int id) => _dbSet.Find(id);

    public async Task<TEntity> ObterPorIdAsync(int id) => await _dbSet.FindAsync(id);

    public IEnumerable<TEntity> ObterTodos() => _dbSet.ToList();

    public async Task<List<TEntity>> ObterTodosAsync() => await _dbSet.ToListAsync();

    public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicado)
        => _dbSet.Where(predicado).ToList();

    public async Task<List<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicado)
        => await _dbSet.Where(predicado).ToListAsync();

    public TEntity ObterPrimeiro(Expression<Func<TEntity, bool>> predicado)
        => _dbSet.FirstOrDefault(predicado);

    public async Task<TEntity> ObterPrimeiroAsync(Expression<Func<TEntity, bool>> predicado)
        => await _dbSet.FirstOrDefaultAsync(predicado);

    public void Adicionar(TEntity entidade) => _dbSet.Add(entidade);

    public void AdicionarVarios(IEnumerable<TEntity> entidades) => _dbSet.AddRange(entidades);

    public void Atualizar(TEntity entidade)
    {
        _dbSet.Attach(entidade);
        _contexto.Entry(entidade).State = EntityState.Modified;
    }

    public void Remover(TEntity entidade)
    {
        if (_contexto.Entry(entidade).State == EntityState.Detached)
            _dbSet.Attach(entidade);

        _dbSet.Remove(entidade);
    }

    public void RemoverVarios(IEnumerable<TEntity> entidades) => _dbSet.RemoveRange(entidades);

    public IQueryable<TEntity> Consultar() => _dbSet.AsQueryable();

    public void Salvar() => _contexto.SaveChanges();

    public async Task SalvarAsync() => await _contexto.SaveChangesAsync();
}
}