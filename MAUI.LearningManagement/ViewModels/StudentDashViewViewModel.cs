using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LMS.Services;
using LMS.Models;
using Vision;
using System.Collections.ObjectModel;

namespace MAUI.LearningManagement.ViewModels
{
    public class StudentDashViewViewModel : INotifyPropertyChanged
    {
        public static Student CurrentStudent {get; set;}
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private CourseService courseSvc;

        public StudentDashViewViewModel()
        {
            courseSvc = CourseService.Current;
        }


        public ObservableCollection<Course> Courses
        {
            get
            {
                var filteredList = courseSvc
                    .Courses
                    .Where(c => c.Roster.Contains(CurrentStudent))
                    .ToList();
                return new ObservableCollection<Course>(filteredList);
            }
        }

        public Course? SelectedCourse { get; set; }

        public void Refresh()
        {
            OnPropertyChanged(nameof(Courses));
        }

    }
}