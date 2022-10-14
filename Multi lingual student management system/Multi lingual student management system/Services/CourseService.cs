using Multi_lingual_student_management_system.Data;
using Multi_lingual_student_management_system.Models;
using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Services
{
    public class CourseService : ICourseService
    {

        private readonly ApplicationDbContext _db;
        private readonly ITeacherService _teacher;

        public CourseService(ApplicationDbContext db,
                             ITeacherService teacher)
        {
            _db = db;
            _teacher = teacher;
        }

        public async Task<List<Course>> GetAllCourseAsync(int teacherId = 0)
        {
            var model = _db.Courses.ToList();
            if(teacherId > 0)
            {
                model = model.Where(teacher => teacher.TeacherId == teacherId).ToList();
            }

            return model;

        }
        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return new Course();
        }
        public async Task UpdateCourseAsync(CourseModel viewModel)
        {

        }
        public async Task DeleteCourseByIdAsync(int id)
        {

        }
        public async Task CreateCourseAsync(CourseModel viewModel)
        {
            var teacher = await _teacher.GetTeacherByIdAsync(viewModel.TeacherId);
            var model = new Course()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                TeacherId = viewModel.TeacherId,
                CourseTeacher = teacher.Name,
                Code = viewModel.Code,
            };
            
             
            await _db.Courses.AddAsync(model);
            await _db.SaveChangesAsync();
        }

    }
}
