using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace NotificationPro.Forms
{
    public class LinkUserForm : LinkForm
    {
        public int UserId { get; set; }
    }
}
