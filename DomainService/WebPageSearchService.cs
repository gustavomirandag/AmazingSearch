using DomainModel.Entities;
using DomainModel.Interfaces.Repository.Entities;
using System;
using System.Collections.Generic;

namespace DomainService
{
    public class WebPageSearchService
    {
        private IWebPageRepository _webPageRepository;

        public WebPageSearchService(IWebPageRepository webPageRepository)
        {
            _webPageRepository = webPageRepository;
        }

        public IEnumerable<WebPage> SearchByTitle(string title)
        {
            return _webPageRepository.SearchByTitle(title);
        }

        public IEnumerable<WebPage> SearchByContent(string content)
        {
            return _webPageRepository.SearchByContent(content);
        }
    }
}
