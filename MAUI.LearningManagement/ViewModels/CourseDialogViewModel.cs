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
                if (course != null)
                    course.Code = value;
            }
        }

        public string Name
        {
            get { return course?.Name ?? string.Empty; }
            set
            {
                if (course != null)
                    course.Name = value;
            }
        }

        public string Description
        {
            get { return course?.Description ?? string.Empty; }
            set
            {
                if (course != null)
                    course.Description = value;
            }
        }

        public CourseDialogViewModel(Course? courseToEdit = null)
        {
            this.course = courseToEdit ?? new Course();
        }

        public void AddOrUpdateCourse()
        {
            if (course != null)
            {
                CourseService.Current.AddOrUpdateCourse(course);
            }
        }
    }
}