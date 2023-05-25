using FIAP_APP.Domain.Models;
using FIAP_APP.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace FIAP_APP.API.Controllers
{
    [Route("api/Student")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [Route("ListaEstudantes")]
        [HttpGet]
        public  ActionResult<List<Student>> GetAllStudents()
        {
            try
            {
                return _studentService.GetAllStudents();
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = ex.Message });
            }
           
        }

        [Route("CriarEstudante")]
        [HttpPost]
        public ActionResult<ResponseObject> CreateStudent([FromBody] Student obj)
        {

            if (obj == null)
            {
                return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = "invali json" });
            }

            try
            {
                return Ok(_studentService.CreateStudent(obj));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = ex.Message});
            }

          
        }

        [Route("EditarEstudante")]
        [HttpPost]
        public  ActionResult<ResponseObject> EditStudent([FromBody] Student obj)
        {

            if (obj == null)
            {
                return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = "invali json" });
            }

            try
            {
                return Ok(_studentService.EditStudent(obj));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = ex.Message });
            }
        }

        [Route("InativarEstudante")]
        [HttpPost]
        public ActionResult<ResponseObject> InactivateStudent([FromBody] Student obj)
        {

            if (obj == null)
            {
                return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = "invali json" });
            }
            try
            {
                return Ok(_studentService.EditStudent(obj));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = ex.Message });
            }
        }






    }
}
