using LMS.Models;
using LMS.Services;
namespace MAUI.LearningManagement.ViewModels
{
    public class CreateAssignmentDialogViewModel
    {
        private Course course;
        private CourseService courseSvc;

        public CreateAssignmentDialogViewModel()
        {
            course = CurrentCourse;
            courseSvc = CourseService.Current;
            assignment = new Assignment();
        }
        private Assignment assignment;
        public static Course CurrentCourse { get; set; }

        public string Name { 
            get{
                return assignment.Name ?? string.Empty;
            } 
            set{
                assignment.Name = value;
            } 
        }

        public string Description { 
            get{
                return assignment.Description ?? string.Empty;
            } 
            set{
                assignment.Description = value;
            } 
        }

        public DateTime DueDate { 
            get{
                return assignment.DueDate;
            } 
            set{
                assignment.DueDate = value;
            } 
        }

        public decimal Points { 
            get{
                return assignment.TotalAvailablePoints;
            } 
            set{
                assignment.TotalAvailablePoints = value;
            } 
        }

        public void SaveAssignment()
        {
            if (assignment != null)
            {
                courseSvc.AddAssignmentToCourse(course, assignment);
            }
        }
    }
}