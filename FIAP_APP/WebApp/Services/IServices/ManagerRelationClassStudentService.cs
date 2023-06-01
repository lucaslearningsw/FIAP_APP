using Flurl.Http;
using WebApp.Models.Dto.RelationsClassStudent;
using WebApp.Models.Dto.Student;

namespace WebApp.Services.IServices
{
    public class ManagerRelationClassStudentService : IManagerRelationClassStudentService
    {
        private readonly string apiUrl;

        public ManagerRelationClassStudentService(IConfiguration configuration)
        {
            apiUrl = configuration.GetValue<string>("ServicesUrls:APIUrl");
        }
        public Task GetAllStudentsFromCollegeClass(int collegeClassId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RelationsClassStudentDto>> GetRelationsClassStudentDto()
        {
            try
            {
                var url = apiUrl + "/api/ManagerRelationCollegeClassStudent/relacoes-classes_estudantes";

                var listResult = await url.GetJsonAsync<List<RelationsClassStudentDto>>();

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

        public Task InativateRelation(int userId, int collegeClassId)
        {
            throw new NotImplementedException();
        }

        public Task RelateCollegeWithStudent(int userId, int collegeClassId)
        {
            throw new NotImplementedException();
        }
    }
}
