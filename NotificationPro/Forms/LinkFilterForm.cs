using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationPro.Enum;

namespace NotificationPro.Forms
{
    public class LinksFilterForm
    {
        public DateTimeOffset startDate { get; set; }
        public DateTimeOffset endDate { get; set; }
        public LinkType Type { get; set; }
    }
}
