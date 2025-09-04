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
        public async Task<IList<tblStudent>> GetStudent()
        {
            return await _StudentRepository.GetAllStudents();
        }

    }
}
