using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Log
{
    public class UserActivityLog : ActivityLogBase
    {
        [Keyword]
        public string Query { get; set; }
        [Text(Index = true, Fielddata = true)]
        public string FoldedSplittedQuery { get; set; }

        public UserActivityLog(string query)
            : base()
        {
            FoldedSplittedQuery = query.ToLower().Trim();
        }
    }
}
