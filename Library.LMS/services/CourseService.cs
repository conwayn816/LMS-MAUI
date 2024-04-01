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
            courses = new List<Course>();
        }

        //returns list of courses (uses query if applicable)
        public IList<Course> Courses
        {
            get
            {
            
                return courses.Where(
                    c =>
                        c.Code.Contains(query ?? string.Empty, StringComparison.CurrentCultureIgnoreCase)
                        || c.Name.Contains(query ?? string.Empty, StringComparison.CurrentCultureIgnoreCase)
                        || c.Description.Contains(query ?? string.Empty, StringComparison.CurrentCultureIgnoreCase)).ToList();
            
            }
        }

        //searches for a course by name
        public IList<Course> Search(string query)
        {
            this.query = query;
            return Courses;
        }

        //adds course from frontend to the list
        public void Add(Course course)
        {
            courses.Add(course);
        }
    }
}