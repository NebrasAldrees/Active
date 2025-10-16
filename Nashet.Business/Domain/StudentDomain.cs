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

        public async Task<tblStudent> GetByAcademicId(String academicId)
        {
            return await _StudentRepository.GetByAcademicIdAsync(academicId); 
        }

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
            
            }).ToList();
        }

        public async Task<int> InsertStudent(StudentViewModel viewModel)
        {
            try
            {
                tblStudent Student = new tblStudent
                {
                    StudentNameAr = viewModel.StudentNameAr,
                    StudentNameEn = viewModel.StudentNameEn,
                    AcademicId = viewModel.AcademicId,
                    StudentEmail = viewModel.StudentEmail,
                    StudentPhone = viewModel.StudentPhone,
                    StudentSkills = viewModel.StudentSkills,
                    SiteId = viewModel.SiteId,


                };
                int check = await _StudentRepository.InsertStudent(Student);
                if (check == 0)
                {
                    return 0;
                }
                else
                {
                    var systemLog = new tblSystemLogs
                    {
                        UserId = 23456,
                        username = "najd",
                        RecordId = 17,
                        Table = "tblSite",
                        operation_date = DateTime.Now,
                        operation_type = "Insert",
                        OldValue = null,
                        // NewValue=
                    };
                    //await _SystemLogsRepository.InsertLog(systemLog);
                    return 1;
                }
               
            }
            catch
            {
                return 0;
            }
        }

        public virtual async Task<int> UpdateStudent(int id, StudentViewModel viewModel)
        {
            try
            {
                var student = await _StudentRepository.GetStudentByIdAsync(id);
                if (student == null)
                {
                    return 0; 
                }

                student.StudentId = viewModel.StudentId;
                student.StudentNameAr = viewModel.StudentNameAr;
                student.StudentNameEn = viewModel.StudentNameEn;

                int check = await _StudentRepository.updateStudent(student);
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
        public virtual async Task<int> DeleteStudent(int id)
        {
            try
            {
                var student = await _StudentRepository.GetStudentByIdAsync(id);
                if (student == null)
                {
                    return 0; 
                }

                int check = await _StudentRepository.DeleteStudent(student);
                if (check == null)
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



