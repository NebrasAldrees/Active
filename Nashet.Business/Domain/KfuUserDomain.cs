using Microsoft.EntityFrameworkCore;
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
    public class KfuUserDomain : BaseDomain
    {
        private readonly KFUuserRepository _KFUuserRepository;
        public KfuUserDomain(KFUuserRepository Repository)
        {
            _KFUuserRepository = Repository;
        }
        public async Task<IList<KfuUserViewModel>> GetGetKfuUser()
        {
            return _KFUuserRepository.GetAllKFUuser().Result.Select(x => new KfuUserViewModel
            {
                guid = x.Guid,
                KFUUserId = x.KFUUserId,
                NameAR = x.NameAR,
                NameEN = x.NameEN,
                UserEmail = x.UserEmail,
                Username = x.Username,
                UserPhone = x.UserPhone,
                UserType = x.UserType
            }).ToList();
        }
        public virtual async Task<tblKFUuser> CheckUser(String username, String password)
        {
            return await _KFUuserRepository.CheckUser(username,password);
        }
        public virtual async Task<tblKFUuser> CheckUserByEmail(string email, string password)
        {
            return await _KFUuserRepository.CheckUserByEmail(email, password);
        }
        public async Task<int> InsertKfuUser(KfuUserViewModel viewModel)
        {
            try
            {
                // تحقق من البيانات الأساسية
                if (viewModel == null || string.IsNullOrEmpty(viewModel.Username))
                    return 0;

                tblKFUuser user = new tblKFUuser
                {
                    UserType = viewModel.UserType,
                    NameAR = viewModel.NameAR,
                    NameEN = viewModel.NameEN,
                    Password = viewModel.Password,
                    UserEmail = viewModel.UserEmail,
                    Username = viewModel.Username,
                    UserPhone = viewModel.UserPhone
                };

                int check = await _KFUuserRepository.InsertKfuUser(user);
                return check;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in InsertKfuUser: {ex.Message}");
                return 0;
            }
        }
    }
}
