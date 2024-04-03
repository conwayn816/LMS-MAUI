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
    public class StudentManagementViewViewModel : INotifyPropertyChanged
    {
        public StudentManagementViewViewModel()
        {
            studentSvc = StudentService.Current;
        }
        private StudentService studentSvc;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        //STUDENTS
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
                return new ObservableCollection<Student>(studentSvc.Students);
            }
        }

        public Student? SelectedStudent
        {
            get; set;
        }

        public void RemoveStudent()
        {
            if (SelectedStudent == null)
            {
                return;
            }
            studentSvc.Remove(SelectedStudent);
            Refresh();
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Students));
        }
    }
}
