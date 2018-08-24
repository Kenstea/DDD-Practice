using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class RepositoryBase<TEntity, TIdentifier> : IRepository<TEntity, TIdentifier>
        where TEntity : class, IEntity<TIdentifier>
    {
        private readonly IRepositoryContext _repositoryContext;

        public RepositoryBase()
            : this(new RepositoryContext())
        {
        }

        public RepositoryBase(IRepositoryContext repositoryContext)
        {
            repositoryContext = repositoryContext ?? new RepositoryContext();
            ObjectSet = repositoryContext.GetObjectSet<TEntity>();
            _repositoryContext = repositoryContext;
            AutoTrackingEnable = true;
        }

        public bool AutoTrackingEnable { get; set; }

        public bool AutoDetectChangesEnabled
        {
            get => _repositoryContext.ObjectContext.Configuration.AutoDetectChangesEnabled;
            set => _repositoryContext.ObjectContext.Configuration.AutoDetectChangesEnabled = value;
        }

        public bool LazyLoadingEnabled
        {
            get => _repositoryContext.ObjectContext.Configuration.LazyLoadingEnabled;
            set => _repositoryContext.ObjectContext.Configuration.LazyLoadingEnabled = value;
        }

        public bool ProxyCreationEnabled
        {
            get => _repositoryContext.ObjectContext.Configuration.ProxyCreationEnabled;
            set => _repositoryContext.ObjectContext.Configuration.ProxyCreationEnabled = value;
        }

        private IDbSet<TEntity> ObjectSet { get; }

        public virtual IQueryable<TEntity> GetQuery()
        {
            return !AutoTrackingEnable ? ObjectSet.AsQueryable().AsNoTracking() : ObjectSet.AsQueryable();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return !AutoTrackingEnable ? ObjectSet.AsNoTracking().AsEnumerable() : ObjectSet.AsEnumerable();
        }

        /// <summary>
        /// Gets the entity by identifier. This does not load related entities.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns></returns>
        //public TEntity GetById(TIdentifier identifier)
        //{
        //    return ObjectSet.Find(identifier);
        //}

        /// <summary>
        /// Gets the single entity. Support eager loading related entities.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includedProperties">The included properties.</param>
        /// <returns></returns>
        //public TEntity GetSingle(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] includedProperties)
        //{
        //    var item = ObjectSet.Include(e=>e.Id).AsNoTracking().SingleOrDefault(where);
        //    return item;
        //}

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="commitOnInserted">if set to <c>true</c> [commit on inserted].</param>
        /// <returns></returns>
        public bool Insert(TEntity entity, bool commitOnInserted)
        {
            if (entity == null)
            {
                return false;
            }

            try
            {
                if (commitOnInserted)
                {
                    Complete();
                }

                return true;
            }
            catch (Exception e)
            {
                // TODO: log exception and throw it
                throw;
            }
        }

        public bool Insert(TEntity entity)
        {
            return Insert(entity, true);
        }

        public bool Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Completes the persistence transaction.
        /// </summary>
        public void Complete()
        {
            if (_repositoryContext.ObjectContext != null)
            {
                try
                {
                    // TODO: handle audit fields here
                    _repositoryContext.SaveChanges();
                }
                catch (ChangeConflictException)
                {
                    // TODO: resolve change conflicts
                }
            }
        }
        public bool Compare<T>(T x, T y)
        {
            return EqualityComparer<T>.Default.Equals(x, y);
        }
    }
}
