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


        [Route("lista-turma")]
        [HttpGet]
        public ActionResult<List<CollegeClass>> GetAllCollegeClass()
        {
            try
            {
                return _collegeClassService.GetAllClass();
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = ex.Message });
            }
        }

        [Route("criar-turma")]
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

        [Route("turma-detalhe")]
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

        [Route("editar-turma")]
        [HttpPost]
        public async Task<IActionResult> EditTurma([FromBody] CollegeClassUpdateDto dto)
        {

            if (!ModelState.IsValid) return BadRequest();

            try
            {
                await _collegeClassService.EditCollegeClass(_mapper.Map<CollegeClass>(dto));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = ex.Message });

            }
        }


        [Route("inativar-turma")]
        [HttpDelete]
        public  async Task<IActionResult> InactivateClass(int id)
        {
            try
            {
               await _collegeClassService.InactivateCollegeClass(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseObject { Status = "Error", ErrorMessage = ex.Message });
            }
        }
    }
}
