using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationPro.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<Link> Links { get; set; }

        public User()
        {

        }

        public User(string email, string password)
        {
            Password = password;
            Email = email;

        }

    }

    
}
