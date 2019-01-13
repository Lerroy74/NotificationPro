using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationPro.Enum;

namespace NotificationPro.Forms
{
    public class LinkForm
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public LinkType Type { get; set; }
        public DateTimeOffset CreateDate { get; set; } 
    }
}
