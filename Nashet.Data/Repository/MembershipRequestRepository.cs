using Microsoft.EntityFrameworkCore;
using Nashet.Data.Models;
using Nashet.Data.Repository.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Repository
{
    public class MembershipRequestRepository : BaseRepository<tblMembershipRequest>
    {
        public MembershipRequestRepository(NashetContext dbContext) : base(dbContext)
        {
        }
        public virtual async Task<IList<tblMembershipRequest>> GetAllRequests()
        {
            return await dbSet.Include(s=>s.Student).ToListAsync();
        }
        public virtual async Task<tblMembershipRequest> GetRequestByGUID(Guid? guid)
        {
            return await dbSet.Include(s => s.Student).AsNoTracking().FirstOrDefaultAsync(Request => Request.Guid == guid);
        }
        public async Task<int> InsertMembershipRequest(tblMembershipRequest request)
        {
            try
            {
                await InsertAsync(request);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"خطأ في الإضافة:{ex.Message}");
                return 0;
            }
        }
        public virtual async Task<List<tblMembershipRequest>> GetStudentRequestsAsync(string academicId)
        {
            try
            {
                var requests = await dbSet
                    .Include(r => r.Student)
                    .Include(r => r.Club)
                    .Include(r => r.Team)
                    .Include(r => r.Status)
                    .Where(r => r.Student.AcademicId == academicId &&
                               r.Student.IsDeleted == false &&
                               r.IsDeleted == false)
                    .OrderByDescending(r => r.MRId)
                    .ToListAsync();

                return requests;
            }
            catch
            {
                return new List<tblMembershipRequest>();
            }
        }
        public virtual async Task<bool> IsRequestExists(int ClubID, Guid? excludeRequestGuid = null)
        {
            var query = dbSet.Where(request => request.IsDeleted == false);

            if (excludeRequestGuid.HasValue)
            {
                query = query.Where(request => request.Guid != excludeRequestGuid.Value);
            }

            return await query.AnyAsync(request => request.ClubID == ClubID);
        }

        public virtual async Task<int> AcceptRequest(tblMembershipRequest request)
        {
            try
            {
                await UpdateAsync(request);   // update request status
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public virtual async Task<int> DeleteRequest(tblMembershipRequest request)
        {
            try
            {
                await UpdateAsync(request);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

    }
}
