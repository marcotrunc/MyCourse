using Microsoft.AspNetCore.Mvc;
using MyCourse.Models.Services.Application;
using MyCourse.Models.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace MyCourse.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;
        public CoursesController(ICourseService courseService) => _courseService = courseService;
        public IActionResult Index()
        {
            List<CourseViewModel> courses = _courseService.GetCourses();
            return View(courses);
        }

        public IActionResult Detail(int id)
        {
            CourseDetailViewModel viewModel = _courseService.GetCourse(id);
            return View(viewModel);
        }
    }
}
