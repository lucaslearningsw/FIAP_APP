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
        public async Task<List<Student>> GetAllStudents()
        {
            try
            {
                return await _studentService.GetAllStudents();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        [Route("CriarEstudante")]
        [HttpPost]
        public async Task<ResponseObject> CreateStudent([FromBody] Student obj)
        {
            var result = new ResponseObject();

            if (obj == null)
            {
                result.code = 405;
                result.message = "Universal format JSON invalid, verify the fields.";
                return result;
            }

            try
            {
                return await _studentService.CreateStudent(obj);
            }
            catch (Exception ex)
            {

                result = ResponseObject.CreateResponseError(500, ex.Message);
                return result;
            }

          
        }

        [Route("EditarEstudante")]
        [HttpPost]
        public async Task<ResponseObject> EditStudent([FromBody] Student obj)
        {
            var result = new ResponseObject();

            if (obj == null)
            {
                result.code = 405;
                result.message = "Universal format JSON invalid, verify the fields.";
                return result;
            }

            try
            {
                return await _studentService.EditStudent(obj);
            }
            catch (Exception ex)
            {

                result = ResponseObject.CreateResponseError(500, ex.Message);
                return result;
            }
        }

        [Route("InativarEstudante")]
        [HttpPost]
        public async Task<ResponseObject> InactivateStudent([FromBody] Student obj)
        {
            var result = new ResponseObject();

            if (obj == null)
            {
                result.code = 405;
                result.message = "Universal format JSON invalid, verify the fields.";
                return result;
            }

            try
            {
                return await _studentService.InactivateStudent(obj);
            }
            catch (Exception ex)
            {

                result = ResponseObject.CreateResponseError(500, ex.Message);
                return result;
            }
        }






    }
}
