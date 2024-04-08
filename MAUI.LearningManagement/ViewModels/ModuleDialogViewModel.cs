using LMS.Models;
using LMS.Services;

namespace MAUI.LearningManagement.ViewModels
{
    public class ModuleDialogViewModel
    {
        public static Course CurrentCourse { get; set; }
        private Course course;
        private CourseService courseSvc;

        public ModuleDialogViewModel()
        {
            course = CurrentCourse;
            courseSvc = CourseService.Current;
            module = new Module();
        }

        private Module module;

        public string Name
        {
            get
            {
                return module.Name ?? string.Empty;
            }
            set
            {
                module.Name = value;
            }
        }

        public string Description
        {
            get
            {
                return module.Description ?? string.Empty;
            }
            set
            {
                module.Description = value;
            }
        }   

        public void SaveModule()
        {
            if (module != null)
            {
                courseSvc.AddModuleToCourse(course, module);
            }
        }
    }
}