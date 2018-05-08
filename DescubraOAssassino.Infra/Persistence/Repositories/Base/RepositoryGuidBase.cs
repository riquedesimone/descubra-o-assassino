using DescubraOAssassino.Domain.Entities.Base;
using DescubraOAssassino.Domain.Inferfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DescubraOAssassino.Infra.Persistence.Repositories.Base
{
    public class RepositoryBase<TEntity, TId> : IRepositoryBase<TEntity, TId>
        where TEntity : EntityBase
        where TId : struct
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public TEntity Adicionar(TEntity entidade)
        {
            return _context.Set<TEntity>().Add(entidade);
        }

        public IEnumerable<TEntity> AdicionarLista(IEnumerable<TEntity> entidades)
        {
            return _context.Set<TEntity>().AddRange(entidades);
        }

        public TEntity Editar(TEntity entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;

            return entidade;
        }

        public bool Existe(Func<TEntity, bool> where)
        {
            return _context.Set<TEntity>().Any(where);
        }

        public IQueryable<TEntity> Listar(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IOrderedQueryable<TEntity> query = _context.Set<TEntity>();

            if (includeProperties.Any())
            {
                return Include(_context.Set<TEntity>(), includeProperties);
            }

            return query;
        }

        public IQueryable<TEntity> ListarEOrdernarPor<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return ascendente ? ListarPor(where, includeProperties).OrderBy(ordem) : ListarPor(where, includeProperties).OrderByDescending(ordem);
        }

        public IQueryable<TEntity> ListarOrdenadosPor<TKey>(Expression<Func<TEntity, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return ascendente ? Listar(includeProperties).OrderBy(ordem) : Listar(includeProperties).OrderByDescending(ordem);
        }

        public IQueryable<TEntity> ListarPor(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Listar(includeProperties).Where(where);
        }

        public TEntity ObterPor(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Listar(includeProperties).FirstOrDefault(where);
        }

        public TEntity ObterPorId(TId id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            if (includeProperties.Any())
            {
                return Listar(includeProperties).FirstOrDefault(x => x.Id.ToString() == id.ToString());
            }

            return _context.Set<TEntity>().Find(id);
        }

        public void Remover(TEntity entidade)
        {
            _context.Set<TEntity>().Remove(entidade);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private IQueryable<TEntity> Include(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            return query;
        }
    }
}
