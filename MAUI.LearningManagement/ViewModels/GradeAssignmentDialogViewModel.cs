using System.Collections.ObjectModel;
using LMS.Models;
using LMS.Services;
namespace MAUI.LearningManagement.ViewModels
{
    public class GradeAssignmentDialogViewModel
    {
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