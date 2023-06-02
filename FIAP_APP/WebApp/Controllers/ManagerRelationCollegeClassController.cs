using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Dto.RelationsClassStudent;
using WebApp.Models.Dto.Student;
using WebApp.Services.IServices;

namespace WebApp.Controllers
{
    public class ManagerRelationCollegeClassController : Controller
    {
        private readonly IManagerRelationClassStudentService _managerRelationClass;

        public ManagerRelationCollegeClassController(IManagerRelationClassStudentService managerRelationClass)
        {
            _managerRelationClass = managerRelationClass;
        }

        [Route("lista-relacoes")]
        public async Task<IActionResult> Index()
        {
            try
            {
               var result = await _managerRelationClass.GetRelationsClassStudentDto();
               return View(result);
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        [Route("inativar-relacao/{userId}/{collegeClassId}")]
        [HttpPost, ActionName("Inativate")]
        public async Task<IActionResult> Delete(int userId, int collegeClassId)
        {

             try
            {
                await _managerRelationClass.InativateRelation(userId, collegeClassId);
                TempData["Sucesso"] = "Relação Inativada com sucesso";
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {

                TempData["Error"] = $"{ex.Message}";
                return View();
            }

        }



        [Route("inativar-relacao/{studentId}/{collegeClassId}")]
        [HttpGet, ActionName("Inativate")]
        public async Task<IActionResult> Inativate(int studentId, int collegeClassId)
        {

            return PartialView("_Inativar", new RelationsClassStudentDto { CollegeName = "test", CollegeClassID= 12, StudentId = 12, StudentName = "ESTUDANTE"});

        }
    }
}
