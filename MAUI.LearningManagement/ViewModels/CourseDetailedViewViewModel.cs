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
using MAUI.LearningManagement.Dialogs;

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
            get { 
                if (course == null)
                    return null;
                else
                    return new ObservableCollection<Student>(course.Roster); 
            }
        }

        public Student? SelectedStudent
        {
            get; set;
        }


        public ObservableCollection<Assignment>? Assignments
        {
            get { 
                if (course != null)
                    return new ObservableCollection<Assignment>(course.Assignments); 
                else
                    return null;
            }
        }

        public ObservableCollection<Module>? Modules
        {
            get { 
                if (course == null)
                    return null;
                else
                    return new ObservableCollection<Module>(course.Modules); 
            }
        }

        public CourseDetailedViewViewModel(Course courseSelected)
        {
            if (courseSelected == null)
            {
                throw new ArgumentNullException(nameof(courseSelected));
            }
            this.Course = courseSelected;
        }

        public async void OpenCreateAssignmentDialog()
        {
            if (Course == null)
            {
                return;
            }
            else
            {
                CreateAssignmentDialogViewModel.CurrentCourse = Course;
                try
                {
                    await Shell.Current.GoToAsync("//CreateAssignment");
                }
                catch (Exception ex)
                {
                    // Log or handle the exception
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public async void OpenEnrollStudentDialog()
        {
            if (Course == null)
            {
                return;
            }
            else
            {
                EnrollStudentDialogViewModel.CurrentCourse = Course;
                try
                {
                    await Shell.Current.GoToAsync("//EnrollStudent");
                }
                catch (Exception ex)
                {
                    // Log or handle the exception
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void UnenrollStudent()
        {
            if (SelectedStudent != null)
            {
                if (Course == null)
                {
                    return;
                }
                else{
                    CourseService.Current.RemoveStudentFromCourse(Course, SelectedStudent);
                    NotifyPropertyChanged(nameof(Roster));
                }
            }
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(course));
        }


    }
}