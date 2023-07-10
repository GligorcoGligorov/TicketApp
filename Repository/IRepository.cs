using System;
using System.Collections.Generic;
using Domain;

namespace Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        public T Delete(T entity);
        public T Insert(T entity);

        public T Update(T entity);
        public T Get(Guid? id);
        public IEnumerable<T> GetAll();

    }
}