using MAUI.LearningManagement.ViewModels;
using LMS.Models;

namespace MAUI.LearningManagement.Dialogs
{
    public partial class EnrollStudentDialog : ContentPage
    {
        public EnrollStudentDialog()
        {
            InitializeComponent();
            BindingContext = new EnrollStudentDialogViewModel();
        }

        private void ContentPage_NavigatedTo(object sender, EventArgs e)
        {
            (BindingContext as EnrollStudentDialogViewModel)?.Refresh();
        }

        private void SaveClicked(object sender, EventArgs e)
        {
            (BindingContext as EnrollStudentDialogViewModel)?.EnrollStudent();
        }

        private void DoneClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//CourseManagement");
        }
    }
}
