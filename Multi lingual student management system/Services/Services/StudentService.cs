using Multi_lingual_student_management_system.Data;
using Multi_lingual_student_management_system.Models;
using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Services
{
    public class StudentService : IStudentService
    {
        #region Ctor
        private readonly ApplicationDbContext _db;
        private readonly ILocalizationService _localization;

        public StudentService(ApplicationDbContext db,
                              ILocalizationService localization)
        {
            _db = db;
            _localization = localization;
        }
        #endregion
        #region Methods

        public async Task<List<Student>> GetAllStudentAsync()
        {
            var model = _db.Students.ToList();
            if (model == null) return new List<Student>();
            return model;

        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var model = _db.Students.Where(x => x.Id == id).Select(y => new Student()
            {
                Id = y.Id,
                Name = y.Name,
                Roll = y.Roll,
                EnrolledCourses = y.EnrolledCourses.Select(z => new Course()
                {
                    Id = z.Id,
                    Title = z.Title,
                    CourseTeacher = z.CourseTeacher
                }).ToList()
            }).FirstOrDefault();
            if (model == null) return new Student();

            return model;
        }
        public async Task UpdateStudentAsync(StudentModel viewModel)
        {

        }
        public async Task DeleteStudentByIdAsync(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if(student!=null)
            {
                _db.Students.Remove(student);
                await _db.SaveChangesAsync();

            }
           
        }
        public async Task InsertStudentAsync(StudentModel viewModel)
        {
            Student model = new Student();
            model.Id = viewModel.Id;
            model.Name = viewModel.Name;
            model.Roll = viewModel.Roll;
            await _db.Students.AddAsync(model);
            await _db.SaveChangesAsync();

            await _localization.InsertLocalizationAsync(viewModel.Language, "Student", model.Id, "Name", viewModel.Translation);
        }
        public async Task<bool> IsEnrolledCourseAsync(int courseId, int studentId)
        {
            if (courseId == 0 || studentId == 0) return false;
            var course = _db.Courses.Where(x => x.Id == courseId).FirstOrDefault();
            var isEnrolled = _db.Students.Where(x => x.Id == studentId).Select(y => y.EnrolledCourses.Contains(course)).FirstOrDefault();
            return isEnrolled;

        }

        public async Task RemoveEnrolledCourseFromStudentAsync(int courseId, int studentId)
        {
            if (courseId == 0 || studentId == 0) return ;
            var student =  _db.Students.Where(x => x.Id == studentId).FirstOrDefault();

             /* var students = await _db.Students.Where(x => x.Id == studentId).Select(y => new StudentModel()
              {
                  Id = y.Id,
                  EnrolledCourses = y.EnrolledCourses.Select(z => new CourseModel()
                  {
                      Id = z.Id,
                      Title = z.Title,
                      CourseTeacher = z.CourseTeacher

                  }).ToList()


              }).FirstOrDefault();*/

            foreach (var course in student.EnrolledCourses)
            {
                var check = await IsEnrolledCourseAsync(courseId, studentId);
                if(check)
                {
                    student.EnrolledCourses.Clear();
                }
            }
       

           if(student != null && student.EnrolledCourses != null) 
            {
               
                _db.Students.Update(student);
                await _db.SaveChangesAsync();
            }
          
            
        }


        public async Task EnrollCouresToStudenAsync(List<EnrollCourseModel> viewModel, int studentId)
        {
            var student = await _db.Students.FindAsync(studentId);
          
            if (student == null) return;

            var courseList = new List<Course>();

             for (int cnt = 0; cnt < viewModel.Count; cnt++)
             {
                 var course = await _db.Courses.FindAsync(viewModel[cnt].CourseId);
                 bool isEnrolledCourse = false;
                 isEnrolledCourse = await IsEnrolledCourseAsync(viewModel[cnt].CourseId, studentId);

                 if (course != null && viewModel[cnt].IsSelected && !isEnrolledCourse)
                 {
                    courseList.Add(course);
                   
                 }
                 else if (!viewModel[cnt].IsSelected && isEnrolledCourse)
                 {
                     await RemoveEnrolledCourseFromStudentAsync(viewModel[cnt].CourseId, studentId);
                 }

             }

            student.EnrolledCourses = courseList;
         
            _db.Students.Update(student);
            await _db.SaveChangesAsync();
        }
        #endregion
    }
}
