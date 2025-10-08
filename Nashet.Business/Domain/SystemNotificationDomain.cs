using Nashet.Business.Domain.Common;
using Nashet.Business.ViewModels;
using Nashet.Data.Models;
using Nashet.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.Domain
{
    public class SystemNotificationDomain(SystemNotificationRepository Repository) : BaseDomain
    {
            private readonly SystemNotificationRepository _SystemNotificationRepository = Repository;
            public async Task<IList<SystemNotificationViewModel>> GetAllNotifications()
            {
            var notifications = await _SystemNotificationRepository.GetAllNotifications();

            return notifications?.Select(n => new SystemNotificationViewModel
            {
                SystemNotificationId = n.SystemNotificationId,
                date = n.date,
                Time = n.Time
            }).ToList() ?? new List<SystemNotificationViewModel>();
        }

        //public async Task<tblSystemNotification> GetNotificationByIdAsync(int id)
        //{
        //    var Notification = await _SystemNotificationRepository.GetNotificationByIdAsync(id);

        //    if ( Notification== null)
        //    {
        //        throw new KeyNotFoundException($" Systemnotification with ID {id} was not found.");
        //    }

        //    return Notification;
        //}
        public async Task<int> InsertNotification(SystemNotificationViewModel viewModel)
            {
                try
                {
                tblSystemNotification  notification = new tblSystemNotification
                {
                         date = viewModel.date,
                         Time = viewModel.Time

                };
                    int check = await _SystemNotificationRepository.InsertNotification(notification);
                if (check == 0)
                {
                    return 0;
                }
                else
                {
                    var systemLog = new tblSystemLogs
                    {
                        UserId = 23456,
                        username = "najd",
                        RecordId = 17,
                        Table = "tblSystemNotification",
                        operation_date = DateTime.Now,
                        operation_type = "Insert",
                        OldValue = null,
                        // NewValue=
                    };
                    await _SystemLogsRepository.InsertLog(systemLog);
                    return 1;
                }
                
                }
                catch
                {
                    return 0;
                }
            }
        //public int Delete Notification(int id)
        //{
        //    try
        //    {
        //        _SystemNotificationRepository.Delete(id);
        //        return 1;
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}
    }
}

