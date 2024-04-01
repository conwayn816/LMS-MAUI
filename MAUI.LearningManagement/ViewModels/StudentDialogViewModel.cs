
using LMS.Models;
using LMS.Services;

namespace MAUI.LearningManagement.ViewModels
{
    public class StudentDialogViewModel
    {
        private Student? student;

        public int Id
        {
            get { return student?.Id ?? 0; }
            set
            {
                if (student == null) student = new Student();
                student.Id = value;
            }
        }

        public string Name
        {
            get { return student?.Name ?? string.Empty; }
            set
            {
                if (student == null) student = new Student();
                student.Name = value;
            }
        }

        public StudentDialogViewModel()
        {
            student = new Student();
        }

        public void AddStudent()
        {
            if (student != null)
            {
                StudentService.Current.Add(student);
            }
        }
    }
}