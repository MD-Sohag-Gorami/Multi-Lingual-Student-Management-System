using Multi_lingual_student_management_system.Models;
using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Services
{
    public interface IStudentService
    {
        Task CreateStudentAsync(StudentModel viewModel);
        Task DeleteStudentByIdAsync(int id);
        Task<List<Student>> GetAllStudentAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task UpdateStudentAsync(StudentModel viewModel);
    }
}