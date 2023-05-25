using FIAP_APP.Domain.Models;
using FIAP_APP.Domain.Repositories.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP_APP.Domain.Services
{
    public class StudentService 
    {
        private readonly IStudentRepository _studentRepo;

        public StudentService(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }
        public ResponseObject CreateStudent(Student student)
        {
           var result = _studentRepo.CreateStudent(student);

            return result;
        }

        public ResponseObject EditStudent(Student student)
        {
            var result = _studentRepo.EditStudent(student);

            return result;
        }

        public List<Student> GetAllStudents()
        {
            var result = _studentRepo.GetAllStudents();

            return result;
        }

        public ResponseObject InactivateStudent(Student student)
        {
            var result = _studentRepo.InactivateStudent(student);

            return result;
        }
    }
}
