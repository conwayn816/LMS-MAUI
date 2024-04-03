using MAUI.LearningManagement.ViewModels;
using MAUI.LearningManagement.Dialogs;
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

        private async void EditStudentClicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as StudentManagementViewViewModel;
            if (viewModel != null)
            {
                var selectedStudent = viewModel.SelectedStudent;
                if (selectedStudent != null)
                {
                    var studentDialogViewModel = new StudentDialogViewModel(selectedStudent);
                    var studentDialog = new StudentDialog { BindingContext = studentDialogViewModel };
                    await Shell.Current.Navigation.PushModalAsync(studentDialog);
                }
                else
                {
                    await DisplayAlert("Error", "Please select a student to edit", "OK");
                }
            }
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