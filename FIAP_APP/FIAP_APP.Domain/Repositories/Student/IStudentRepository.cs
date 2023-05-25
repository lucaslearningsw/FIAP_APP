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
        List<Domain.Models.Student> GetAllStudents();

        ResponseObject CreateStudent(Domain.Models.Student student);

        ResponseObject EditStudent(Domain.Models.Student student);

        ResponseObject InactivateStudent(Domain.Models.Student student);
    }
}
