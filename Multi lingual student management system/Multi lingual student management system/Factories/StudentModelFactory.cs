using Microsoft.AspNetCore.Mvc.Rendering;
using Multi_lingual_student_management_system.Models;
using Multi_lingual_student_management_system.Services;
using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Factories
{
    public class StudentModelFactory : IStudentModelFactory
    {
        private readonly IStudentService _student;
        private readonly ILanguageService _language;

        #region Ctor
        public StudentModelFactory(IStudentService student,
                                   ILanguageService language)
        {
     
          
            _student = student;
            _language = language;
        }
        #endregion
        #region Methods
        public async Task<StudentModel> PrepareStudentModelAsync(StudentModel viewModel)
        {
            var languages = await _language.GetAllLanguageAsync();

            foreach (var language in languages)
            {
                var item = new SelectListItem()
                {
                    Value = language.Id.ToString(),
                    Text = language.Name,
                };
                viewModel.TranslateLanguage.Add(item);
            }
            return viewModel;
        }

        public async Task<List<StudentModel>> PrepareAllStudentAsync()
        {
            var students = await _student.GetAllStudentAsync();
            List<StudentModel> studentList = new List<StudentModel>();

            foreach (var student in students)
            {

                StudentModel ViewModel = new StudentModel()
                {
                    Id = student.Id,
                    Name = student.Name,
                    Roll = student.Roll,
                };
                studentList.Add(ViewModel);
            }

            if (studentList == null) return new List<StudentModel>();
            return studentList;


        }
        public async Task<StudentModel> PrepareStudentByIdAsync(int id)
        {
            var student = await _student.GetStudentByIdAsync(id);

            if (student == null) return new StudentModel();

            StudentModel ViewModel = new StudentModel()
            {
                Id = student.Id,
                Name = student.Name,
                Roll = student.Roll,
            };

            return ViewModel;

        }
        #endregion
    }
}
