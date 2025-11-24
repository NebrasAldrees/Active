using Microsoft.EntityFrameworkCore;
using Nashet.Data.Models;
using Nashet.Data.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Repository
{
    public class MembershipRepository : BaseRepository<tblMembership>
    {
        public MembershipRepository(NashetContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<IList<tblMembership>> GetAllMembers()
        {
            return await dbSet.Where(member => member.IsDeleted == false).Include(s => s.Student).ToListAsync(); 
        }
        public virtual async Task<tblMembership> GetMemberByIdAsync(int id)
        {
            return await dbSet.Include(s => s.Student).Where(member => member.IsDeleted == false && member.MembershipId == id)
                            .FirstOrDefaultAsync();
        }
        public virtual async Task<tblMembership> GetMemberByGuid(Guid guid)
        {
            return await dbSet.Include(s => s.Student).AsNoTracking().FirstOrDefaultAsync(member => member.IsDeleted == false && member.Guid == guid);
            
        }

        public virtual async Task<IList<tblMembership>> GetMembersByClubGuid(Guid Guid)
        {
            return await dbSet.Include(s => s.Student).Where(member => member.IsDeleted == false && member.Team.Club.Guid == Guid)
                            .ToListAsync();
        }

        public virtual async Task<int> InsertMember(tblMembership Member)
        {
            try
            {
                await InsertAsync(Member);
                return 1;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error inserting system:{ex.Message}");
                return 0;
            }
        }
        public virtual async Task<int> updateMember(tblMembership Member)
        {
            try
            {
                await UpdateAsync(Member);
                return 1;
            }
            catch 
            {
                return 0;
            }
        }
        public virtual async Task<int> DeleteMember(tblMembership Member)
        {
            try
            {
                await UpdateAsync(Member);
                return 1;
            }
            catch 
            {
                return 0;
            }
        }

        public virtual async Task<tblMembership> GetStudentMembershipAsync(string academicId)
        {
            try
            {
                var membership = await dbSet
                    .Include(m => m.Student)
                    .Include(m => m.ClubRole)
                    .Include(m => m.Team)
                    .ThenInclude(t => t.Club)
                    .Where(m => m.Student.AcademicId == academicId &&
                               m.Student.IsDeleted == false &&
                               m.IsDeleted == false)
                    .FirstOrDefaultAsync();

                return membership;
            }
            catch
            {
                return null;
            }
        }

    }
}
