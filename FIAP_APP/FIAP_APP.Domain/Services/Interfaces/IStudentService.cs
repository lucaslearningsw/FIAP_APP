using FIAP_APP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP_APP.Domain.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();

     
        Task<ResponseObject> CreateStudent(Student student);

        Task<ResponseObject> EditStudent(Student student);

        Task<ResponseObject> InactivateStudent(Student student);
    }
}
