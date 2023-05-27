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
                var url = apiUrl + "/api/CollegeClass/ListaTurma";

                var listResult = await url.GetJsonAsync<List<CollegeClassDto>>();

                return listResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<CollegeClassDto> GetCollegeClassAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCollegeClassAsync(CollegeClassUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
