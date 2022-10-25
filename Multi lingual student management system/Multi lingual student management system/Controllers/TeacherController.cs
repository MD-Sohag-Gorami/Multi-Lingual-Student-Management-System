using Microsoft.AspNetCore.Mvc;
using Multi_lingual_student_management_system.Factories;
using Multi_lingual_student_management_system.Models;
using Multi_lingual_student_management_system.Services;
using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherModelFactory _teacherFactroy;
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherModelFactory teacherFactroy,
                                 ITeacherService teacherService)
                                 
        {
            _teacherFactroy = teacherFactroy;
            _teacherService = teacherService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _teacherFactroy.PrepareAllTeacherAsync();
            if(model == null) return NotFound();
            return View(model);
         
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = await _teacherFactroy.PrepareTeacherModelAsync(new TeacherModel());

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeacherModel model)
        {
            if (ModelState.IsValid)
            {
                await _teacherService.InsertTeacherAsync(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if(id == null || id == 0) return NotFound();
            var model = await _teacherFactroy.PrepareTeacherByIdAsync(id.Value);
            if (model == null) return NotFound();

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            await _teacherService.DeleteTeacherByIdAsync(id.Value);
            return RedirectToAction("Index");
        }
    }
}
