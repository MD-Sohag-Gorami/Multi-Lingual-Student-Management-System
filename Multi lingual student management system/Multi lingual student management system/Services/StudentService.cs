using Multi_lingual_student_management_system.Data;
using Multi_lingual_student_management_system.Models;
using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Services
{
    public class StudentService : IStudentService
    {

        private readonly ApplicationDbContext _db;


        public StudentService(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<List<Student>> GetAllStudentAsync()
        {
            var model = _db.Students.ToList();
            if (model == null) return new List<Student>();
            return model;

        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var model = await _db.Students.FindAsync(id);
            if (model == null) return new Student();
            return model;
        }
        public async Task UpdateStudentAsync(StudentModel viewModel)
        {

        }
        public async Task DeleteStudentByIdAsync(int id)
        {

        }
        public async Task CreateStudentAsync(StudentModel viewModel)
        {
            Student model = new Student();
            model.Id = viewModel.Id;
            model.Name = viewModel.Name;
            model.Roll = viewModel.Roll;
            await _db.Students.AddAsync(model);
            await _db.SaveChangesAsync();
        }

    }
}
