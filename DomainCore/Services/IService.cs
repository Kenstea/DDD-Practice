using System.Collections.Generic;
using DomainCore.Models;
using PagedList;

namespace DomainCore.Services
{
    public interface IService<TEntity, TIdentifier>
    {
        TEntity Entity { get; set; }

        TModel GetById<TModel>(TIdentifier id) where TModel : BusinessModelBase<TIdentifier>;
        
        //TModel GetSingle<TModel>(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] includedProperties);

        IPagedList<TModel> GetPagedList<TModel>(int? page, int? pageNumber) where TModel : class;

        IEnumerable<TModel> GetAll<TModel>() where TModel : class;

        bool Insert<TModel>(TModel model) where TModel : class;
    }
}
