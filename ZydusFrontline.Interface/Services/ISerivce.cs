using System;
using System.Collections.Generic;

namespace ZydusFrontline.Interface.Services
{
    /// <summary>
    /// Repository interface to inherite all CRUD operations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TResp"></typeparam>
    public interface ISerivces<TEntity, TQuery, TResp>
        : IAddService<TEntity, TQuery, TResp>
        , IUpdateService<TEntity, TQuery, TResp>
        , IDeleteService<TEntity, TQuery, TResp>
        , IFindService<TEntity, TQuery, TResp>
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
    public interface IAddUpdateDeleteServices<TEntity, TQuery, TResp>
        : IAddService<TEntity, TQuery, TResp>
        , IUpdateService<TEntity, TQuery, TResp>
        , IDeleteService<TEntity, TQuery, TResp>
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
    public interface IAddSearchServices<TEntity, TQuery, TResp>
        : IAddService<TEntity, TQuery, TResp>
        , IFindService<TEntity, TQuery, TResp>
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
    public interface ISearchServices<TEntity, TQuery, TResp>
        : IFindService<TEntity, TQuery, TResp>
        where TEntity : class
    {
        void Dispose();
    }
}
