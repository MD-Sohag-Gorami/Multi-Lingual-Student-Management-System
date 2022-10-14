using Multi_lingual_student_management_system.Data;
using Multi_lingual_student_management_system.Models;
using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Services
{
    public class TeacherService : ITeacherService
    {

        private readonly ApplicationDbContext _db;
     

        public TeacherService(ApplicationDbContext db)
        {
            _db = db;
           
        }

        public async Task<List<Teacher>> GetAllTeacherAsync()
        {
            var model = _db.Teachers.ToList();
            if (model == null) return new List<Teacher>();
            return model;

        }
        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            var model = await _db.Teachers.FindAsync(id);
            if(model == null) return new Teacher();
            return model;
        }
        public async Task UpdateTeacherAsync(TeacherModel viewModel)
        {

        }
        public async Task DeleteTeacherByIdAsync(int id)
        {

        }
        public async Task CreateTeacherAsync(TeacherModel viewModel)
        {
           

            Teacher model = new Teacher();
            model.Id = viewModel.Id;
            model.Name = viewModel.Name;
            model.Designation = viewModel.Designation;
            await _db.Teachers.AddAsync(model);
            await _db.SaveChangesAsync();
        }

    }
}
