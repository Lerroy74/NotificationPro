using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationPro.Entities
{
    public class Link
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public bool Ispublic { get; set; }

        public Link(string url, string type)
        {
            Url = url;
            Type = type;
        }
    }
}
