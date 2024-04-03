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
    public class CourseManagementViewViewModel : INotifyPropertyChanged
    {
        public CourseManagementViewViewModel()
        {
            courseSvc = CourseService.Current;
        }
        private CourseService courseSvc;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //COURSES
        private Course? Course;

        public Course? course
        {
            get
            {
                return Course;
            }
        }

        public Course? SelectedCourse
        {
            get; set;
        }

        public ObservableCollection<Course> Courses
        {
            get
            {
                return new ObservableCollection<Course>(courseSvc.Courses);
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
