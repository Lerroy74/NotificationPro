using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
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
            DateTimeOffset createDate = DateTimeOffset.Now;
            var link = new Link(linkForm.Url, linkForm.Type, createDate);
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
            var link = new Link(linkUserForm.Url, linkUserForm.Type, linkUserForm.CreateDate);
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

        public Result GetLinksByFilter(LinksFilterForm linkFilterForm)
        {
            var result = new Result();
            var linkFromDbType = _commonContext.Links.Where(x => (x.Type == linkFilterForm.Type) & (x.CreateDate == linkFilterForm.startDate));
            var links = new List<LinkViewModel>();
            foreach (var link in linkFromDbType)
            {
                links.Add(new LinkViewModel(link));
            }
            result.Data = links;
            return result;
        }

        public Result GenerateTestData(int count)
        {
            Random randomData = new Random();
            int range = 5 * 365; //5 years          
            Random rand = new Random();
            var result = new Result();
            int countLinkType = 0;
            LinkForm link = new LinkForm();
            if (count >= 100)
            {
                count = 100;
            }
            do
            {
                DateTime randomDate = DateTime.Today.AddDays(-randomData.Next(range));
                countLinkType = rand.Next(maxValue: 5);
                switch (countLinkType)
                {
                    case 0:
                        link.CreateDate = randomDate;
                        link.Url = "Тестовая ссылка с типом: " + LinkType.Неизвестно;
                        link.Type = LinkType.Неизвестно;
                        break;
                    case 1:
                        link.CreateDate = randomDate;
                        link.Url = "Тестовая ссылка с типом: " + LinkType.Обучение;
                        link.Type = LinkType.Обучение;
                        break;
                    case 2:
                        link.CreateDate = randomDate;
                        link.Url = "Тестовая ссылка с типом: " + LinkType.Развлечение;
                        link.Type = LinkType.Развлечение;
                        break;
                    case 3:
                        link.CreateDate = randomDate;
                        link.Url = "Тестовая ссылка с типом: " + LinkType.Личное;
                        link.Type = LinkType.Личное;
                        break;
                    case 4:
                        link.CreateDate = randomDate;
                        link.Url = "Тестовая ссылка с типом: " + LinkType.Чтение;
                        link.Type = LinkType.Чтение;
                        break;
                }
                AddLink(link);
            }
            while (count-- > 1);
            result.Data = "Готово";
            return result;
        }

    }
}
