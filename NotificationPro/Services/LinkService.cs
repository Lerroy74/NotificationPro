using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotificationPro.Entities;
using NotificationPro.Enum;
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

        public Result AddLinkUser(LinkUserForm linkUserForm)
        {
            var result = new Result();
            var link = new Link(linkUserForm.Url, linkUserForm.Type);
            var userFromDb = _commonContext.Users.FirstOrDefault(x => x.Id == linkUserForm.UserId);
            if (userFromDb == null)
            {
                result.Errors.Add("Пользователь не найден.");
                return result;
            }
            userFromDb.Links.Add(link);
            _commonContext.Users.Update(userFromDb);
            _commonContext.SaveChanges();
            result.Data = userFromDb;
            return result;
        }

        public Result GetLinkUser(LinkUserForm linkUserForm)
        {
            var result = new Result();
            
            var userFromDb = _commonContext.Users.Where(x => x.Id == linkUserForm.UserId).Include(x => x.Links).FirstOrDefault();
            var links = new List<LinkViewModel>();
            foreach (var link in userFromDb.Links)
            {
                links.Add(new LinkViewModel(link));
            }
            result.Data = links;
            return result;
        }

        public Result GetLink(LinkFilterForm linkFilterForm)
        {
            var result = new Result();
            var linkFromDbType = _commonContext.Links.Where(x => x.Type == linkFilterForm.Type);
            var linkFromDbId = _commonContext.Links.Where(x => x.Id == linkFilterForm.Id);
            var links = new List<LinkViewModel>();
            foreach (var link in linkFromDbType)
            {
                links.Add(new LinkViewModel(link));
            }
            foreach (var link in linkFromDbId)
            {
                links.Add(new LinkViewModel(link));
            }

            result.Data = links;
            return result;
        }
    }
}
