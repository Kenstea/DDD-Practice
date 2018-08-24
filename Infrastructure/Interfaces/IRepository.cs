using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Interfaces
{
    /// <summary>
    /// Base repository
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
    public interface IRepository<TEntity, TIdentifier>
    {
        IQueryable<TEntity> GetQuery();

        IEnumerable<TEntity> GetAll();

        //TEntity GetById(TIdentifier identifier);

        //TEntity GetSingle(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] includedProperties);

        bool Insert(TEntity entity);

        bool Insert(TEntity entity, bool commit);

        bool Update(TEntity entity);
    }
}
