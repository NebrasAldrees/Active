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
    public class MembershipDomain(MembershipRepository Repository) : BaseDomain
    {
        private readonly MembershipRepository _MembershipRepository = Repository;
        public async Task<IList<MembershipViewModel>> GetMembership()
        {
            return _MembershipRepository.GetAllMembers().Result.Select(m => new MembershipViewModel
            {
                MembershipId = m.MembershipId,
                StudentId = m.StudentId,
                Student = m.Student,
                ClubRoleId = m.ClubRoleId,
                ClubRole = m.ClubRole,
                TeamId = m.TeamId,
                Team = m.Team,
                JoinDate = m.JoinDate,
                Guid = m.Guid,

            }).ToList();
        }


        public async Task<int> InsertMembership(MembershipViewModel viewModel)
        {
            try
            {
                tblMembership membership = new tblMembership
                {
                    StudentId = viewModel.StudentId,
                    //Student = viewModel.Student,
                    ClubRoleId = viewModel.ClubRoleId,
                    TeamId = viewModel.TeamId,
                    JoinDate = viewModel.JoinDate,
                };
                int check = await _MembershipRepository.InsertMember(membership);
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
        public int DeleteMembership(int id)
        {
            try
            {
                _MembershipRepository.Delete(id);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
