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
                var filteredList = studentSvc
                    .Students
                    .Where(
                        s => s.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty)).ToList();
                    return new ObservableCollection<Student>(filteredList);
            }
        }

        public Student? SelectedStudent
        {
            get; set;
        }

        private string query;

        public string Query 
        {
            get { return query; }
            set
            {
                query = value;
                NotifyPropertyChanged(nameof(Students));
            }
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
