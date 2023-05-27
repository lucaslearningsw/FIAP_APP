using WebApp.Models.Dto;
using WebApp.Models.Dto.CollegeClass;

namespace WebApp.Services.IServices
{
    public interface ICollegeClassService
    {
        Task<List<CollegeClassDto>> GetAllCollegeAsync();
        Task<CollegeClassDto> GetCollegeClassAsync(int id);

        Task CreateCollegeClassAsync(CollegeClassCreationDto dto);
        Task UpdateCollegeClassAsync(CollegeClassUpdateDto dto);

        Task DeleteCollegeClassAsync (int id);
    }
}
