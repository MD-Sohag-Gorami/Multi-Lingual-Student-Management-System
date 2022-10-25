using Multi_lingual_student_management_system.Models;
using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Services
{
    public interface IStudentService
    {
        Task InsertStudentAsync(StudentModel viewModel);
        Task DeleteStudentByIdAsync(int id);
        Task<List<Student>> GetAllStudentAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task UpdateStudentAsync(StudentModel viewModel);
        Task<bool> IsEnrolledCourseAsync(int courseId, int studentId);
        Task EnrollCouresToStudenAsync(List<EnrollCourseModel> viewModel, int id);
        Task RemoveEnrolledCourseFromStudentAsync(int courseId, int studentId);
    }
}