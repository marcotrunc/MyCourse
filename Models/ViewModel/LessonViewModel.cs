using System.Data;

namespace MyCourse.Models.ViewModel
{
    public class LessonViewModel
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }

        public static LessonViewModel FromDataRow(DataRow lessonRow)
        {
            DateTime dateTime = DateTime.Parse(lessonRow["Duration"].ToString());
            LessonViewModel lessonViewModel = new LessonViewModel()
            {
                Title = Convert.ToString(lessonRow["Title"]),
                Duration = TimeSpan.Parse(dateTime.ToString("hh:mm:ss"))
            };
            return lessonViewModel;
        }
    }
}