using Microsoft.AspNetCore.Mvc.Rendering;

namespace Multi_lingual_student_management_system.ViewModel
{
    public class TeacherModel
    {
        public TeacherModel()
        {
            AvailableLanguage = new List<LanguageModel>();
            TakenCourses = new List<CourseModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string? Designation { get; set; }
        public IList<CourseModel> TakenCourses { get; set; }
        public IList<LanguageModel> AvailableLanguage { get; set; }

    }
}
