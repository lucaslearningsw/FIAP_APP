using AutoMapper;
using FIAP_APP.API.Dto.CollegeClass;
using FIAP_APP.Domain.Models;
using FIAP_APP.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace FIAP_APP.API.Controllers
{

    [Route("api/CollegeClass")]
    [ApiController]
    public class CollegeClassController : Controller
    {
        private readonly CollegeClassService _collegeClassService;
        private readonly IMapper _mapper;

        public CollegeClassController(CollegeClassService collegeClassService, IMapper mapper)
        {
            _collegeClassService = collegeClassService;
            _mapper = mapper;
        }


        [Route("ListaTurma")]
        [HttpGet]
        public async Task<List<CollegeClass>> GetAllCollegeClass()
        {
            try
            {
                return _collegeClassService.GetAllClass();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("CriarTurma")]
        [HttpPost]
        public async Task<IActionResult> CreateClass([FromBody] CollegeClassCreationDto obj)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                return Ok(await _collegeClassService.CreateCollegeClass(_mapper.Map<CollegeClass>(obj)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = ex.Message });
            }
        }

        [Route("TurmaDetalhe")]
        [HttpGet]
        public async Task<ActionResult<CollegeClass>> GetCollegeClass(int id)
        {
            try
            {
                var collegeClass = await _collegeClassService.GetCollegeClass(id);

                if (collegeClass == null) return NotFound();

                return collegeClass;
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [Route("EditarTurma")]
        [HttpPost]
        public async Task<IActionResult> EditTurma([FromBody] CollegeClass obj)
        {

            if (!ModelState.IsValid) return BadRequest();

            try
            {
               await _collegeClassService.EditCollegeClass(obj);
               return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = ex.Message });

            }
        }


        [Route("InativarTurma")]
        [HttpPost]
        public ActionResult<ResponseObject> InactivateClass([FromBody] CollegeClass obj)
        {
            if (obj == null)
            {
                return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = "invali json" });
            }
            try
            {
                return Ok(_collegeClassService.InactivateCollegeClass(obj));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = ex.Message });
            }
        }
    }
}
