using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationPro
{
    public class Result
    {
        public object Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
