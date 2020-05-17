using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZydusFrontline.Interface.Services
{
    [Obsolete]
    public interface IAddService<TEntity, TQuery, TResp> where TEntity : class
    {
       Task<TResp> Add(TEntity entity);
    }

    [Obsolete]
    public interface IUpdateService<TEntity, TQuery, TResp> where TEntity : class
    {
        Task<TResp> Update(TEntity entity);
    }

    [Obsolete]
    public interface IDeleteService<TEntity, TQuery, TResp> where TEntity : class
    {
        Task<TResp> Delete(TEntity entity);
    }

    [Obsolete]
    public interface IFindService<TEntity, TQuery, TResp> where TEntity : class
    {
        Task<List<TEntity>> Find(TQuery query);
    }
}
