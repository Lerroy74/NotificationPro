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
        public IActionResult AddLinkUser(LinkUserForm linkUserForm)
        {
            return Ok(_linkService.AddLinkUser(linkUserForm));
        }

        [HttpPost]
        [Route("getLinkUser")]
        public IActionResult GetLinkUser(LinkUserForm linkUserForm)
        {
            return Ok(_linkService.GetLinkUser(linkUserForm));
        }

        [HttpPost]
        [Route("getlinks")]
        public IActionResult GetLinksByFilter(LinksFilterForm linkFilterForm)
        {
            return Ok(_linkService.GetLinksByFilter(linkFilterForm));
        }

        [HttpPost]
        [Route("generatetestdata")]
        public IActionResult GenerateTestData(int count)
        {
            return Ok(_linkService.GenerateTestData(count));
        }
    }
}