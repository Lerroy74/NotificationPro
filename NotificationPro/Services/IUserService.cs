using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationPro.Forms;

namespace NotificationPro.Services
{
    public interface IUserService
    {
        Result Registration(UserRegistrationForm userForm);

    }
}
