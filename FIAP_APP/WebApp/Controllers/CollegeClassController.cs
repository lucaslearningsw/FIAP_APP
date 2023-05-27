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
        public async Task<IActionResult> Edit(CollegeClassDto collegeClass)
        {
            if (!ModelState.IsValid) return View(collegeClass);

            var collegeClassResult = await _collegeClass.GetCollegeClassAsync(collegeClass.Id);

            if (collegeClassResult == null) return NotFound();

            await _collegeClass.UpdateCollegeClassAsync(collegeClass);


            return RedirectToAction("index");
        }





    }
}
