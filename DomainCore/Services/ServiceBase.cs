using System.Collections.Generic;
using System.Linq;
using DomainCore.Models;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Mapster;
using PagedList;

namespace DomainCore.Services
{
    public abstract class ServiceBase<TEntity, TIdentifier> : IService<TEntity, TIdentifier>
        where TEntity : RepositoryBase<TEntity, TIdentifier>, IEntity<TIdentifier>
    {   
        protected ServiceBase(TEntity entity)
        {
            Entity = entity; 
        }

        public TEntity Entity { get; set; }

        public TModel GetById<TModel>(TIdentifier id) where TModel : BusinessModelBase<TIdentifier>
        {
            // this does not support  e.Id.Equals(id) 
            return Entity.GetQuery().ProjectToType<TModel>().FirstOrDefault(e => e.Id.Equals(id));
        }

        //public TModel GetSingle<TModel>(
        //    Func<TEntity, bool> where,
        //    params Expression<Func<TEntity, object>>[] includedProperties)
        //{
        //    // does not support property included
        //    return Entity.GetQuery().Include("").ProjectToType<TModel>().FirstOrDefault(where);
        //    return default(TModel);
        //}

        public IPagedList<TModel> GetPagedList<TModel>(int? page, int? pageNumber) where TModel : class 
        { 
            return Entity.GetQuery().OrderByDescending(e => e.CreatedAt).ProjectToType<TModel>()
                .ToPagedList(page ?? 1, pageNumber ?? 10);
        }

        public IEnumerable<TModel> GetAll<TModel>() where TModel : class
        {
            return Entity.GetQuery().ProjectToType<TModel>().AsEnumerable();
        }

        public bool Insert<TModel>(TModel model) where TModel : class
        {
            var entity = model.Adapt<TEntity>();
            return Entity.Insert(entity);
        }
    }
}
