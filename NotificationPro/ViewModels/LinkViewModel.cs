using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationPro.Entities;

namespace NotificationPro.ViewModels
{
    public class LinkViewModel
    {
        public LinkViewModel(Link link)
        {
            Url = link.Url;
            Type = link.Type;
        }
        public string Url { get; set; }
        public string Type { get; set; }
    }
}
