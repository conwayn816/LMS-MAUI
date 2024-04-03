/*using LMS.Models;
using LMS.Services;

namespace LMS.Helpers
{
    public class CourseHelper
    {
        private CourseService courseService;
        private StudentService studentService;

        public CourseHelper()
        {
            courseService = CourseService.Current;
            studentService = StudentService.Current;
        }

        //creates a new course
        public void AddUpdateCourseRecord(Course? selectedCourse = null)
        {
            Console.WriteLine("Enter course code: ");
            var code = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter course name: ");
            var name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter course description: ");
            var description = Console.ReadLine() ?? string.Empty;


            //add students
            Console.WriteLine("Which students should be enrolled in this course ('Q' to quit)?");
            var roster = new List<Student>();
            bool continueAdding = true;
            while (continueAdding)
            {
                studentService.Students.Where(s => !roster.Any(s2 => s2.Id == s.Id)).ToList().ForEach(s => Console.WriteLine(s.ToString()));
                //default to Q
                var selection = Console.ReadLine() ?? "Q";

                //kill condition
                if (selection.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    continueAdding = false;
                }
                else
                {
                    var selectedId = int.Parse(selection);
                    var selectedStudent = studentService.Students.FirstOrDefault(s => s.Id == selectedId);
                    if (selectedStudent != null)
                    {
                        roster.Add(selectedStudent);
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection");
                    }
                }
            }

            //check if adding assignments
            var assignments = new List<Assignment>();
            Console.WriteLine("Would you like to add assignments to this course (Y/N)?");
            var assignmentResponse = Console.ReadLine() ?? "N";
            if (assignmentResponse.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                //add assignments
                continueAdding = true;
                while (continueAdding)
                {
                    //Name
                    Console.WriteLine("Name: ");
                    var aName = Console.ReadLine() ?? string.Empty;
                    //Description
                    Console.WriteLine("Description: ");
                    var aDescription = Console.ReadLine() ?? string.Empty;
                    //TotalAvailablePoints
                    Console.WriteLine("Total Points: ");
                    var totalPoints = decimal.Parse(Console.ReadLine() ?? "100");
                    //DueDate
                    Console.WriteLine("Due Date: ");
                    var dueDate = DateTime.Parse(Console.ReadLine() ?? "01/01/1900");

                    assignments.Add(new Assignment
                    {
                        Name = aName,
                        Description = aDescription,
                        TotalAvailablePoints = totalPoints,
                        DueDate = dueDate
                    });

                    Console.WriteLine("Would you like to add another assignment (Y/N)?");
                    assignmentResponse = Console.ReadLine() ?? "N";
                    if (assignmentResponse.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                    {
                        continueAdding = false;
                    }
                }
            }


            var isNew = false;
            if (selectedCourse == null)
            {
                isNew = true;
                selectedCourse = new Course();
            }
            //update info
            selectedCourse.Code = code;
            selectedCourse.Name = name;
            selectedCourse.Description = description;
            selectedCourse.Roster = new List<Student>();
            selectedCourse.Roster.AddRange(roster);
            selectedCourse.Assignments = new List<Assignment>();
            selectedCourse.Assignments.AddRange(assignments);


            //add course if new
            if (isNew)
            {
                courseService.Add(selectedCourse);
            }
        }

        //search course by code, name, or description
        //if no query is provided, list all courses
        //user can choose course from output to view details
        public void SearchCourses(string? query = null)
        {
            if (string.IsNullOrEmpty(query))
            {
                courseService.Courses.ToList().ForEach(Console.WriteLine);
            }
            else{
                courseService.Search(query).ToList().ForEach(Console.WriteLine);
            } 

            Console.WriteLine("Select a Course: ");
            var code = Console.ReadLine() ?? string.Empty;

            var selectedCourse = courseService
                .Courses
                .FirstOrDefault(c => c.Code.Equals(code, StringComparison.OrdinalIgnoreCase));

            if (selectedCourse != null)
            {
                Console.WriteLine(selectedCourse.DetailDisplay);
            }
        }

        public void UpdateCourseRecord()
        {
            Console.WriteLine("Enter the code of the course to update: ");
            SearchCourses();
            Console.WriteLine("Select a course to update: ");
            var selection = Console.ReadLine() ?? string.Empty;

            var selectedCourse = CourseService.Current.Courses.FirstOrDefault(c => c.Code.Equals(selection, StringComparison.InvariantCultureIgnoreCase));
            if (selectedCourse != null)
            {
                AddUpdateCourseRecord(selectedCourse);
            }
            else
            {
                Console.WriteLine("Invalid selection");
            }

        }
    }
}*/