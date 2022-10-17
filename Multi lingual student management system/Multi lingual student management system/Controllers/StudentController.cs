using Microsoft.AspNetCore.Mvc;
using Multi_lingual_student_management_system.Factories;
using Multi_lingual_student_management_system.Services;
using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Controllers
{
    public class StudentController : Controller
    {
        #region Ctro
        private readonly ILanguageService _language;
        private readonly IStudentModelFactory _studentFactory;
        private readonly IStudentService _student;

        public StudentController(ILanguageService language,
                               
                                 IStudentService student, 
                                 IStudentModelFactory studentFactory)
        {
            _language = language;
           
            _student = student;
            _studentFactory = studentFactory;
        }
        #endregion
        #region Methods
        public async Task<IActionResult> Index()
        {
            var model = await _studentFactory.PrepareAllStudentAsync();
            if(model == null) return NotFound();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var studentView = await _studentFactory.PrepareStudentModelAsync(new StudentModel());
            if(studentView == null) return NotFound();

            return View(studentView);
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentModel model)
        {
            if(ModelState.IsValid)
            {
                await _student.CreateStudentAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        #endregion
    }
}
