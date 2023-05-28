using Flurl.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using WebApp.Models.Dto;
using WebApp.Models.Dto.CollegeClass;
using WebApp.Models.Dto.Student;
using WebApp.Services.IServices;

namespace WebApp.Services
{
    public class CollegeClassService : ICollegeClassService
    {
        private string apiUrl;

        public CollegeClassService( IConfiguration configuration)
        {
            apiUrl = configuration.GetValue<string>("ServicesUrls:APIUrl");
        }

        public async Task CreateCollegeClassAsync(CollegeClassCreationDto dto)
        {
            try
            {
                var url = apiUrl + "/api/CollegeClass/criar-turma";

                await url.PostJsonAsync(dto);
            }
            catch (FlurlHttpException ex)
            {
                var exceptionMessage = await ex.GetResponseStringAsync();  
                throw new Exception(exceptionMessage);
            }
            catch(Exception)
            {
                throw;
            }

        }

        public async Task<List<CollegeClassDto>> GetAllCollegeAsync()
        {
            try
            {
                var url = apiUrl + "/api/CollegeClass/lista-turma";

                var listResult = await url.GetJsonAsync<List<CollegeClassDto>>();

                return listResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CollegeClassDto> GetCollegeClassAsync(int id)
        {
            try
            {
                var collegeClass = await $"{apiUrl}/api/CollegeClass/turma-detalhe?id={id}".GetJsonAsync<CollegeClassDto>();

                return collegeClass;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateCollegeClassAsync(CollegeClassUpdateDto dto)
        {
            try
            {
                var url = apiUrl + "/api/CollegeClass/editar-turma";

                await url.PostJsonAsync(dto);
            }
            catch (FlurlHttpException ex)
            {
                var exceptionMessage = await ex.GetResponseStringAsync();
                throw new Exception(exceptionMessage);
            }

            catch(Exception)
            {
                throw;
            }

        }


        public async Task DeleteCollegeClassAsync(int id)
        {
            try
            {
                await $"{apiUrl}/api/CollegeClass/inativar-turma?id={id}".DeleteAsync();

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
