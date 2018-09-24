using DataAccess.Services.Elastic;
using DomainModel.Entities;
using DomainModel.Interfaces.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Elastic.Entities
{
    public class WebPageElasticRepository : ElasticRepositoryBase<WebPage>, IWebPageRepository
    {
        private ElasticConnection<WebPage> _elasticConnection;

        public WebPageElasticRepository(ElasticConnection<WebPage> elasticConnection)
            :base(elasticConnection)
        {
            _elasticConnection = elasticConnection;
        }

        public IEnumerable<WebPage> SearchByContent(string content)
        {
            return _elasticConnection.SearchByField("content", content);
        }

        public IEnumerable<WebPage> SearchByTitle(string title)
        {
            return _elasticConnection.SearchByField("title", title);
        }
    }
}
