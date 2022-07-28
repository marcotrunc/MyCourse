using MyCourse.Models.ValueTypes;
using System;
using System.Data;

namespace MyCourse.Models.ViewModel
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Author { get; set; }
        public double Rating { get; set; }
        public Money FullPrice { get; set; }
        public Money CurrentPrice { get; set; }

        public static CourseViewModel FromDataRow(DataRow courseRow)
        {
            var course = new CourseViewModel()
            {
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
            };
            return course;
        }
    }
}
