using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationPro.Enum;

namespace NotificationPro.Entities
{
    public class Link
    {
        public DateTimeOffset CreateDate { get; set; } = DateTimeOffset.Now;
        public int Id { get; set; }
        public string Url { get; set; }
        public EnumTypes Type { get; set; }
        
        public Link(string url, EnumTypes type)
        {
            Url = url;
            Type = type;
        }
    }
}
