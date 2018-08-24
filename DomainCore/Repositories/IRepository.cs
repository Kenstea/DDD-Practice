using System.Collections.Generic;
using System.Linq;

using Gnnovation.Sims.DomainCore.Interfaces;

namespace Gnnovation.Sims.DomainCore.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity<int>
    {
        IQueryable<TEntity> GetQuery();

        IEnumerable<TEntity> GetAll();

        //TEntity GetById(object id);

        //void Create<TEntity>(TEntity entity, string createdBy = null)
        //    where TEntity : class, IEntity;

        //void Update<TEntity>(TEntity entity, string modifiedBy = null)
        //    where TEntity : class, IEntity;

        //void Delete<TEntity>(object id)
        //    where TEntity : class, IEntity;

        //void Delete<TEntity>(TEntity entity)
        //    where TEntity : class, IEntity;

        //void Save();

        //Task SaveAsync();
    }
}
