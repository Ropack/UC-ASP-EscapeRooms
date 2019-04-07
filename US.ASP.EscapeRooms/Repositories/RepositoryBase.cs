using System;
using System.Collections.Generic;
using System.Linq;
using UC.CSP.MeetingCenter.DAL;
using UC.CSP.MeetingCenter.DAL.Entities;
using US.ASP.EscapeRooms.DAL;
using US.ASP.EscapeRooms.DAL.Entities;

namespace US.ASP.EscapeRooms.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        //protected AppDbContext Context => AppUnitOfWorkProvider.Instance.GetCurrent().Context;
        protected AppDbContext Context { get; }

        public RepositoryBase(AppDbContext context)
        {
            Context = context;
        }

        public void Delete(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetById(int id)
        {
            var entity = Context.Set<TEntity>().FirstOrDefault(r => r.Id == id);
            if (entity is ISoftDeletable softDeletableEntity)
            {
                if (softDeletableEntity.DeletedDate != null)
                {
                    return null;
                }
            }

            return entity;
        }

        public IList<TEntity> GetByIds(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public virtual void Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            var e = GetById(entity.Id);
            if (e == null)
            {
                return;
            }

            Context.Entry(e).CurrentValues.SetValues(entity);
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity is ISoftDeletable softDeletableEntity)
            {
                softDeletableEntity.DeletedDate = DateTime.UtcNow;
                Update(softDeletableEntity as TEntity);
            }
            else
            {
                Context.Set<TEntity>().Remove(entity);
            }
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}