using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationPro.Enum;

namespace NotificationPro.Forms
{
    public class LinkFilterForm
    {
        public int Id { get; set; }
        public DateTimeOffset startDate { get; set; }
        public DateTimeOffset endDate { get; set; }
        public EnumTypes Type { get; set; }
    }
}
