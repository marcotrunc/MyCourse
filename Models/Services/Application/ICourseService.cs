using MyCourse.Models.ViewModel;

namespace MyCourse.Models.Services.Application
{
    public interface ICourseService
    {
       public List<CourseViewModel> GetCourses();
       public CourseDetailViewModel GetCourse(int id);
    }
}
