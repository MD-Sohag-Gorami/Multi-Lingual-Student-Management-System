using Multi_lingual_student_management_system.Data;
using Multi_lingual_student_management_system.Models;
using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ApplicationDbContext _db;

        public LanguageService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<LanguageModel>> GetAllLanguageAsync()
        {
            var model = _db.Languages.ToList();
            List<LanguageModel> viewModel = new List<LanguageModel>();  
            if(model == null) return viewModel;
            foreach(var language in model)
            {

                viewModel.Add(new LanguageModel
                {

                    Name = language.Name,
                    Id = language.Id,

                });
                    
            }

            return viewModel;

        }
        public async Task<LanguageModel> GetLanguageByIdAsync(int? id)
        {
            return new LanguageModel();
        }
        public async Task UpdateLanguageAsync(LanguageModel viewModel)
        {

        }
        public async Task DeleteLanguageByIdAsync(int? id)
        {

        }
        public async Task CreateLanguageAsync(LanguageModel viewModel)
        {
            Language model = new Language();
            model.Id = viewModel.Id;
            model.Name = viewModel.Name;
            await _db.Languages.AddAsync(model);
            await _db.SaveChangesAsync();
        }

    }
}
