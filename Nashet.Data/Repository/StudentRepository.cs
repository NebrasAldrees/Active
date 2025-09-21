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
    public class StudentRepository : BaseRepository<tblStudent>
    {
        public StudentRepository(NashetContext dbContext) : base(dbContext)
        {
        }
        public virtual async Task<IList<tblStudent>> GetAllStudents()
        {
            return await dbSet.Where(Student => Student.IsDeleted == false).ToListAsync(); 
        }

        public virtual async Task<int> InsertStudent(tblStudent student)
        {
            try
            {
                await InsertAsync(student);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public virtual async Task<tblStudent> GetStudentByIdAsync(int id)
        {
            return await dbSet.Where(Student => Student.IsDeleted == false && Student.StudentId == id)
                            .FirstOrDefaultAsync();
        }


    }
}
