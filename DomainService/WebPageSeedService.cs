using DomainModel.Entities;
using DomainModel.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainService
{
    public class WebPageSeedService
    {
        private IRepository<WebPage> _webPageRepository;

        public WebPageSeedService(IRepository<WebPage> webPageRepository)
        {
            _webPageRepository = webPageRepository;
        }

        public void AddWebPage(WebPage webPage)
        {
            _webPageRepository.Create(webPage);
        }
    }
}
