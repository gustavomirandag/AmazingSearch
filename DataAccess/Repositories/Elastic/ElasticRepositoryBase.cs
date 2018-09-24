using DataAccess.Services.Elastic;
using DomainModel.Base;
using DomainModel.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Elastic
{
    public abstract class ElasticRepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        private ElasticConnection<T> _elasticConnection;

        public ElasticRepositoryBase(ElasticConnection<T> elasticConnection)
        {
            _elasticConnection = elasticConnection;
            _elasticConnection.CreateIndex(); //Create if not exist
        }

        public void Create(T entity)
        {
            _elasticConnection.AddDocumentToIndex(entity);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public T Get(Guid? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
