using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Gnnovation.Sims.ApplicationCore.Repositories;

using IEntity = Gnnovation.Sims.ApplicationCore.Entities.IEntity;

namespace Gnnovation.Sims.Infrastructure.Repositories
{
    public class EntityFrameworkReadOnlyRepository<TContext> : IReadOnlyRepository
     where TContext : DbContext
    {
        protected readonly TContext context;

        public bool LazyLoadingEnabled { get => context.Configuration.LazyLoadingEnabled; set => context.Configuration.LazyLoadingEnabled = true; }

        public bool AutoDetectChangesEnabled { get => context.Configuration.AutoDetectChangesEnabled; set => context.Configuration.AutoDetectChangesEnabled = true; }

        public bool ProxyCreationEnabled { get => context.Configuration.ProxyCreationEnabled; set => context.Configuration.ProxyCreationEnabled = true; }

        public EntityFrameworkReadOnlyRepository(TContext context)
        {
            this.context = context;
        }

        public virtual IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class, IEntity
        {
            return context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
            where TEntity : class, IEntity
        {
            return GetQueryable(null, orderBy, null, null, includeProperties);
        }

        public virtual IEnumerable<TEntity> GetAll<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
            where TEntity : class, IEntity
        {
            return GetQueryable(null, orderBy, skip, take, includeProperties);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
            where TEntity : class, IEntity
        {
            return await GetQueryable<TEntity>(null, orderBy, skip, take, includeProperties).ToListAsync();
        }

        public virtual IEnumerable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
            where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter, orderBy, skip, take, includeProperties).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
            where TEntity : class, IEntity
        {
            return await GetQueryable<TEntity>(filter, orderBy, skip, take, includeProperties).ToListAsync();
        }

        public virtual TEntity GetOne<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
            where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter, null, null, null, includeProperties).SingleOrDefault();
        }

        public virtual async Task<TEntity> GetOneAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
            where TEntity : class, IEntity
        {
            return await GetQueryable<TEntity>(filter, null, null, null, includeProperties).SingleOrDefaultAsync();
        }

        public virtual TEntity GetFirst<TEntity>(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
           where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter, orderBy, null, null, includeProperties).FirstOrDefault();
        }

        public virtual async Task<TEntity> GetFirstAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
            where TEntity : class, IEntity
        {
            return await GetQueryable<TEntity>(filter, orderBy, null, null, includeProperties).FirstOrDefaultAsync();
        }

        public virtual TEntity GetById<TEntity>(object id)
            where TEntity : class, IEntity
        {
            return context.Set<TEntity>().Find(id);
        }

        public virtual Task<TEntity> GetByIdAsync<TEntity>(object id)
            where TEntity : class, IEntity
        {
            return context.Set<TEntity>().FindAsync(id);
        }

        public virtual int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter).Count();
        }

        public virtual Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter).CountAsync();
        }

        public virtual bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter).Any();
        }

        public virtual Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter).AnyAsync();
        }

        protected virtual IQueryable<TEntity> GetQueryable<TEntity>(
             Expression<Func<TEntity, bool>> filter = null,
             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
             int? skip = null,
             int? take = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
             where TEntity : class, IEntity
        {
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null && includeProperties.Length > 0)
            {
                query = includeProperties.Aggregate(query, (q, w) => q.Include(w));
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }


        protected virtual IQueryable<TEntity> GetQueryable<TEntity, TSelector>(
            TSelector selector,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
            where TEntity : class, IEntity

        {
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var propertyNames = string.Join(",", selector.GetType().GetProperties().Select(e => e.Name));

            if (includeProperties != null && includeProperties.Length > 0)
            {
                query = includeProperties.Aggregate(query, (q, w) => q.Include(w));
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }
    }
}
