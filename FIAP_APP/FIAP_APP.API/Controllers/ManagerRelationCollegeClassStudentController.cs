using AutoMapper;
using FIAP_APP.Domain.Models;
using FIAP_APP.Domain.Services.ManagerRelationClassStudent;
using Microsoft.AspNetCore.Mvc;

namespace FIAP_APP.API.Controllers
{
    [Route("api/ManagerRelationCollegeClassStudent")]
    public class ManagerRelationCollegeClassStudentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ManagerRelationClassStudentService _managerRelationService;

        public ManagerRelationCollegeClassStudentController(IMapper mapper, ManagerRelationClassStudentService managerRelationService)
        {
            _mapper = mapper;
            _managerRelationService = managerRelationService;
        }

        [Route("relacoes-classes_estudantes")]
        [HttpGet]
        public ActionResult<List<RelationsClassStudent>> GetRelationsClassStudent()
        {
            try
            {
                return _managerRelationService.GetRelationsClassStudent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
