using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationPro.Entities
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<Link> Links { get; set; }

    }

    
}
