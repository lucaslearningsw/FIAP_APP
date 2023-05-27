using Flurl.Http;
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

        public Task CreateCollegeClassAsync(CollegeClassCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCollegeClassAsync(int id)
        {
            throw new NotImplementedException();
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
                var student = await $"{apiUrl}/api/CollegeClass/turma-detalhe?id={id}".GetJsonAsync<CollegeClassDto>();

                return student;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateCollegeClassAsync(CollegeClassDto dto)
        {
            try
            {
                var student = await $"{apiUrl}/api/CollegeClass/editar-turma".PutJsonAsync(dto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
