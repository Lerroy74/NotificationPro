using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationPro.Forms;
using NotificationPro.Services;

namespace NotificationPro.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService = new UserService();

        [HttpPost]
        [Route("registration")]
        public IActionResult Registration(UserRegistrationForm _userRegistrationForm)
        {
            return Ok(_userService.Registration(_userRegistrationForm));
        }
    }
}