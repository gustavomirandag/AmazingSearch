using DataAccess.Repositories.Elastic.Entities;
using DataAccess.Services.Elastic;
using DataAccess.Services.Elastic.Config.Entities;
using DomainModel.Entities;
using DomainService;
using System;
using System.Collections.Generic;

namespace WebPageSeeder
{
    class Program
    {
        static void Main(string[] args)
        {
            var elasticConnection = new ElasticConnection<WebPage>(new WebPageElasticConfig());
            var webPageSeedService = new WebPageSeedService(new WebPageElasticRepository(elasticConnection));

            List<WebPage> webPages = new List<WebPage>
            {
                new WebPage("Banco do Brasil", "O Banco do Brasil é um dos maiores do Brasil.", "https://www.bb.com.br"),
                new WebPage("G1 Notícias - Notícias o Tempo Todo", "Notícias do o Brasil, do mundo. Brasil se recupera da crise!", "https://g1.globo.com/"),
                new WebPage("UOL Esporte Notícias", "Tudo sobre esporte.", "https://esporte.uol.com.br/")
            };

            foreach(var webPage in webPages)
                webPageSeedService.AddWebPage(webPage);

            Console.WriteLine("Elasticsearch filled with some webpages.");

            Console.ReadLine();
        }
    }
}
