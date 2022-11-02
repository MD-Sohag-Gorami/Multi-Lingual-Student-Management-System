using Multi_lingual_student_management_system.Models;
using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Services
{
    public interface ICourseService
    {
        Task InsertCourseAsync(CourseModel viewModel);
        Task DeleteCourseByIdAsync(int id);
        Task<List<Course>> GetAllCourseAsync(int teacherId = 0);
        Task<Course> GetCourseByIdAsync(int id);
        Task UpdateCourseAsync(CourseModel viewModel);
    }
}