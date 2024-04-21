using LMS.Models;
using LMS.Services;
namespace MAUI.LearningManagement.ViewModels
{
    public class SubmitAssignmentDialogViewModel
    {
        private CourseService courseSvc;

        public SubmitAssignmentDialogViewModel()
        {
            courseSvc = CourseService.Current;
            content = string.Empty;
        }
        public static Assignment? CurrentAssignment { get; set; }
        public static Course? CurrentCourse { get; set; }
        public static Student? CurrentStudent { get; set; } 

        public string Name
        {
            get
            {
                return CurrentAssignment?.Name ?? string.Empty;
            }
        }

        public string Description
        {
            get
            {
                return CurrentAssignment?.Description ?? string.Empty;
            }
        }

        public DateTime DueDate
        {
            get
            {
                return CurrentAssignment.DueDate;
            }
        }

        public decimal Points
        {
            get
            {
                return CurrentAssignment.TotalAvailablePoints;
            }
        }

        private string content;

        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }

        public void SaveAssignment()
        {
            var submission = new Submission
            {
                Content = Content,
                studentGuid = CurrentStudent.guid,
                Points = 0
            };
            courseSvc.SubmitAssignment(CurrentCourse, CurrentAssignment, submission);
        }
    }
}