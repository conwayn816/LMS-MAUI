/*using LMS.Services;
using LMS.Models;
using Microsoft.VisualBasic;

namespace LMS.Helpers
{
    internal class StudentHelper
    {
        private StudentService studentService;
        private CourseService courseService;

        public StudentHelper()
        {
            studentService = StudentService.Current;
            courseService = CourseService.Current;
        }


        //gets info about a new student from user and creates a student that gets added to student list
        public void AddUpdateStudentRecord(Student? selectedStudent = null)
        {
            Console.WriteLine("Enter student id: ");
            var id = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Enter student name: ");
            var name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter classification (F)reshman, S(O)phmore, (J)unior, (S)enior: ");
            var classification = Console.ReadLine() ?? string.Empty;
            StudentClassifcation classEnum;

            if (classification.Equals("F", StringComparison.OrdinalIgnoreCase))
                classEnum = StudentClassifcation.Freshman;
            else if (classification.Equals("O", StringComparison.OrdinalIgnoreCase))
                classEnum = StudentClassifcation.Sophomore;
            else if (classification.Equals("J", StringComparison.OrdinalIgnoreCase))
                classEnum = StudentClassifcation.Junior;
            else if (classification.Equals("S", StringComparison.OrdinalIgnoreCase))
                classEnum = StudentClassifcation.Senior;
            else
                throw new Exception("Invalid classification");

            //check if new student needs to be created
            var isNew = false;
            if (selectedStudent == null)
            {
                isNew = true;
                selectedStudent = new Student();
            }
            //update info
            selectedStudent.Id = id;
            selectedStudent.Name = name;
            selectedStudent.Classification = classEnum;
            //add student if new
            if (isNew)
                studentService.Add(selectedStudent);

        }

        //lists all students
        public void ListStudents()
        {
            studentService.Students.ForEach(Console.WriteLine);

            Console.WriteLine("Select a student: ");
            var selectionStr = Console.ReadLine() ?? string.Empty;
            var selectionInt = int.Parse(selectionStr ?? "0");

            Console.WriteLine("Courses for student: ");
            courseService.Courses.Where(c => c.Roster.Any(s => s.Id == selectionInt)).ToList().ForEach(Console.WriteLine);

        }


        //search student list by name
        public void SearchStudents()
        {
            Console.WriteLine("Enter search query: ");
            var query = Console.ReadLine() ?? string.Empty;
            studentService.Search(query).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("Select a student: ");
            var selectionStr = Console.ReadLine() ?? string.Empty;
            var selectionInt = int.Parse(selectionStr ?? "0");

            Console.WriteLine("Courses for student: ");
            courseService.Courses.Where(c => c.Roster.Any(s => s.Id == selectionInt)).ToList().ForEach(Console.WriteLine);
        }

        //update student record
        public void UpdateStudentRecord()
        {
            Console.WriteLine("Select a student to update: ");
            studentService.Search(string.Empty).ToList().ForEach(Console.WriteLine);

            var selection = Console.ReadLine() ?? string.Empty;

            if (int.TryParse(selection, out int selectionId))
            {
                var selectedStudent = StudentService.Current.Students.FirstOrDefault(s => s.Id == selectionId);
                if (selectedStudent != null)
                {
                    AddUpdateStudentRecord(selectedStudent);
                }
                else
                {
                    Console.WriteLine("Invalid selection");
                }
            }

        }

    }
}*/