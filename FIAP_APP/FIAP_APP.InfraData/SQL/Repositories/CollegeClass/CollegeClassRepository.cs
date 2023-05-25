using FIAP_APP.Domain.Models;
using FIAP_APP.Domain.Repositories.CollegeClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP_APP.InfraData.SQL.Repositories.CollegeClass
{
    public class CollegeClassRepository : ICollegeClassRepository
    {
        public ResponseObject CreateCollegeClass(Domain.Models.CollegeClass collegeClass)
        {
            throw new NotImplementedException();
        }

        public ResponseObject EditCollegeClass(Domain.Models.CollegeClass collegeClass)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Models.CollegeClass> GetAllClass()
        {
            throw new NotImplementedException();
        }

        public bool HasClassWithSameName(Domain.Models.CollegeClass collegeClass)
        {
            throw new NotImplementedException();
        }

        public ResponseObject InactivateCollegeClass(Domain.Models.CollegeClass collegeClass)
        {
           
            throw new NotImplementedException();
        }
    }
}
