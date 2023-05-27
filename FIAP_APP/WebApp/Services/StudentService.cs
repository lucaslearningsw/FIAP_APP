using WebApp.Models.Dto;
using WebApp.Services.IServices;
using WebApp.Models.Dto.Student;
using Flurl.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System;
using Newtonsoft.Json;
using Flurl;

namespace WebApp.Services
{
    public class StudentService : IStudentService
    { 

        private string apiUrl;

        public StudentService(IConfiguration configuration)
        {
            apiUrl = configuration.GetValue<string>("ServicesUrls:APIUrl");
        }
       
        public async Task CreateStudent(StudentCreationDto dto)
        {
            try
            {
                var url = apiUrl + "/api/Student/criar-estudante";

                await url.PostJsonAsync(dto);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public Task  DeleteStudentAsync (int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StudentDto>> GetAllStudentAsync()
        {
            try
            {
                var url = apiUrl + "/api/Student/lista-estudantes";

                var listResult = await url.GetJsonAsync<List<StudentDto>>();

                return listResult;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<StudentDto> GetStudentAsync(int id)
        {
            try
            {
                var student = await $"{apiUrl}/api/Student/estudante-detalhe?id={id}".
                GetJsonAsync<StudentDto>();

               return student;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateStudentAsync (StudentUpdate dto)
        {
            try
            {
                var student = await $"{apiUrl}/api/Student/editar-estudante".PutJsonAsync(dto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
