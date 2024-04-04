using LMS.Models;

namespace LMS.Services
{
    public class CourseService
    {
        private IList<Course> courses;
        private string query;

        //singleton pattern
        private static readonly object currentLock = new object();
        private static CourseService? instance;
        public static CourseService Current
        {
            get
            {
                lock (currentLock)
                {
                    if (instance == null)
                    {
                        instance = new CourseService();
                    }
                }

                return instance;
            }
        }

        //default constructor only used in current
        private CourseService()
        {
            query = string.Empty;
            courses = new List<Course>() {
                new Course { Code = "CS101", Name = "Intro to Computer Science", Description = "An introduction to computer science" },
                new Course { Code = "CS102", Name = "Advanced Computer Science", Description = "An advanced course in computer science" },
            };
        }

        //returns list of courses (uses query if applicable)
        public List<Course> Courses
        {
            get
            {
                return courses.ToList();
            }
        }

        //adds course from frontend to the list
        public void AddOrUpdateCourse(Course course)
        {
            var existingCourse = courses.FirstOrDefault(c => c.guid == course.guid);
            if (existingCourse == null)
            {
                courses.Add(course);
            }
            else
            {
                var index = courses.IndexOf(existingCourse);
                courses[index] = course;
            }
        }

        public void AddStudentToCourse(Course course, Student student)
        {
            var existingCourse = courses.FirstOrDefault(c => c.guid == course.guid);
            if (existingCourse != null)
            {
                if (existingCourse.Roster.Contains(student))
                {
                    return;
                }
                else{
                    existingCourse.Roster.Add(student);
                }
            }
        }

        public void RemoveStudentFromCourse(Course course, Student student)
        {
            var existingCourse = courses.FirstOrDefault(c => c.guid == course.guid);
            if (existingCourse != null)
            {
                if (existingCourse.Roster.Contains(student))
                {
                    existingCourse.Roster.Remove(student);
                }
                else{
                    return;
                }
            }
        }

        public void Remove(Course course)
        {
            courses.Remove(course);
        }
    }
}