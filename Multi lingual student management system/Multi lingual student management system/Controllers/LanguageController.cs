using Microsoft.AspNetCore.Mvc;
using Multi_lingual_student_management_system.Services;
using Multi_lingual_student_management_system.ViewModel;
namespace Multi_lingual_student_management_system.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageService _language;

        public LanguageController(ILanguageService language)
        {
            _language = language;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _language.GetAllLanguageAsync();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(LanguageModel model)
        {
            if(ModelState.IsValid)
            {
                await _language.CreateLanguageAsync(model);
                return RedirectToAction("Index");
            }
            
            return View(model);
        }
    }
}
