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
    public class StatusDomain(StatusRepository statusRepository) : BaseDomain
    {
        private readonly StatusRepository _statusRepository = statusRepository;

        public async Task<IList<StatusViewModel>> GetStatus()
        {
            return _statusRepository.GetAllStatusType().Result.Select(status => new StatusViewModel
            {
                guid = status.Guid,
                StatusId = status.StatusId,
                StatusTypeAr = status.StatusTypeAr,
                StatusTypeEn = status.StatusTypeEn,

            }).ToList() ?? new List<StatusViewModel>();
        }

        public async Task<tblStatus> GetStatusByGuid(Guid guid)
        {
            var status = await _statusRepository.GetAllStatusTypeByGuid(guid);

            if (status == null)
            {
                throw new KeyNotFoundException($"الحالة المطلوب غير متوفر");
            }

            return status;
        }
        public async Task<tblStatus> GetStatusById(int id)
        {
            var status = await _statusRepository.GetAllStatusTypeByIdAsync(id);

            if (status == null)
            {
                throw new KeyNotFoundException($"الحالة المطلوب غير متوفر");
            }

            return status;
        }
        public async Task<int> InsertStatus(StatusViewModel viewModel)
        {
            try
            {
                tblStatus Status = new tblStatus
                {
                    StatusTypeAr = viewModel.StatusTypeAr,
                    StatusTypeEn = viewModel.StatusTypeEn,

                };
                int check = await _statusRepository.InsertStatusType(Status);
                if (check == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }


            }
            catch
            {
                return 0;
            }

        }

        public async Task<bool> DeleteStatus(Guid guid)
        {
            try
            {
                var status = await _statusRepository.GetAllStatusTypeByGuid(guid);
                if (status == null)
                    return false;

                status.IsDeleted = true;
                await _statusRepository.UpdateAsync(status);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
