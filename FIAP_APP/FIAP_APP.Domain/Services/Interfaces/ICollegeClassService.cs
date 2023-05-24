using FIAP_APP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP_APP.Domain.Services.Interfaces
{
    public interface ICollegeClassService
    {
        Task<List<CollegeClass>> GetAllClass();

        Task<ResponseObject> InactivateCollegeClass(CollegeClass collegeClass);

        Task<ResponseObject> CreateCollegeClass(CollegeClass collegeClass);

        Task<ResponseObject> EditCollegeClass(CollegeClass collegeClass);   
    }
}
