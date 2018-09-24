using DomainModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Interfaces.Repository
{
    public interface IRepository<T> where T: EntityBase
    {
        void Create(T entity);
        T Get(Guid? id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Delete(Guid id);
    }
}
