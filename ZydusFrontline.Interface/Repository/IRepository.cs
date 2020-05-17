using System;
using System.Linq;

namespace ZydusFrontline.Interface.Repository
{
    /// <summary>
    /// Repository interface to inherite all CRUD operations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TResp"></typeparam>
    public interface IRepository<TEntity, TQuery, TResp>
        : IAddRepository<TEntity, TQuery, TResp>
        , IUpdateRepository<TEntity, TQuery, TResp>
        , IDeleteRepository<TEntity, TQuery, TResp>
        , IFindRepository<TEntity, TQuery, TResp>
        where TEntity : class
    {
        void Dispose();
    }

    /// <summary>
    /// Repository interface to inherite Add, Update & Delete operations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TResp"></typeparam>
    public interface IAddUpdateDeleteRepository<TEntity, TQuery, TResp>
        : IAddRepository<TEntity, TQuery, TResp>
        , IUpdateRepository<TEntity, TQuery, TResp>
        , IDeleteRepository<TEntity, TQuery, TResp>
        where TEntity : class
    {
        void Dispose();
    }

    /// <summary>
    /// Repository interface to inherite Add & Search operations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TResp"></typeparam>
    public interface IAddSearchRepository<TEntity, TQuery, TResp>
        : IAddRepository<TEntity, TQuery, TResp>
        , IFindRepository<TEntity, TQuery, TResp>
        where TEntity : class
    {
        void Dispose();
    }

    /// <summary>
    /// Repository interface to inherite only search operations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TResp"></typeparam>
    public interface ISearchRepository<TEntity, TQuery, TResp>
        : IFindRepository<TEntity, TQuery, TResp>
        where TEntity : class
    {
        void Dispose();
    }
}
