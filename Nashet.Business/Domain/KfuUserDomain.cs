using Nashet.Business.Domain.Common;
using Nashet.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nashet.Data.Models;
using Nashet.Business.ViewModels;

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
        public async Task<int> InsertKfuUser(KfuUserViewModel viewModel)
        {
            try
            {
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
        public int DeleteKFUuser(int id)
        {
            try
            {
                _KFUuserRepository.Delete(id); 
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
