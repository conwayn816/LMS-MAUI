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
    public class EnrollStudentDialogViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Students));
            NotifyPropertyChanged(nameof(Roster));
            NotifyPropertyChanged(nameof(CurrentCourse));
        }

        private Course course;
        private Student? selectedStudent;
        private CourseService courseSvc;
        private StudentService studentSvc;

        public EnrollStudentDialogViewModel()
        {
            course = CurrentCourse;
            courseSvc = CourseService.Current;
            studentSvc = StudentService.Current;
        }

        public static Course CurrentCourse
        {
            get; set;
        }

        public ObservableCollection<Student> Roster
        {
            get
            {
                return new ObservableCollection<Student>(CurrentCourse.Roster);
            }
        }

        public ObservableCollection<Student> Students
        {
            get
            {
                return new ObservableCollection<Student>(studentSvc.Students.Except(Roster));
            }
        }

        public Student? SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                if (selectedStudent != value)
                {
                    selectedStudent = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public void EnrollStudent()
        {
            if (selectedStudent != null)
            {
                courseSvc.AddStudentToCourse(CurrentCourse, selectedStudent);
                NotifyPropertyChanged(nameof(Students));
                NotifyPropertyChanged(nameof(Roster));
            }
        }
    }
}