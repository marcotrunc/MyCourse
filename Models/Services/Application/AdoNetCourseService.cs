using MyCourse.Models.Services.Infrastructure;
using MyCourse.Models.ViewModel;
using System.Data;

namespace MyCourse.Models.Services.Application
{
    public class AdoNetCourseService : ICourseService 
    {
        private readonly IDatabaseAccessor db;
        public AdoNetCourseService(IDatabaseAccessor db) 
        { 
            this.db = db;   
        }
        public CourseDetailViewModel GetCourse(int id)
        {
            string query = $"SELECT Id, Title, ImagePath, Author, Description,Rating, FullPrice_Amount,FullPrice_Currency, CurrentPrice_Amount, CurrentPrice_Currency FROM Courses WHERE Id = {id};" +
                $"SELECT Id, Title, Description, Duration FROM Lessons WHERE CourseId = {id};";
            DataSet dataSet = db.Query(query);
            
            //Course Table
            DataTable courseTable = dataSet.Tables[0];
            if(courseTable.Rows.Count != 1)
            {
                throw new InvalidConstraintException($"Did not return exactly 1 row for course {id}");
            }
            DataRow courseRow = courseTable.Rows[0];
            CourseDetailViewModel courseDetailViewModel = CourseDetailViewModel.FromDataRow(courseRow);


            //Lessons Table
            DataTable lessonDataTable = dataSet.Tables[1];
            foreach(DataRow lessonRow in lessonDataTable.Rows)
            {
                LessonViewModel lesson = LessonViewModel.FromDataRow(lessonRow);
                courseDetailViewModel.Lessons.Add(lesson);
            }

            return courseDetailViewModel;
        }

        public List<CourseViewModel> GetCourses()
        {
            string query = "SELECT Id, Title, ImagePath, Author, Rating, FullPrice_Amount,FullPrice_Currency, CurrentPrice_Amount, CurrentPrice_Currency FROM Courses";
            DataSet dataSet =  db.Query(query);
            var dataTable = dataSet.Tables[0];
            List<CourseViewModel> courseList = new List<CourseViewModel>();
            foreach(DataRow courseRow in dataTable.Rows)
            {
                CourseViewModel course = CourseViewModel.FromDataRow(courseRow);
                courseList.Add(course);
            }
            return courseList;
        }
    }
}
