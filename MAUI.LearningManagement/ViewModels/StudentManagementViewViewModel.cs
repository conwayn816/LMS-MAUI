using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LMS.Models;
using LMS.Services;

namespace MAUI.LearningManagement.ViewModels
{
    public class StudentManagementViewViewModel : INotifyPropertyChanged
    {
        public StudentManagementViewViewModel()
        {
            studentSvc = StudentService.Current;
            query = string.Empty;
        }
        private StudentService studentSvc;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        //STUDENTS
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
