using Nashet.Business.Domain.Common;
using Nashet.Business.ViewModels;
using Nashet.Data.Models;
using Nashet.Data.Repository;
using Nashet.Data.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.Domain
{
    public class EmailNotificationDomain(EmailNotificationRepository Repository) : BaseDomain
    {
        private readonly EmailNotificationRepository _EmailNotificationRepository = Repository;

        public async Task<IList<EmailNotificationViewModel>> GetEmailNotification()
        {
            return _EmailNotificationRepository.GetAllEmailNotifications().Result.Select(e => new EmailNotificationViewModel
            {
                EmailNotificationsId = e.EmailNotificationsId,
                UserEmail = e.UserEmail

            }).ToList();

        }
        public async Task<int> InsertEmailNotification(EmailNotificationViewModel viewModel)
        {
            try
            {
                tblEmailNotificationLog email = new tblEmailNotificationLog
                {

                    // EmailNotificationsId = viewModel.EmailNotificationsId,
                    UserEmail = viewModel.UserEmail,

                };
                    int check = await  _EmailNotificationRepository.InsertEmailNotification(email);
                if (check == 0)
                 
                    return 0;
                else
                     return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
