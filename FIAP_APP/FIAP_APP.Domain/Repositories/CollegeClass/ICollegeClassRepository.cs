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
        Task<List<Domain.Models.CollegeClass>> GetAllClass();

        Task<ResponseObject> InactivateCollegeClass(Domain.Models.CollegeClass collegeClass);

        Task<ResponseObject> CreateCollegeClass(Domain.Models.CollegeClass collegeClass);

        Task<ResponseObject> EditCollegeClass(Domain.Models.CollegeClass collegeClass);
    }
}
