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
        public async Task<ResponseObject> CreateCollegeClass(Domain.Models.CollegeClass collegeClass)
        {
            try
            {
                //SELECT NO BANCO 

            }
            catch (Exception ex)
            {
                var errorResult = ResponseObject.CreateResponseError(500, ex.Message);
                return errorResult;
            }

            return ResponseObject.CreateResponseOK();
        }

        public Task<ResponseObject> EditCollegeClass(Domain.Models.CollegeClass collegeClass)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Models.CollegeClass>> GetAllClass()
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasClassWithSame(Domain.Models.CollegeClass collegeClass)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseObject> InactivateCollegeClass(Domain.Models.CollegeClass collegeClass)
        {
           
            throw new NotImplementedException();
        }
    }
}
