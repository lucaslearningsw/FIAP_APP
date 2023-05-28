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
            try
            {
                var listResult = await _studentService.GetAllStudentAsync();

                return View(listResult);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"{ex.Message}";
                return View("Index");
            }

        }

        [Route("novo-aluno")]
        [HttpPost]
        public async Task<IActionResult> Create(StudentCreationDto studentDto)
        {
            
            if (!ModelState.IsValid) return View(studentDto);

            studentDto.Senha = HashGenerator.GenerateHash(studentDto.Senha);

            try
            {
                await _studentService.CreateStudent(studentDto);
            }
            catch (Exception ex)
            {

                TempData["Error"] = $"{ex.Message}";
                return View("Create");
            }

            TempData["Sucesso"] = "Aluno criado com sucesso";
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
            try
            {
                var student = await _studentService.GetStudentAsync(id);
                if (student == null)
                {
                    return NotFound();
                }
                return View(student);
            }
            catch (Exception ex)
            {

                TempData["Error"] = $"{ex.Message}";
                return View("Edit");
            }
        }

        [Route("editar-aluno/{id:int}")]
        [HttpPost]
        public async Task<IActionResult> Edit(StudentDto student)
        {
            if (!ModelState.IsValid) return View(student);

            try
            {
                var studentResult = await _studentService.GetStudentAsync(student.Id);

                if (studentResult == null) return NotFound();

                student.Senha = HashGenerator.GenerateHash(student.Senha);

                 await _studentService.UpdateStudentAsync(student);

                TempData["Sucesso"] = "Aluno editado com sucesso";
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"{ex.Message}";
                return View("Edit");
            }
        }


        [Route("deletar-aluno/{id:int}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(StudentDto studentDto)
        {

            var student = await _studentService.GetStudentAsync(studentDto.Id);

            if (student == null) return NotFound();

            try
            {
                await _studentService.DeleteStudentAsync(studentDto.Id);
                TempData["Sucesso"] = "Aluno Inativado com sucesso";
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {

                TempData["Error"] = $"{ex.Message}";
                return View(studentDto);
            }

           
        }


        [Route("deletar-aluno/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetStudentAsync(id);

            if (student == null) return NotFound();

            return View(student);

        }






    }
}
