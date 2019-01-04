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
        public string Status { get; set; }
        public string Act { get; set; }
        public bool Ispublic { get; set; }

    }
}
