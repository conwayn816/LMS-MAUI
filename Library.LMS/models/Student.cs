using LMS.Models;
using LMS.Services;
using System.Collections.ObjectModel;
namespace LMS.Models
{
    public class Student
    {
        public Guid guid { get; set;}
        public int Id { get; set; }
        public string Name { get; set; }
        public StudentClassifcation Classification { get; set; }
        public Dictionary<Guid, double> Grades { get; set; }

        public Student()
        {
            Name = "";
            Grades = new Dictionary<Guid, double>();
            guid = Guid.NewGuid();
        }

        //Student Courses
        public ObservableCollection<Course> StudentCourses
        {
            get
            {
                var studentCourses = CourseService.Current.Courses
                    .Where(c => c.Roster.Contains(this)).ToList();
                return new ObservableCollection<Course>(studentCourses);
            }
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} - {Classification}";
        }
    }

    public enum StudentClassifcation
    {
        Freshman, Sophomore, Junior, Senior
    }
}