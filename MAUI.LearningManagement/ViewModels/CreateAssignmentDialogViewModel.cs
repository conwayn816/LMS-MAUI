using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LMS.Models;
using LMS.Services;
namespace MAUI.LearningManagement.ViewModels
{
    public class CreateAssignmentDialogViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


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