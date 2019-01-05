using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotificationPro.Entities;
using NotificationPro.Forms;
using NotificationPro.ViewModels;

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

        public Result FindUser(UserRegistrationForm userForm)
        {
            var result = new Result();
            var userFromDb = _commonContext.Users.FirstOrDefault(x => x.Email == userForm.Email);
            if (userFromDb == null)
            {
                result.Errors.Add("Пользователь не найден.");
                return result;
            }
            var userViewModel = new UserViewModel(userFromDb);
            result.Data = userViewModel;
            return result;
        }

        public Result UpdateUser(UserUpdateForm userForm)
        {
            var result = new Result();
            var userFromDb = _commonContext.Users.FirstOrDefault(x => x.Id == userForm.Id);
            if (userFromDb == null)
            {
                result.Errors.Add("Пользователь не найден.");
                return result;
            }
            userFromDb = Update(userForm, userFromDb);
            _commonContext.Users.Update(userFromDb);
            _commonContext.SaveChanges();
            result.Data = userFromDb;
            return result;
        }

        private User Update(UserUpdateForm userUpdateForm, User user)
        {

            if (!string.IsNullOrEmpty(userUpdateForm.Email))
            {
                user.Email = userUpdateForm.Email;
            }
            if (!string.IsNullOrEmpty(userUpdateForm.Password))
            {
                user.Password = userUpdateForm.Password;
            }

            return user;
        }
        
    }
}
