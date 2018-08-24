using System.Data.Entity;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class RepositoryContext : IRepositoryContext
    {
        private const string ObjectContextKey = "Infrastructure.SimsModel";

        /// <summary>
        /// Returns the active object context
        /// </summary>
        public DbContext ObjectContext { get; } = ContextManager.GetObjectContext(ObjectContextKey);

        public IDbSet<T> GetObjectSet<T>()
            where T : class
        {
            return ContextManager.GetObjectContext(ObjectContextKey).Set<T>();
        }

        public int SaveChanges()
        {
            return ObjectContext.SaveChanges();
        }

        public void Terminate()
        {
            ContextManager.SetRepositoryContext(null, ObjectContextKey);
        }
    }
}
