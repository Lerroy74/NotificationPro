using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace NotificationPro.Forms
{
    public class LinkFormUser : LinkForm
    {
        public int userId { get; set; }
    }
}
