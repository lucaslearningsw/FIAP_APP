using AutoMapper;
using FIAP_APP.API.Dto.Student;
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
        private readonly IMapper _mapper;

        public StudentController(StudentService studentService , IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
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
        public async Task<IActionResult> CreateStudent([FromBody] StudentCreationDto obj)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                return Ok(await _studentService.CreateStudent(_mapper.Map<Student>(obj)));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = ex.Message});
            }

          
        }

        [Route("EditarEstudante")]
        [HttpPost]
        public async Task<IActionResult> EditStudent([FromBody] StudentUpdate obj)
        {

            if (!ModelState.IsValid) return BadRequest();

            if (await _studentService.GetStudent(obj.Id) == null) return NotFound();
           
            try
            {
               await _studentService.EditStudent(_mapper.Map<Student>(obj));

               return Ok();
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

            if (!ModelState.IsValid) return BadRequest();
            try
            {
                return Ok( _studentService.EditStudent(obj));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = ex.Message });
            }
        }






    }
}
