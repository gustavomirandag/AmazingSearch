using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Interfaces.Repository.Entities
{
    public interface IWebPageRepository : IRepository<WebPage>
    {
        IEnumerable<WebPage> SearchByTitle(string title);
        IEnumerable<WebPage> SearchByContent(string content);
    }
}
