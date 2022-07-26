using System.Collections.Generic;
using MyCourse.Models.ValueTypes;
namespace MyCourse.Models.ViewModel
{
    public class CourseDetailViewModel : CourseViewModel
    {
        public string Description { get; set; }

        public List<LessonViewModel> Lessons { get; set; }

        public TimeSpan TotalCourseDuration
        {
            get => TimeSpan.FromSeconds(Lessons?.Sum(x => x.Duration.TotalSeconds) ?? 0);
        }
    }
}
