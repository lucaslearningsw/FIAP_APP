using FIAP_APP.Domain.Models;
using FIAP_APP.Domain.Repositories.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public async Task<Student> CreateStudent(Student student)
        {
            var result = await _studentRepo.CreateStudent(student);
            return result;
        }

        public async Task EditStudent(Student student)
        {
            await _studentRepo.EditStudent(student);
        }

        public async Task<Student> GetStudent(int id)
        {
            var result = await _studentRepo.GetStudent(id);

            return result;
        }


        public List<Student> GetAllStudents()
        {
            var result = _studentRepo.GetAllStudents();

            return result;
        }

        public  Task InactivateStudent(Student student)
        {
            var result = _studentRepo.InactivateStudent(student);

            return result;
        }
    }
}
