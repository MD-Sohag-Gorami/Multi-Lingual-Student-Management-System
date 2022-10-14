using Multi_lingual_student_management_system.Models;
using Multi_lingual_student_management_system.ViewModel;
namespace Multi_lingual_student_management_system.Services
{
    public interface ITeacherService
    {
        Task CreateTeacherAsync(TeacherModel viewModel);
        Task DeleteTeacherByIdAsync(int id);
        Task<List<Teacher>> GetAllTeacherAsync();
        Task<Teacher> GetTeacherByIdAsync(int id);
        Task UpdateTeacherAsync(TeacherModel viewModel);
    }
}