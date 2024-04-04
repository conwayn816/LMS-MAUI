using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LMS.Models;
using LMS.Services;

namespace MAUI.LearningManagement.ViewModels
{
    public class CourseManagementViewViewModel : INotifyPropertyChanged
    {
        public CourseManagementViewViewModel()
        {
            query = string.Empty;
            courseSvc = CourseService.Current;
        }
        private CourseService courseSvc;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //COURSES
        public Course? SelectedCourse
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
                NotifyPropertyChanged(nameof(Courses));
            }
        }

        public ObservableCollection<Course> Courses
        {
            get
            {
                var filteredList = courseSvc
                    .Courses
                    .Where(
                        c => c.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty)
                        || c.Description.ToUpper().Contains(Query?.ToUpper() ?? string.Empty)
                        || c.Code.ToUpper().Contains(Query?.ToUpper() ?? string.Empty)).ToList();
                return new ObservableCollection<Course>(filteredList);
            }
        }

        public void RemoveCourse()
        {
            if (SelectedCourse == null)
            {
                return;
            }
            courseSvc.Remove(SelectedCourse);
            Refresh();
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Courses));
        }
    }
}
