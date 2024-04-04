using LMS.Models;

namespace LMS.Services
{
    public class StudentService
    {
        //main list of all students
        private IList<Student> students;
        //stores the query
        private string query;

        //singleton pattern
        private static readonly object currentLock = new object();
        private static StudentService? instance;
        public static StudentService Current
        {
            get
            {
                lock (currentLock)
                {
                    if (instance == null)
                    {
                        instance = new StudentService();
                    }
                }
                return instance;
            }
        }

        //returns to front end list of Students (uses query if applicable)
        public List<Student> Students
        {
            get
            {
                return students.ToList();
            }
        }

        //default contructor only used in current
        private StudentService()
        {
            query = string.Empty;
            students = new List<Student>() {
                new Student{Name = "John Doe"},
                new Student{Name = "Jane Doe"},
            };
        }

        //takes in a Student from frontend and adds to list of Students
        public void AddOrUpdateStudent(Student student)
        {
            var existingStudent = students.FirstOrDefault(p => p.guid == student.guid);
            if (existingStudent != null)
            {
                var index = students.IndexOf(existingStudent);
                students[index] = student;
            }
            else
            {
                students.Add(student);
            }
        }

        public void Remove(Student student)
        {
            students.Remove(student);
        }

    }
}