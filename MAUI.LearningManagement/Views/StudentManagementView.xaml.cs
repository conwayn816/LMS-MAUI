using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Views;

public partial class StudentManagementView : ContentPage
{
    
        public StudentManagementView()
        {
            InitializeComponent();
            BindingContext = new StudentManagementViewViewModel();
        }
    
        private void GoBackClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Instructor");
        }
    
        private void AddStudentClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//StudentDetail");
        }
    
        private void RemoveStudentClicked(object sender, EventArgs e)
        {
            (BindingContext as StudentManagementViewViewModel)?.RemoveStudent();
        }
    
        private void ContentPage_NavigatedTo(object sender, EventArgs e)
        {
            (BindingContext as StudentManagementViewViewModel)?.Refresh();
        }
}