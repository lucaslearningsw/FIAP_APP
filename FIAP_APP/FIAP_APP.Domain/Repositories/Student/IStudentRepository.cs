using FIAP_APP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP_APP.Domain.Repositories.Student
{
    public interface IStudentRepository
    {
        Task<List<Domain.Models.Student>> GetAllStudents();

        Task<ResponseObject> CreateStudent(Domain.Models.Student student);

        Task<ResponseObject> EditStudent(Domain.Models.Student student);

        Task<ResponseObject> InactivateStudent(Domain.Models.Student student);
    }
}
