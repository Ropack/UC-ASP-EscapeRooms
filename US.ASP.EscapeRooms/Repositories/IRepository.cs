﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using US.ASP.EscapeRooms.DAL.Entities;

namespace US.ASP.EscapeRooms.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        void Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> entities);

        void Delete(int id);

        void Delete(IEnumerable<int> ids);

        TEntity GetById(int id);
        IList<TEntity> GetByIds(IEnumerable<int> ids);
        void Insert(TEntity entity);

        void Insert(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);
        IList<TEntity> GetAll();
    }
}