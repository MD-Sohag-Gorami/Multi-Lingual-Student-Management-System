using Microsoft.AspNetCore.Mvc;
using Multi_lingual_student_management_system.Factories;
using Multi_lingual_student_management_system.Services;
using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseModelFactory _courseFactory;
        private readonly ITeacherModelFactory _teacherFactory;
        private readonly ICourseService _course;

        public CourseController(ICourseModelFactory courseFactory,
                                ITeacherModelFactory teacherFactory,
                                ICourseService course)
        {
            
            _courseFactory = courseFactory;
            _teacherFactory = teacherFactory;
            _course = course;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _courseFactory.PrepareAllCourseAsync();
            if (model == null) return NotFound();

            return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var teachers = await _courseFactory.PrepareCourseModelAsync(new CourseModel());
            if (teachers == null) return NotFound();
         
            return View(teachers);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CourseModel model)
        {
            if (ModelState.IsValid)
            {
                await _course.InsertCourseAsync(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            await _course.DeleteCourseByIdAsync(id.Value);
            return RedirectToAction("Index");
        }
    }
    
}
