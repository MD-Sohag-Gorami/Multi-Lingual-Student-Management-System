using Microsoft.AspNetCore.Mvc;
using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Controllers
{
    public class LanguageController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
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
                
                return RedirectToAction("Index");
            }
            
            return View(model);
        }
    }
}
