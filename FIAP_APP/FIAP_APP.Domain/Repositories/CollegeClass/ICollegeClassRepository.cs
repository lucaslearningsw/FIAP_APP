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

        ResponseObject InactivateCollegeClass(Domain.Models.CollegeClass collegeClass);

        ResponseObject CreateCollegeClass(Domain.Models.CollegeClass collegeClass);

        ResponseObject EditCollegeClass(Domain.Models.CollegeClass collegeClass);

        bool HasClassWithSameName(Domain.Models.CollegeClass collegeClass);
    }
}
