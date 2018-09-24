using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Services.Elastic
{
    public interface IElasticConfig
    {
        string IndexName { get; }

        string ElastisearchUrl { get; }
    }
}
