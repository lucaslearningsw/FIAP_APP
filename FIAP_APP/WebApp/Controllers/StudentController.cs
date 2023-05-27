using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Dto;
using WebApp.Models.Dto.Student;
using WebApp.Provider;
using WebApp.Services.IServices;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [Route("lista-alunos")]
        public async Task<IActionResult> Index()
        {

            var listResult = await _studentService.GetAllStudentAsync();
            
            return View(listResult);
        }

        [Route("novo-aluno")]
        [HttpPost]
        public async Task<IActionResult> Create(StudentCreationDto studentDto)
        {
            
            if (!ModelState.IsValid) return View(studentDto);

            studentDto.Senha = HashGenerator.GenerateHash(studentDto.Senha);

            await _studentService.CreateStudent(studentDto);

            return RedirectToAction("Index");
        }

        [Route("novo-aluno")]
        public async Task<IActionResult> Create()
        {
            return View("Create");
        }


        [Route("editar-aluno/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.GetStudentAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [Route("editar-aluno/{id:int}")]
        [HttpPost]
        public async Task<IActionResult> Edit(StudentUpdate student)
        {
            if (!ModelState.IsValid) return View(student);

            var studentResult = await _studentService.GetStudentAsync(student.Id);

            if (studentResult == null) return NotFound();

            student.Senha = HashGenerator.GenerateHash(student.Senha);

            await _studentService.UpdateStudentAsync(student);


            return RedirectToAction("index");
        }






    }
}
