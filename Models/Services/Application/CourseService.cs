using MyCourse.Models.ValueTypes;
using MyCourse.Models.ViewModel;
using System;

namespace MyCourse.Models.Services.Application
{
    public class CourseService
    {
        public List<CourseViewModel> GetCourses()
        {
            List<CourseViewModel> courseList = new List<CourseViewModel>();
            Random random = new Random();

            for (int i =0; i <= 20; i++){
                var price = Convert.ToDecimal(random.NextDouble() * 10 + 10);
                var course = new CourseViewModel()
                {
                    Id = i,
                    Title = $"Corso {i}",
                    CurrentPrice = new Money(Currency.EUR, price),
                    FullPrice = new Money(Currency.EUR, random.NextDouble() > 0.5 ? price : price - 1),
                    Author = "Mario Rossi",
                    Rating = random.NextDouble() * 5.0,
                    ImagePath = "~/logo.svg"
                };
                courseList.Add(course);
            }
            return courseList;
        }

        public CourseDetailViewModel GetCourse(int id)
        {
            Random random = new Random();
            var price = Convert.ToDecimal(random.NextDouble() * 10 + 10);
            CourseDetailViewModel course = new CourseDetailViewModel()
            {
                Id = id,
                Title = $"Corso {id}",
                CurrentPrice = new Money(Currency.EUR, price),
                FullPrice = new Money(Currency.EUR, random.NextDouble() > 0.5 ? price : price - 1),
                Author = "Mario Rossi",
                Rating = random.NextDouble() * 5.0,
                ImagePath = "~/logo.svg",
                Description = $"Descrizione {id}",
                Lessons = new List<LessonViewModel>()
            };

            for (int i = 1; i <= 5; i++)
            {
                LessonViewModel lesson = new LessonViewModel()
                {
                    Title = $"Lezione {i}",
                    Duration = TimeSpan.FromSeconds(random.Next(40, 90))
                };
                course.Lessons.Add(lesson);
            }
            return course;
        }
    }
}
