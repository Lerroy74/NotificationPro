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

        public Result AddLinkUser(LinkFormUser linkFormUser)
        {
            var result = new Result();
            var link = new LinkFormUser();
            var userFromDb = _commonContext.Users.FirstOrDefault(x => x.Id == linkFormUser.Id);
            if (userFromDb == null)
            {
                result.Errors.Add("Пользователь не найден.");
                return result;
            }

            _commonContext.Users.Update(userFromDb);
            _commonContext.SaveChanges();
            result.Data = userFromDb;
            return result;


            //link = linkFormUser;
            //_commonContext.Links.Add()


            //return result;
        }
    }
}
