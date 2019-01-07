using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationPro.Entities;
using NotificationPro.Forms;
using NotificationPro.ViewModels;

namespace NotificationPro.Services
{
    public class LinkService : ILinkService
    {
        private readonly CommonContext _commonContext = new CommonContext();

        public Result AddLink(LinkForm linkForm)
        {
            var result = new Result();
            var link = new Link(linkForm.Url, linkForm.Type);
            if (string.IsNullOrEmpty(link.Url))
            {
                result.Errors.Add("Ссылка не может быть пустой");
                return result;
            }
            LinkViewModel linkViewModel = new LinkViewModel(link);
            result.Data = linkViewModel;
            _commonContext.Links.Add(link);
            _commonContext.SaveChanges();
            return result;
        }

        public Result AddLinkUser(LinkForm linkForm, UserUpdateForm userLink)
        {
            var result = new Result();
            var link = new Link(linkForm.Url, linkForm.Type);
            var userLinkAdd = new UserService();
            userLinkAdd.UpdateUser(userLink);
            



            return result;
        }
    }
}
