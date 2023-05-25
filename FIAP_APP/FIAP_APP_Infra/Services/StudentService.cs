using FIAP_APP.Domain.Models;
using FIAP_APP.Domain.Repositories.Student;
using FIAP_APP.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP_APP.Infra.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepo;

        public StudentService(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }
        public Task<ResponseObject> CreateStudent(Student student)
        {
           var result = _studentRepo.CreateStudent(student);

            return result;
        }

        public Task<ResponseObject> EditStudent(Student student)
        {
            var result = _studentRepo.EditStudent(student);

            return result;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            var result = await _studentRepo.GetAllStudents();

            return result;
        }

        public async Task<ResponseObject> InactivateStudent(Student student)
        {
            var result = await _studentRepo.InactivateStudent(student);

            return result;
        }
    }
}
