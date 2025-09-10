using Nashet.Business.Domain.Common;
using Nashet.Data.Models;
using Nashet.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.Domain
{
    public class EmailNotificationDomain : BaseDomain
    {
        private readonly EmailNotificationRepository _EmailNotificationRepository;
        public EmailNotificationDomain(EmailNotificationRepository Repository)
        {
            _EmailNotificationRepository = Repository;
        }
        //public async Task<IList<tblEmailNotificationLog>> GetEmailNotification()
        //{
        //    return await _EmailNotificationRepository.GetAllEmailNotifications();
        //}
        public virtual async Task<int> InsertMember(tblEmailNotificationLog email)
        {
            try
            {
                await _EmailNotificationRepository.InsertEmailNotification(email);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
