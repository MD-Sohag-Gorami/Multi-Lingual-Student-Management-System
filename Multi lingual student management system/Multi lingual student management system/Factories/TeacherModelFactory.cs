using Multi_lingual_student_management_system.Models;
using Multi_lingual_student_management_system.Services;
using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Factories
{
    public class TeacherModelFactory : ITeacherModelFactory
    {
        private readonly ICourseService _course;
        private readonly ITeacherService _teacher;

        public TeacherModelFactory(ICourseService course, ITeacherService teacher)
        {
            _course = course;
            _teacher = teacher;
        }

        private async Task<TeacherModel> PrepareTeacherByModelAsync(Teacher model)
        {
            TeacherModel ViewModel = new TeacherModel()
            {
                Id = model.Id,
                Name = model.Name,
                Designation = model.Designation,

                TakenCourses = model.TakenCourses.Select(m => new CourseModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Code = m.Code,
                    TeacherId = m.TeacherId,

                }).ToList(),

            };
            return ViewModel;
        }
        public async Task<List<TeacherModel>> PrepareAllTeacherAsync()
        {
            var model = await _teacher.GetAllTeacherAsync();

            List<TeacherModel> teacherList = new List<TeacherModel>();
            foreach (var item in model)
            {
                var createView = await PrepareTeacherByModelAsync(item);
                teacherList.Add(createView);
            }
            return teacherList;
        }
        public async Task<TeacherModel> PrepareTeacherByIdAsync(int id)
        {
            var model = await _teacher.GetTeacherByIdAsync(id);
            model.TakenCourses = await _course.GetAllCourseAsync(teacherId:id);
            var createView = await PrepareTeacherByModelAsync(model);

            return createView;
        }
    }
}
