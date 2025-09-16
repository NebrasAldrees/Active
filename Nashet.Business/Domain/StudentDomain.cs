using Nashet.Business.Domain.Common;
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
    public class StudentDomain(StudentRepository Repository) : BaseDomain
    {
        private readonly StudentRepository _StudentRepository = Repository;
        
        public async Task<IList<tblStudent>> GetStudent()
        {
            return await _StudentRepository.GetAllStudents();
        }
        public async Task<tblStudent> GetStudentByIdAsync(int id)
        {
            var Student = await _StudentRepository.GetStudentByIdAsync(id);

            if (Student == null)
            {
                throw new KeyNotFoundException($"Position request with ID {id} was not found.");
            }

            return Student;
        }

    }
}
