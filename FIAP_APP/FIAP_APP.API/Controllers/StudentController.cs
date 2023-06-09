﻿using AutoMapper;
using FIAP_APP.API.Dto.Student;
using FIAP_APP.Domain.Models;
using FIAP_APP.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIAP_APP.API.Controllers
{
    [Route("api/Student")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(StudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [Route("lista-estudantes")]
        [HttpGet]
        public ActionResult<List<Student>> GetAllStudents()
        {
            try
            {
                return _studentService.GetAllStudents();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("estudante-detalhe")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            try
            {
                var student = await _studentService.GetStudent(id);

                if(student == null) return NotFound();

                return student;
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Route("criar-estudante")]
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentCreationDto obj)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                return Ok(await _studentService.CreateStudent(_mapper.Map<Student>(obj)));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

          
        }


        [Route("editar-estudante")]
        [HttpPost]
        public async Task<IActionResult> EditStudent(StudentUpdate obj)
        {

            if (!ModelState.IsValid) return BadRequest();

            if (await _studentService.GetStudent(obj.Id) == null) return NotFound();
           
            try
            {
               await _studentService.EditStudent(_mapper.Map<Student>(obj));

               return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [Route("inativar-aluno")]
        [HttpDelete]
        public async Task<IActionResult>InactivateStudent(int id)
        {
            try
            {
                await _studentService.InactivateStudent(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }






    }
}
