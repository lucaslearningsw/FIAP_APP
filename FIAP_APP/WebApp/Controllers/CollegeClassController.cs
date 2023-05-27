using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Dto;
using WebApp.Models.Dto.CollegeClass;
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

           
            await _collegeClass.CreateCollegeClassAsync(studentDto);

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
  
            var collegeClassResult = await _collegeClass.GetCollegeClassAsync(collegeClass.Id);

            if (collegeClassResult == null) return NotFound();

            await _collegeClass.UpdateCollegeClassAsync(collegeClass);


            return RedirectToAction("index");
        }

        [Route("deletar-turma/{id:int}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(CollegeClassUpdateDto collegeClass)
        {

            var collegeClassResult = await _collegeClass.GetCollegeClassAsync(collegeClass.Id);

            if (collegeClassResult == null) return NotFound();

            await _collegeClass.DeleteCollegeClassAsync(collegeClass.Id);


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
