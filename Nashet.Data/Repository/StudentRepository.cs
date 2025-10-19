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

        public async Task<tblStudent> GetByAcademicIdAsync(string academicId)
        {
            return await dbSet.FirstOrDefaultAsync(student => student.AcademicId == academicId && student.IsDeleted == false);
        }

        public async Task<tblStudent> GetStudentByGuid(Guid Guid)
        {
            return await dbSet.FirstOrDefaultAsync(student => student.Guid == Guid && student.IsDeleted == false);
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
            catch (Exception ex) 
            {
                Console.WriteLine($"Error inserting system:{ex.Message}");
                return 0;
            }
        }

        public virtual async Task<int> DeleteStudent(tblStudent student)
        {
            try
            {
                if (student == null || student.IsDeleted == true)
                {
                    Console.WriteLine($"Error deleting system:");
                }

                IsDeleted(student);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public virtual async Task<int> updateStudent(tblStudent student)
        {
            try
            {
                await UpdateAsync(student);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
