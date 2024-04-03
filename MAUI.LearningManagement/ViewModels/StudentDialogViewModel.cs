
using LMS.Models;
using LMS.Services;

namespace MAUI.LearningManagement.ViewModels
{
    public class StudentDialogViewModel
    {
        private Student? student;

        public int Id
        {
            get { return student.Id; }
            set { student.Id = value; }
        }

        public string Name
        {
            get { return student.Name ?? string.Empty; }
            set { student.Name = value; }
        }

        public StudentDialogViewModel(Student studentToEdit = null)
        {
            this.student = studentToEdit ?? new Student();
        }

        public void AddOrUpdateStudent()
        {
            if (student != null)
            {
                StudentService.Current.AddOrUpdateStudent(student);
            }
        }
    }
}