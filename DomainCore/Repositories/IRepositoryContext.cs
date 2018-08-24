using System.Collections.Generic;
using System.Data.Entity;

namespace Gnnovation.Sims.DomainCore.Repositories
{
    public interface IRepositoryContext
    {
        DbContext ObjectContext { get; }

        IDbSet<T> GetObjectSet<T>() where T : class;

        /// <summary>
        /// Save all changes to all repositories
        /// </summary>
        /// <returns>Integer with number of objects affected</returns>
        int SaveChanges();

        /// <summary>
        /// Terminates the current repository context
        /// </summary>
        void Terminate();
    }
}
