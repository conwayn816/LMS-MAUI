using MAUI.LearningManagement.ViewModels;
using LMS.Models;

namespace MAUI.LearningManagement.Dialogs;

public partial class StudentDialog : ContentPage
{
    public StudentDialog(Student studentToEdit = null)
    {
        InitializeComponent();
        BindingContext = new StudentDialogViewModel(studentToEdit);
    }

    private void SaveClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentDialogViewModel)?.AddOrUpdateStudent();
        Shell.Current.GoToAsync("//StudentManagement");
    }
    
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentManagement");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {

    }
}
