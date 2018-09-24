using DomainModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Entities
{
    public class WebPage : EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }

        public WebPage()
        {
        }

        public WebPage(string title, string content, string url)
        {
            Title = title;
            Content = content;
            Url = url;
        }
    }
}
