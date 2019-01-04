using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotificationPro.Entities;
using NotificationPro.Forms;

namespace NotificationPro.Services
{
    public class UserService : IUserService
    {
        private readonly CommonContext _commonContext = new CommonContext();
        public Result Registration(UserRegistrationForm userForm)
        {
            var result = new Result();
            var user = new User(userForm.Email, userForm.Password);
            var userFromDb = _commonContext.Users.FirstOrDefault(x => x.Email == userForm.Email);
            if (userFromDb != null)
            {
                result.Errors.Add("Есть такой");
                return result;
            }
            _commonContext.Users.Add(user);
            _commonContext.SaveChanges();
            result.Data = "збс";
            return result;
        }

        
    }
}
