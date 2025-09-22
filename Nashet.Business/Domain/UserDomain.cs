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

            public async Task<IList<tblUser>> GetUser()
            {
                return await _UserRepository.GetAllUsers();
            }

        public async Task<IList<UserViewModel>> GetGetUser()
        {
            return _UserRepository.GetAllUsers().Result.Select(U => new UserViewModel
            {
                guid = U.Guid,
                UserId = U.UserId,
                UserNameAR = U.UserNameAR,
                UserNameEN = U.UserNameEN,
                UserEmail = U.UserEmail,
                UserPhone = U.UserPhone,
                SiteId = U.SiteId,
               
            }).ToList();
        }
      
        public async Task<int> InsertUser(UserViewModel viewModel)
        {
            try
            {
                tblUser User = new tblUser
                {
                    UserId = viewModel.UserId,
                    UserNameAR = viewModel.UserNameAR,
                    UserNameEN = viewModel.UserNameEN,
                    UserEmail = viewModel.UserEmail,
                    UserPhone = viewModel.UserPhone,
                    SiteId = viewModel.SiteId,

                };
                int check = await _UserRepository.InsertUser(User);
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

        public async Task<int> InsertUser(tblUser user)
        {
            throw new NotImplementedException();
        }
    }

}
