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

        private string _query;

        public string Query 
        {
            get => _query;
            set
            {
                if (_query == value)
                    return;

                _query = value;
                OnPropertyChanged();
            }
        }

        private CourseService courseSvc;
        private StudentService studentSvc;

        public StudentDashViewViewModel()
        {
            _query = string.Empty;
            courseSvc = CourseService.Current;
            studentSvc = StudentService.Current;
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

        public void Refresh()
        {
            OnPropertyChanged(nameof(Courses));
        }

    }
}