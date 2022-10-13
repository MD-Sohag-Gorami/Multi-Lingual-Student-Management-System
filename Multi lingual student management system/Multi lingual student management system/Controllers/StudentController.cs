using Microsoft.AspNetCore.Mvc;

namespace Multi_lingual_student_management_system.Controllers
{
    public class StudentController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        
    }
}
