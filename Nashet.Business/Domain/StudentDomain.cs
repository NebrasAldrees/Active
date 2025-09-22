using Nashet.Business.Domain.Common;
using Nashet.Business.ViewModels;
using Nashet.Data.Models;
using Nashet.Data.Repository;
using Nashet.Data.Repository.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.Domain
{
    public class StudentDomain(StudentRepository Repository) : BaseDomain
    {
        private readonly StudentRepository _StudentRepository = Repository;



        public async Task<IList<StudentViewModel>> GetStudent()
        {
            return _StudentRepository.GetAllStudents().Result.Select(S => new StudentViewModel
            {
                StudentId = S.StudentId,
                AcademicId = S.AcademicId,
                StudentNameAr = S.StudentNameAr,
                StudentNameEn = S.StudentNameEn,
                StudentEmail = S.StudentEmail,
                StudentPhone = S.StudentPhone,
                StudentSkills = S.StudentSkills,
                SiteId = S.SiteId,
                Site = S.Site

            }).ToList();
        }

        public async Task<int> InsertStudent(StudentViewModel viewModel)
        {
            try
            {
                tblStudent Student = new tblStudent
                {
                    StudentId = viewModel.StudentId,
                    AcademicId = viewModel.AcademicId,
                    StudentNameAr = viewModel.StudentNameAr,
                    StudentNameEn = viewModel.StudentNameEn,
                    StudentEmail = viewModel.StudentEmail,
                    StudentPhone = viewModel.StudentPhone,
                    StudentSkills = viewModel.StudentSkills,
                    SiteId = viewModel.SiteId,
                    Site = viewModel.Site
                };
                int check = await _StudentRepository.InsertStudent(Student);
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
    }
}



