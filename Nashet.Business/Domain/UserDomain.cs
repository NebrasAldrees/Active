using Nashet.Business.Domain.Common;
using Nashet.Business.ViewModels;
using Nashet.Data.Models;
using Nashet.Data.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.Domain
{
    public class UserDomain(UserRepository Repository) : BaseDomain
    {
        private readonly UserRepository _UserRepository = Repository;
        public async Task<IList<UserViewModel>> GetUser()
        {
            return _UserRepository.GetAllUsers().Result.Select(U => new UserViewModel
            {
                guid = U.Guid,
                UserId = U.UserId,
                Username = U.Username,
                UserNameAR = U.UserNameAR,
                UserNameEN = U.UserNameEN,
                UserEmail = U.UserEmail,
                UserPhone = U.UserPhone,
                //SystemRoles = U.SystemRoles,
                SystemRoleId = U.SystemRoleId,
                SiteId = (int)U.SiteId,
            }).ToList();
        }

        public async Task<int> InsertUser(UserViewModel viewModel)
        {
            try
            {
                tblUser User = new tblUser
                {
                    Username = viewModel.Username,
                    UserNameAR = viewModel.UserNameAR,
                    UserNameEN = viewModel.UserNameEN,
                    UserEmail = viewModel.UserEmail,
                    UserPhone = viewModel.UserPhone,
                    SystemRoleId = viewModel.SystemRoleId,
                    SiteId = viewModel.SiteId,
                };
                int check = await _UserRepository.InsertUser(User);
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
                        Table = "tblUser",
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

        public int DeleteUser(int id)
        {
            try
            {
                _UserRepository.Delete(id);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<UserViewModel> GetUserByUsername(String username)
        {
            var user = await _UserRepository.GetUserByUsername(username);
            UserViewModel viewModel = new UserViewModel
            {
                UserId = user.UserId,
                Username = user.Username,
                UserNameAR = user.UserNameAR,
                UserNameEN = user.UserNameEN,
                UserEmail = user.UserEmail,
                UserPhone = user.UserPhone,
                SystemRoleId = user.SystemRoleId,
                SiteId = (int)user.SiteId,
            };
            return viewModel;
        }
    }
}
