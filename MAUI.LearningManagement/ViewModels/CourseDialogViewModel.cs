using LMS.Models;
using LMS.Services;

namespace MAUI.LearningManagement.ViewModels
{
    public class CourseDialogViewModel
    {
        private Course? course;

        public string Code
        {
            get { return course?.Code ?? string.Empty; }
            set
            {
                if (course == null) course = new Course();
                course.Code = value;
            }
        }

        public string Name
        {
            get { return course?.Name ?? string.Empty; }
            set
            {
                if (course == null) course = new Course();
                course.Name = value;
            }
        }

        public string Description
        {
            get { return course?.Description ?? string.Empty; }
            set
            {
                if (course == null) course = new Course();
                course.Description = value;
            }
        }

        public CourseDialogViewModel()
        {
            course = new Course();
        }

        public void AddCourse()
        {
            if (course != null)
            {
                CourseService.Current.Add(course);
            }
        }
    }
}