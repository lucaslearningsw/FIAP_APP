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
            catch (FlurlHttpException ex)
            {
                var exceptionMessage = await ex.GetResponseStringAsync();
                throw new Exception(exceptionMessage);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task  DeleteStudentAsync (int id)
        {
            try
            {
                await $"{apiUrl}/api/Student/inativar-aluno?id={id}".DeleteAsync();

            }
            catch (FlurlHttpException ex)
            {
                var exceptionMessage = await ex.GetResponseStringAsync();
                throw new Exception(exceptionMessage);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<StudentDto>> GetAllStudentAsync()
        {
            try
            {
                var url = apiUrl + "/api/Student/lista-estudantes";

                var listResult = await url.GetJsonAsync<List<StudentDto>>();

                return listResult;
            }
            catch (FlurlHttpException ex)
            {
                var exceptionMessage = await ex.GetResponseStringAsync();
                throw new Exception(exceptionMessage);
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
            catch (FlurlHttpException ex)
            {
                var exceptionMessage = await ex.GetResponseStringAsync();
                throw new Exception(exceptionMessage);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateStudentAsync (StudentDto dto)
        {
            try
            {
                var student = await $"{apiUrl}/api/Student/editar-estudante".PostJsonAsync(dto);
            }
            catch (FlurlHttpException ex)
            {
                var exceptionMessage = await ex.GetResponseStringAsync();
                throw new Exception(exceptionMessage);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
