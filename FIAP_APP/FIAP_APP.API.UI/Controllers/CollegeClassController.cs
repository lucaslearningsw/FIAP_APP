using FIAP_APP.Domain.Models;
using FIAP_APP.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FIAP_APP.API.Controllers
{
    
    [Route("api/CollegeClass")]
    [ApiController]
    public class CollegeClassController : Controller
    {
        private readonly ICollegeClassService _collegeClassService;

        public CollegeClassController(ICollegeClassService collegeClassService)
        {
            _collegeClassService = collegeClassService;
        }

        [Route("CreateClass")]
        [HttpPost]
        public async Task<ResponseObject> CreateClass([FromBody] CollegeClass obj)
        {
            var result = new ResponseObject();
            try
            {
                result = await _collegeClassService.CreateCollegeClass(obj);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;


        }
    }
}
