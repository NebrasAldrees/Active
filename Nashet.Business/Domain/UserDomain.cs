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
    public class UserDomain : BaseDomain
    {
        private readonly UserRepository _UserRepository;
        private readonly SiteRepository _SiteRepository;

        public UserDomain(UserRepository Repository, SiteRepository siteRepository)
        {
            _SiteRepository = siteRepository;
            _UserRepository = Repository;
        }
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
                SystemRoleId = U.SystemRoleId,
                SiteId = U.SiteId,
                ClubId = U.ClubId
            }).ToList();
        }

        public async Task<int> InsertUser(UserViewModel viewModel)
        {
            try
            {
                var site = await _SiteRepository.GetSiteByGUID(viewModel.SiteGuid);

                tblUser User = new tblUser
                {
                    Username = viewModel.Username,
                    UserNameAR = viewModel.UserNameAR,
                    UserNameEN = viewModel.UserNameEN,
                    UserEmail = viewModel.UserEmail,
                    UserPhone = viewModel.UserPhone,
                    SystemRoleId = viewModel.SystemRoleId,
                    SiteId = site.SiteId
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
                    //await _SystemLogsRepository.InsertLog(systemLog);
                    return 1;
                }
               
            }
            catch
            {
                return 0;
            }
        }

        
        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var user = await _UserRepository.GetUserByIdAsync(id);
                if (user == null)
                    return false;

                user.IsDeleted = true;
                await _UserRepository.UpdateAsync(user);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<UserViewModel> GetUserByUsername(string username)
        {
            var user = await _UserRepository.GetUserByUsername(username);
            if (user != null)
            {

                UserViewModel viewModel = new UserViewModel
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    UserNameAR = user.UserNameAR,
                    UserNameEN = user.UserNameEN,
                    UserEmail = user.UserEmail,
                    UserPhone = user.UserPhone,
                    SystemRoleId = user.SystemRoleId,
                    SiteId = user.SiteId,
                    RoleTypeEn = user.SystemRole.RoleTypeEn,
                    ClubId = user.ClubId,
                };
                return viewModel;
            }
            return null;
        }
    }
}
