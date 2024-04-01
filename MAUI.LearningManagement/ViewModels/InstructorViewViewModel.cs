using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LMS.Models;
using LMS.Services;


namespace MAUI.LearningManagement.ViewModels
{
    public class InstructorViewViewModel : INotifyPropertyChanged
    {
        public InstructorViewViewModel()
        {
            studentService = StudentService.Current;
            Student = studentService.Students.FirstOrDefault();
        }
        private StudentService studentService;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
        
        /*public void AddStudent()
        {
            studentService.Add(new Student { Name = "New Student" });
            NotifyPropertyChanged(nameof(Students));
        }*/
    }

}
