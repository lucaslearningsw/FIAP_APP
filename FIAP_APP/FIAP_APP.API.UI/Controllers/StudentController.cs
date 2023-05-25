using FIAP_APP.Domain.Models;
using FIAP_APP.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FIAP_APP.API.Controllers
{
    [Route("api/Student")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Route("GetAllStudents")]
        [HttpGet]
        public async Task<List<Student>> GetAllStudents()
        {
           return await  _studentService.GetAllStudents();
        }
    }
}
