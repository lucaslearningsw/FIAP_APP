using WebApp.Models.Dto;
using WebApp.Models.Dto.Student;

namespace WebApp.Services.IServices
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAllStudentAsync();
        Task<StudentDto> GetStudentAsync(int id);

        Task CreateStudent (StudentCreationDto dto);
        Task UpdateStudentAsync(StudentUpdate dto);

        Task DeleteStudentAsync(int id);
    }
}
