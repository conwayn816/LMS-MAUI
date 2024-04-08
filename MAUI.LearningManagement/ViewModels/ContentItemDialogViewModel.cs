using LMS.Models;
using LMS.Services;

namespace MAUI.LearningManagement.ViewModels
{
    public class ContentItemDialogViewModel
    {
        public static Course CurrentCourse { get; set; }
        public static Module CurrentModule { get; set; }

        private Module module;
        private Course course;
        private CourseService courseSvc;

        private ContentItem contentItem;

        public ContentItemDialogViewModel()
        {
            course = CurrentCourse;
            courseSvc = CourseService.Current;
            module = CurrentModule;
            contentItem = new ContentItem();
        }

        public string Name
        {
            get
            {
                return contentItem.Name ?? string.Empty;
            }
            set
            {
                contentItem.Name = value;
            }
        }

        public string Description
        {
            get
            {
                return contentItem.Description ?? string.Empty;
            }
            set
            {
                contentItem.Description = value;
            }
        }

        public void SaveContentItem()
        {
            if (contentItem != null)
            {
                courseSvc.AddContentItemToCourse(course, module, contentItem);
            }
        }
    }
}