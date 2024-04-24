using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LMS.Models;
using LMS.Services;
namespace MAUI.LearningManagement.ViewModels
{
    public class ViewAssignmentDialogViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Description));
            NotifyPropertyChanged(nameof(DueDate));
            NotifyPropertyChanged(nameof(Points));
            NotifyPropertyChanged(nameof(Submissions));
        }


        private CourseService courseSvc;
        private StudentService studentSvc;

        public ViewAssignmentDialogViewModel()
        {
            courseSvc = CourseService.Current;
            studentSvc = StudentService.Current;
        }
        public static Assignment? CurrentAssignment { get; set; }
        public static Course? CurrentCourse { get; set; }

        public string Name
        {
            get { return CurrentAssignment?.Name ?? string.Empty; }
        }

        public string Description
        {
            get { return CurrentAssignment?.Description ?? string.Empty; }
        }

        public string DueDate
        {
            get { return CurrentAssignment?.DueDate.ToString() ?? string.Empty; }
        }

        public string Points
        {
            get { return CurrentAssignment?.TotalAvailablePoints.ToString() ?? string.Empty; }
        }

        public ObservableCollection<Submission>? Submissions
        {
            get
            {
                if (CurrentAssignment == null)
                    return null;
                else
                    return new ObservableCollection<Submission>(CurrentAssignment.Submissions);
            }
        }

        public Submission? SelectedSubmission { get; set; }

        public void GradeAssignment()
        {
            if (SelectedSubmission != null)
            {
                GradeAssignmentDialogViewModel.CurrentAssignment = CurrentAssignment;
                GradeAssignmentDialogViewModel.CurrentCourse = CurrentCourse;
                GradeAssignmentDialogViewModel.CurrentSubmission = SelectedSubmission;
                Shell.Current.GoToAsync("//GradeAssignmentDialog");
            }
        }
    }
}