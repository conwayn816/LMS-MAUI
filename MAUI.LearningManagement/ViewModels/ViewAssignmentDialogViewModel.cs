using System.Collections.ObjectModel;
using LMS.Models;
using LMS.Services;
namespace MAUI.LearningManagement.ViewModels
{
    public class ViewAssignmentDialogViewModel
    {
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
            if (SelectedSubmission == null)
                return;
            else
            {
                GradeAssignmentDialogViewModel.CurrentAssignment = CurrentAssignment;
                GradeAssignmentDialogViewModel.CurrentCourse = CurrentCourse;
                GradeAssignmentDialogViewModel.CurrentSubmission = SelectedSubmission;

                Shell.Current.GoToAsync($"//GradeAssignmentDialog");
            }
        }
    }
}