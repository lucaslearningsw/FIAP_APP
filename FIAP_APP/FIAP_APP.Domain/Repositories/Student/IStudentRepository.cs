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

        Task<Domain.Models.Student> CreateStudent(Domain.Models.Student student);

        Task EditStudent(Domain.Models.Student student);

        Task<Domain.Models.Student> InactivateStudent(Domain.Models.Student student);

        Task<Domain.Models.Student> GetStudent(int id);

    }
}
