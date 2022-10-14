using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Services
{
    public interface ILanguageService
    {
        Task DeleteLanguageByIdAsync(int? id);
        Task<List<LanguageModel>> GetAllLanguageAsync();
        Task<LanguageModel> GetLanguageByIdAsync(int? id);
        Task UpdateLanguageAsync(LanguageModel viewModel);
        Task CreateLanguageAsync(LanguageModel viewModel);
    }
}