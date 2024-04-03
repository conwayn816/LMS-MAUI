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
    public class CourseDetailedViewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //COURSES
        private Course? course;

        public Course? Course
        {
            get { return course; }
            set
            {
                course = value;
                NotifyPropertyChanged();
            }
        }

        public string Code
        {
            get { return course?.Code ?? string.Empty; }
        }

        public string Name
        {
            get { return course?.Name ?? string.Empty; }
        }

        public string Description
        {
            get { return course?.Description ?? string.Empty; }
        }

        public ObservableCollection<Student>? Roster
        {
            get { return new ObservableCollection<Student>(course.Roster); }
        }

        public ObservableCollection<Assignment>? Assignments
        {
            get { return new ObservableCollection<Assignment>(course.Assignments); }
        }

        public ObservableCollection<Module>? Modules
        {
            get { return new ObservableCollection<Module>(course.Modules); }
        }

        public CourseDetailedViewViewModel(Course courseSelected)
        {
            this.Course = courseSelected;
        }
        
        public void Refresh()
        {
            NotifyPropertyChanged(nameof(course));  
        }
            
        
    }
}