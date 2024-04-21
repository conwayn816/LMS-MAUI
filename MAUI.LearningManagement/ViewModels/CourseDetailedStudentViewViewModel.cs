using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LMS.Models;
using LMS.Services;

namespace MAUI.LearningManagement.ViewModels
{
    public class CourseDetailedStudentViewViewModel : INotifyPropertyChanged
    {
        public static Course? CurrentCourse { get; set; }
        public static Student? CurrentStudent { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //COURSES

        public string Code
        {
            get { return CurrentCourse?.Code ?? string.Empty; }
        }

        public string Name
        {
            get { return CurrentCourse?.Name ?? string.Empty; }
        }

        public string Description
        {
            get { return CurrentCourse?.Description ?? string.Empty; }
        }

        public ObservableCollection<Assignment>? Assignments
        {
            get
            {
                if (CurrentCourse != null)
                    return new ObservableCollection<Assignment>(CurrentCourse.Assignments);
                else
                    return null;
            }
        }

        public Assignment? SelectedAssignment { get; set; }

        public ObservableCollection<Module>? Modules
        {
            get
            {
                if (CurrentCourse == null)
                    return null;
                else
                    return new ObservableCollection<Module>(CurrentCourse.Modules);
            }
        }

        public CourseDetailedStudentViewViewModel()
        {
            
        }

        public async void SubmitAssignment()
        {
            if (SelectedAssignment != null)
            {
                SubmitAssignmentDialogViewModel.CurrentAssignment = SelectedAssignment;
                SubmitAssignmentDialogViewModel.CurrentCourse = CurrentCourse;
                SubmitAssignmentDialogViewModel.CurrentStudent = CurrentStudent;
                await Shell.Current.GoToAsync("//SubmitAssignmentDialog");
            }
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(CurrentCourse));
        }
    }
}