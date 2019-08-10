using DataAccess.Services.Elastic;
using DomainModel.Interfaces.Repository.Log;
using DomainModel.Log;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Elastic.Log
{
    public class ActivityLogElasticRepository<T> : ElasticRepositoryBase<T>, IActivityLogRepository<T> where T : ActivityLogBase
    {
        private ElasticConnection<T> _elasticConnection;

        public ActivityLogElasticRepository(ElasticConnection<T> elasticConnection)
            :base(elasticConnection)
        {
        }
    }
}
