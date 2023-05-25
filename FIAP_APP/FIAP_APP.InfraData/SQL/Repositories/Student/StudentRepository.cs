using FIAP_APP.Domain.Models;
using FIAP_APP.Domain.Repositories.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP_APP.InfraData.SQL.Repositories.Student
{
    public class StudentRepository : IStudentRepository
    {
        public Task<ResponseObject> CreateStudent(Domain.Models.Student student)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseObject> EditStudent(Domain.Models.Student student)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Models.Student>> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseObject> InactivateStudent(Domain.Models.Student student)
        {
            throw new NotImplementedException();
        }
    }
}
