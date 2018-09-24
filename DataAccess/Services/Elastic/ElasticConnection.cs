using DomainModel;
using DomainModel.Base;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Services.Elastic
{
    public class ElasticConnection<T> where T : EntityBase
    {
        private ElasticClient _client { get; set; }
        private Uri _node { get; set; }
        private ConnectionSettings _settings { get; set; }
        private string _elasticIndex { get; set; }

        public ElasticConnection(IElasticConfig elasticConfig)
        {
            _elasticIndex = elasticConfig.IndexName;
            _node = new Uri(elasticConfig.ElastisearchUrl);
            _settings = new ConnectionSettings(_node)
                .DefaultIndex(_elasticIndex);
            _client = new ElasticClient(_settings);
        }

        public void CreateIndex()
        {
            var indexSettings = new IndexSettings { NumberOfReplicas = 1, NumberOfShards = 1 };

            var indexConfig = new IndexState
            {
                Settings = indexSettings
            };

            if (!_client.IndexExists(_elasticIndex).Exists)
            {
                var result = _client.CreateIndex(_elasticIndex, ci => ci
                    .InitializeUsing(indexConfig)
                    .Mappings(m => m.Map<T>(mp => mp.AutoMap()))
                );
            }
        }
        
        public void DeleteIndex()
        {
            if (_client.IndexExists(_elasticIndex).Exists)
            {
                var result = _client.DeleteIndex(_elasticIndex);
            }
        }

        public void AddDocumentToIndex(T document)
        {
            var result = _client.Index(document, lr => lr
                .Index(_elasticIndex)
                .Id(document.Id.ToString())
            );
        }

        public IEnumerable<T> SearchByField(string field, string query)
        {
            const int pageNumber = 0;
            const int maxResultsPerPage = 10;
        

            var searchResponse = _client.Search<T>(s => s
                    .Index(_elasticIndex)
                    .AllTypes()
                    .MatchAll()
                    .Query(q => q
                        .MatchPhrase(qe => qe
                            .Field(field)
                            .Query(query)
                        )
                    )
                    .From(pageNumber)
                    .Size(maxResultsPerPage)
                );

            var searchResults = searchResponse.Hits.Select(hit =>
            {
                var result = hit.Source;
                result.Id = Guid.Parse(hit.Id);
                return result;
            });

            return searchResults;
        }
    }
}
