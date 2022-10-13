using Microsoft.AspNetCore.Mvc;

namespace Multi_lingual_student_management_system.Controllers
{
    public class TeacherController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
