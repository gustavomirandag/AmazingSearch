using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AmazingSearchWebApp.Models;
using DomainService;
using DataAccess.Services.Elastic;
using DomainModel.Entities;
using DataAccess.Services.Elastic.Config.Entities;
using DataAccess.Repositories.Elastic.Entities;
using DomainModel.Log;
using DataAccess.Repositories.Elastic.Log;
using DataAccess.Services.Elastic.Config.Log;

namespace AmazingSearchWebApp.Controllers
{
    //[Route("home")]
    public class HomeController : Controller
    {
        private WebPageSearchService _webPageSearchService;
        private ActivityLogService<UserActivityLog> _activityLogService;

        public HomeController()
        {
            //WebPageSearch Service
            var webPageElasticConnection = new ElasticConnection<WebPage>(new WebPageDockerElasticConfig());
            _webPageSearchService = new WebPageSearchService(new WebPageElasticRepository(webPageElasticConnection));

            //ActivityLogService
            var logElasticConnection = new ElasticConnection<UserActivityLog>(new UserActivityLogElasticConfig());
            _activityLogService = new ActivityLogService<UserActivityLog>
                (new ActivityLogElasticRepository<UserActivityLog>(logElasticConnection));
        }

        public IActionResult Index(IEnumerable<WebPage> webPages)
        {
            return View(webPages.ToList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        //[Route("{searchInput}")]
        public IActionResult Search(string searchInput)
        {
            _activityLogService.RegisterActivity(new UserActivityLog(searchInput));
            var searchResultsByTitle = _webPageSearchService.SearchByContent(searchInput);

            return View("Index", searchResultsByTitle.ToList());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
