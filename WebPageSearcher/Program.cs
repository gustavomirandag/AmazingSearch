using DataAccess.Repositories.Elastic.Entities;
using DataAccess.Repositories.Elastic.Log;
using DataAccess.Services.Elastic;
using DataAccess.Services.Elastic.Config.Entities;
using DataAccess.Services.Elastic.Config.Log;
using DomainModel.Entities;
using DomainModel.Log;
using DomainService;
using System;

namespace WebPageSearcher
{
    class Program
    {
        static void Main(string[] args)
        {
            //WebPageSearch Service
            var webPageElasticConnection = new ElasticConnection<WebPage>(new WebPageElasticConfig());
            var webPageSearchService = new WebPageSearchService(new WebPageElasticRepository(webPageElasticConnection));

            //ActivityLogService
            var logElasticConnection = new ElasticConnection<UserActivityLog>(new UserActivityLogElasticConfig());
            var activityLogService = new ActivityLogService<UserActivityLog>
                (new ActivityLogElasticRepository<UserActivityLog>(logElasticConnection));

            Console.WriteLine("Type you next search (\"exit\" to quit): ");
            string query = Console.ReadLine();
            while (query != "exit")
            {
                activityLogService.RegisterActivity(new UserActivityLog(query));

                var searchResultsByTitle = webPageSearchService.SearchByTitle(query);
                Console.WriteLine();
                Console.WriteLine("Search results by title:");
                foreach (var result in searchResultsByTitle)
                {
                    Console.WriteLine(result.Title);
                    Console.WriteLine(result.Content);
                }
                Console.WriteLine();
                Console.WriteLine("Search results by content:");
                var searchResultsByContent = webPageSearchService.SearchByContent(query);
                foreach (var result in searchResultsByContent)
                {
                    Console.WriteLine(result.Title);
                    Console.WriteLine(result.Content);
                }


                Console.WriteLine("Type your next search: ");
                query = Console.ReadLine();
            }
        }
    }
}
