using FIAP_APP.Domain.Models;
using FIAP_APP.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace FIAP_APP.API.Controllers
{
    
    [Route("api/CollegeClass")]
    [ApiController]
    public class CollegeClassController : Controller
    {
        private readonly CollegeClassService _collegeClassService;

        public CollegeClassController(CollegeClassService collegeClassService)
        {
            _collegeClassService = collegeClassService;
        }


        [Route("ListaTurma")]
        [HttpGet]
        public async Task<List<CollegeClass>> GetAllCollegeClass()
        {
            try
            {
                return  _collegeClassService.GetAllClass();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [Route("CriarTurma")]
        [HttpPost]
        public ActionResult<ResponseObject> CreateClass([FromBody] CollegeClass obj)
        {
            if (obj == null)
            {
                return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = "invali json" });
            }
            try
            {
                return Ok(_collegeClassService.CreateCollegeClass(obj));
            }
            catch (Exception ex)
            {
              return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = ex.Message });
            }

           
        }

        [Route("EditarTurma")]
        [HttpPost]
        public ActionResult<ResponseObject> EditTurma([FromBody] CollegeClass obj)
        {

            if (obj == null)
            {
                return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = "invali json" });
            }

            try
            {
                return Ok(_collegeClassService.EditCollegeClass(obj));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = ex.Message });

            }
        }


        [Route("InativarTurma")]
        [HttpPost]
        public  ActionResult<ResponseObject> InactivateClass([FromBody] CollegeClass obj)
        {

            if (obj == null)
            {
                return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = "invali json" });
            }

            try
            {
                return Ok(_collegeClassService.InactivateCollegeClass(obj));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = ex.Message });

            }
        }
    }
}
