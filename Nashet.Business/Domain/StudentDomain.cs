using Microsoft.EntityFrameworkCore;
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

        public async Task<tblStudent> GetByAcademicId(string academicId)
        {
            return await _StudentRepository.GetByAcademicIdAsync(academicId);
        }
        public async Task<tblStudent> GetStudentByGuid(Guid Guid)
        {
            return await _StudentRepository.GetStudentByGuid(Guid);
        }
        public async Task<tblStudent> GetStudentById(int Id)
        {
            return await _StudentRepository.GetStudentById(Id);
        }

        public async Task<IList<StudentViewModel>> GetStudent()
        {
            return _StudentRepository.GetAllStudents().Result.Select(S => new StudentViewModel
            {
                Guid = S.Guid,
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
        public async Task<StudentViewModel> GetStudentByEmail(string email)
        {
            var student = await _StudentRepository.GetStudentByEmail(email);
            if (student == null) return null;

            return new StudentViewModel
            {
                StudentId = student.StudentId,
                AcademicId = student.AcademicId,
                StudentNameAr = student.StudentNameAr,
                StudentNameEn = student.StudentNameEn,
                StudentEmail = student.StudentEmail,
                StudentPhone = student.StudentPhone,
                SiteId = student.SiteId,
                StudentSkills = student.StudentSkills
            };
        }
        public virtual async Task<int> UpdateStudent(StudentViewModel viewModel)
        {
            try
            {
                var student = await _StudentRepository.GetStudentByGuid (viewModel.Guid);
                if (student == null)
                {
                    return 0; 
                }

                student.StudentNameAr = viewModel.StudentNameAr;
                student.StudentNameEn = viewModel.StudentNameEn;
                student.AcademicId = viewModel.AcademicId;
                student.StudentEmail = viewModel.StudentEmail;
                student.StudentPhone = viewModel.StudentPhone;
                student.StudentSkills = viewModel.StudentSkills;
                student.SiteId = viewModel.SiteId;

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
        public virtual async Task<int> DeleteStudent(Guid Guid)
        {
            try
            {
                var student = await _StudentRepository.GetStudentByGuid(Guid);
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

        public virtual async Task<bool> UpdateStudentSkillsAsync(string academicId, string studentSkills)
        {
            try
            {
                // تحقق من البيانات المدخلة
                if (string.IsNullOrEmpty(academicId) || studentSkills == null)
                    return false;

                var result = await _StudentRepository.UpdateStudentSkillsAsync(academicId, studentSkills);

                if (!result)
                {
                    // تسجيل للتصحيح
                    Console.WriteLine($"Failed to update skills for student: {academicId}");
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Domain Error: {ex.Message}");
                return false;
            }
        }
    }
}



