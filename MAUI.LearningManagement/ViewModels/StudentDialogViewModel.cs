
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

        public string ClassificationString
        {
            get { return classificationString ?? string.Empty; }
            set { classificationString = value; }
        }

        private string classificationString = string.Empty;

        public StudentDialogViewModel(Student studentToEdit = null)
        {
            this.student = studentToEdit ?? new Student();
        }

        public void AddOrUpdateStudent()
        {
            if (student != null)
            {
                TranslateClassificationString();
                StudentService.Current.AddOrUpdateStudent(student);
            }
        }

        public void TranslateClassificationString()
        {
            if (student != null)
            {
                if (ClassificationString == "F")
                    student.Classification = StudentClassifcation.Freshman;
                else if (ClassificationString == "O")
                    student.Classification = StudentClassifcation.Sophomore;
                else if (ClassificationString == "J")
                    student.Classification = StudentClassifcation.Junior;
                else if (ClassificationString == "S")
                    student.Classification = StudentClassifcation.Senior;
            }
        }   
    }
}