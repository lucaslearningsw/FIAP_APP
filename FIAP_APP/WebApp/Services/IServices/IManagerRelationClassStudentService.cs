using WebApp.Models.Dto.RelationsClassStudent;

namespace WebApp.Services.IServices
{
    public interface IManagerRelationClassStudentService
    {
        Task<List<RelationsClassStudentDto>> GetRelationsClassStudentDto();
        Task InativateRelation(int userId, int collegeClassId);
        Task RelateCollegeWithStudent(int userId, int collegeClassId);

        Task GetAllStudentsFromCollegeClass(int collegeClassId);

    }
}
