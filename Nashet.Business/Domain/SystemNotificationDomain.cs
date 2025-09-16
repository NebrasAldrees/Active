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
    public class SystemNotificationDomain : BaseDomain
    {
        private readonly SystemNotificationRepository _SystemNotificationRepository;
        public SystemNotificationDomain(SystemNotificationRepository Repository)
        {
            _SystemNotificationRepository = Repository;
        }
        public async Task<IList<tblSystemNotification>> GetNotification()
        {
            return await _SystemNotificationRepository.GetAllNotifications();
        }
        public async Task<tblSystemNotification> GetNotificationByIdAsync(int id)
        {
            var systemNotification = await _SystemNotificationRepository.GetNotificationByIdAsync(id);

            if (systemNotification == null)
            {
                throw new KeyNotFoundException($"Notification request with ID {id} was not found.");
            }

            return systemNotification;
        }
        public virtual async Task<int> InsertNotification(tblSystemNotification Notification)
        {
            try
            {
                await _SystemNotificationRepository.InsertNotification(Notification);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int DeleteSystemNotification(int id)
        {
            try
            {
                _SystemNotificationRepository.Delete(id);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
