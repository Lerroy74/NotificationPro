using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationPro.Entities;
using NotificationPro.Forms;

namespace NotificationPro.Services
{
    public class LinkService : ILinkService
    {
        private readonly CommonContext _commonContext = new CommonContext();

        public Result AddLink(LinkForm linkForm)
        {
            var result = new Result();
            var link = new Link(linkForm.Url, linkForm.Type);
            if (link.Url == null)
            {
                result.Errors.Add("Ссылка не может быть пустой");
            }

            result.Data = link;
            _commonContext.Links.Add(link);
            _commonContext.SaveChanges();
            return result;
            
        }
    }
}
