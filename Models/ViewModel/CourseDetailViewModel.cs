using System.Collections.Generic;
using System.Data;
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

        public static CourseDetailViewModel FromDataRow(DataRow courseRow)
        {
            var courseDetailViewModel = new CourseDetailViewModel()
            {
                Description = Convert.ToString(courseRow["Description"]),
                Title = Convert.ToString(courseRow["Title"]),
                Author = Convert.ToString(courseRow["Author"]),
                ImagePath = Convert.ToString(courseRow["ImagePath"]),
                Rating = Convert.ToDouble(courseRow["Rating"]),
                FullPrice = new Money(
                    Enum.Parse<Currency>(Convert.ToString(courseRow["FullPrice_Currency"])),
                    Convert.ToDecimal(courseRow["FullPrice_Amount"])
                    ),
                CurrentPrice = new Money(
                    Enum.Parse<Currency>(Convert.ToString(courseRow["CurrentPrice_Currency"])),
                    Convert.ToDecimal(courseRow["CurrentPrice_Amount"])
                    ),
                Id = Convert.ToInt32(courseRow["Id"]),
                Lessons = new List<LessonViewModel>()
            };
            return courseDetailViewModel;
        }
    }
}
