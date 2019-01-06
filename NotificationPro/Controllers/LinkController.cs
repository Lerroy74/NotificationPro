using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationPro.Forms;
using NotificationPro.Services;

namespace NotificationPro.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LinkController : ControllerBase
    {
        private readonly LinkService _linkService = new LinkService();
        [HttpPost]
        [Route("addlink")]
        public IActionResult AddLink(LinkForm _linkForm)
        {
            return Ok(_linkService.AddLink(_linkForm));
        }
    }
}