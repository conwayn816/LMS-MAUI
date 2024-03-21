using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using LMS.Services;
using LMS.Models;
using System.Collections.ObjectModel;

namespace MAUI.LearningManagement.ViewModels
{
    public class InstructorViewViewModel
    {
        private Student? Student;

        public Student? student 
        {
            get
            {
                return Student;
            }
        }

        public ObservableCollection<Student> Students
        {
            get
            {
                return new ObservableCollection<Student>(studentService.Students);
            }
        }
        private StudentService studentService;

        public InstructorViewViewModel()
        {
            studentService = StudentService.Current;
        }
    }

}
