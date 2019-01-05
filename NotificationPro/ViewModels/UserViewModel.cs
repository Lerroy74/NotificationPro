using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationPro.Entities;
using NotificationPro.Forms;

namespace NotificationPro.ViewModels
{
    public class UserViewModel
    
    {
        public UserViewModel(User user)
        {

            Id = user.Id;
            Email = user.Email;
        }

        public string Email { get; set; }
        public int Id { get; set; }
    }
}
