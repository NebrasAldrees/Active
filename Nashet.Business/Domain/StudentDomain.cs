using Nashet.Business.Domain.Common;
using Nashet.Data.Models;
using Nashet.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.Domain
{
    public class StudentDomain : BaseDomain
    {
        private readonly StudentRepository _StudentRepository;
        public StudentDomain(StudentRepository Repository)
        {
            _StudentRepository = Repository;
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
