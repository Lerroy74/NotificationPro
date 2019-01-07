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
        [Route("add")]
        public IActionResult AddLink(LinkForm linkForm)
        {
            return Ok(_linkService.AddLink(linkForm));
        }

        [HttpPost]
        [Route("addToUser")]
        public IActionResult AddLinkUser(LinkFormUser linkForm)
        {
            return Ok(_linkService.AddLinkUser(linkForm));
        }
    }
}