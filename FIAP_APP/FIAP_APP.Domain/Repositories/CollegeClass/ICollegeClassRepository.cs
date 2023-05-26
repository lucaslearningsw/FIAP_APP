using FIAP_APP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP_APP.Domain.Repositories.CollegeClass
{
    public interface ICollegeClassRepository
    {
        List<Domain.Models.CollegeClass> GetAllClass();

        Task <Domain.Models.CollegeClass> GetCollegeClass(int id);

        Task InactivateCollegeClass(Domain.Models.CollegeClass collegeClass);

        Task<Domain.Models.CollegeClass> CreateCollegeClass(Domain.Models.CollegeClass collegeClass);

        Task EditCollegeClass(Domain.Models.CollegeClass collegeClass);

        Task<Domain.Models.CollegeClass> HasClassWithSameName(string className);
    }
}
