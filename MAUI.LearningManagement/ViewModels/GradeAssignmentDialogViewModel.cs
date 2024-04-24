using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using LMS.Models;
using LMS.Services;
namespace MAUI.LearningManagement.ViewModels
{
    public class GradeAssignmentDialogViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(AssignmentName));
            NotifyPropertyChanged(nameof(StudentName));
            NotifyPropertyChanged(nameof(Content));
            NotifyPropertyChanged(nameof(Grade));
        }

        private CourseService courseSvc;
        private StudentService studentSvc;

        public GradeAssignmentDialogViewModel()
        {
            courseSvc = CourseService.Current;
            studentSvc = StudentService.Current;
        }
        public static Submission? CurrentSubmission { get; set; }
        public static Assignment? CurrentAssignment { get; set; }
        public static Course? CurrentCourse { get; set; }

        public string AssignmentName
        {
            get { return CurrentAssignment?.Name ?? string.Empty; }
        }

        public string StudentName
        {
            get { 
                var student = studentSvc.Students.Find(s => s.guid == CurrentSubmission?.studentGuid);
                return student?.Name ?? string.Empty;
            }
        }

        public string Content
        {
            get { return CurrentSubmission?.Content ?? string.Empty; }
        }

        private int _grade;

        public string Grade
        {
            get { return _grade.ToString() ?? string.Empty; }
            set
            {
                if (int.TryParse(value, out int grade))
                {
                    _grade = grade;
                }
            }
        }

        public void SaveGrade()
        {
            courseSvc.GradeAssignment(CurrentCourse, CurrentAssignment, CurrentSubmission, _grade);
            Shell.Current.GoToAsync($"//CourseManagement");
        }
    }
}