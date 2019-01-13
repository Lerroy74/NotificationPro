using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationPro.Enum;

namespace NotificationPro.Entities
{
    public class Link
    {
        public DateTimeOffset CreateDate { get; set; } /*= DateTimeOffset.Now;*/
        public int Id { get; set; }
        public string Url { get; set; }
        public LinkType Type { get; set; }
        
        public Link(string url, LinkType type, DateTimeOffset createDate)
        {
            Url = url;
            Type = type;
            CreateDate = createDate;
        }
        //    public Link(DateTimeOffset сreateDate)
        //    {
        //        CreateDate = сreateDate;
        //    }
    }
}
