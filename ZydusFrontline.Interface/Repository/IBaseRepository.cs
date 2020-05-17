
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZydusFrontline.Interface.Repository
{
    [Obsolete]
    public interface IAddRepository<TEntity, TQuery, TResp> where TEntity : class
    {
        Task<TResp> Add(TEntity entity);
    }

    [Obsolete]
    public interface IUpdateRepository<TEntity, TQuery, TResp> where TEntity : class
    {
        Task<TResp> Update(TEntity entity);
    }

    [Obsolete]
    public interface IDeleteRepository<TEntity, TQuery, TResp> where TEntity : class
    {
        Task<TResp> Delete(TEntity entity);
    }

    [Obsolete]
    public interface IFindRepository<TEntity, TQuery, TResp> where TEntity : class
    {
        Task<IQueryable<TEntity>> Entities(TQuery query);      
    }
}
