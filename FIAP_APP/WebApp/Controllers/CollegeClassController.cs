using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Dto;
using WebApp.Models.Dto.CollegeClass;
using WebApp.Models.Dto.Student;
using WebApp.Provider;
using WebApp.Services.IServices;

namespace WebApp.Controllers
{
    public class CollegeClassController : Controller
    {
        private readonly ICollegeClassService _collegeClass;
        public CollegeClassController(ICollegeClassService collegeClass)
        {
            _collegeClass = collegeClass;
        }

        [Route("lista-turmas")]
        public async Task<IActionResult> Index()
        {

            var listResult = await _collegeClass.GetAllCollegeAsync();
            
            return View(listResult);
        }

        [Route("nova-turma")]
        [HttpPost]
        public async Task<IActionResult> Create(CollegeClassCreationDto studentDto)
        {
            
            if (!ModelState.IsValid) return View(studentDto);
            try
            {
                await _collegeClass.CreateCollegeClassAsync(studentDto);
            }
            catch (Exception ex)
            {

                TempData["Error"] = $"{ex.Message}";
                return View("Create");
            }

            TempData["Sucesso"] = "Turma criada com sucesso";
            return RedirectToAction("Index");
        }

        [Route("nova-turma")]
        public async Task<IActionResult> Create()
        {

            return View("Create");
        }


        [Route("editar-turma/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var collegeClass = await _collegeClass.GetCollegeClassAsync(id);

            if (collegeClass == null)
            {
                return NotFound();
            }

            return View(collegeClass);
        }


        [Route("editar-turma/{id:int}")]
        [HttpPost]
        public async Task<IActionResult> Edit(CollegeClassUpdateDto collegeClass)
        {

            if (!ModelState.IsValid) return View(collegeClass);

            var collegeClassResult = await _collegeClass.GetCollegeClassAsync(collegeClass.Id);

            if (collegeClassResult == null) return NotFound();

            try
            {
                await _collegeClass.UpdateCollegeClassAsync(collegeClass);
            }
            catch (Exception ex)
            {

                TempData["Error"] = $"{ex.Message}";
                return View(collegeClassResult);
            }

            TempData["Sucesso"] = "Editado com sucesso";
            return RedirectToAction("index");
        }

        [Route("deletar-turma/{id:int}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(CollegeClassUpdateDto collegeClass)
        {

            var collegeClassResult = await _collegeClass.GetCollegeClassAsync(collegeClass.Id);

            if (collegeClassResult == null) return NotFound();

            try
            {
                await _collegeClass.DeleteCollegeClassAsync(collegeClass.Id);
            }
            catch (Exception ex)
            {

                TempData["Error"] = $"{ex.Message}";
                return View("Delete");
            }

            TempData["Sucesso"] = "Turma Inativada com sucesso";
            return RedirectToAction("index");
        }


        [Route("deletar-turma/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var collegeClassResult = await _collegeClass.GetCollegeClassAsync(id);

            if (collegeClassResult == null) return NotFound();

            return View(collegeClassResult);

        }



    }
}
