using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationPro.Forms;

namespace NotificationPro.Services
{
    interface ILinkService
    {
        Result AddLink(LinkForm linkForm);
        Result AddLinkUser(LinkUserForm linkUserForm);
        Result GenerateTestData(int count);
    }
}
