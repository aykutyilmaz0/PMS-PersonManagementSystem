using PersonManagementSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PersonManagementSystem.DataAccess.Abstract.Repository
{
    //T : person,role,ws
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> ListOperation(Expression<Func<T,bool>> filter = null);
        T GetPerson(Expression<Func<T, bool>> filter = null);
        T AddOperation(T entity);
        T UpdateOperation(T entity);
        void DeleteOperation(T entity);
    }
}
