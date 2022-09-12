using PersonManagementSystem.DataAccess.Abstract.Repository;
using PersonManagementSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PersonManagementSystem.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity:class,IEntity,new()
        where TContext:DbContext,new()
    {
        public List<TEntity> ListOperation(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null

                     ? context.Set<TEntity>().ToList()
                     : context.Set<TEntity>().Where(filter).ToList();

            }
        }

        public TEntity GetPerson(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public TEntity AddOperation(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedPerson = context.Entry(entity);
                addedPerson.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public TEntity UpdateOperation(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedPerson = context.Entry(entity);
                updatedPerson.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }

        public void DeleteOperation(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletePerson = context.Entry(entity);
                deletePerson.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
