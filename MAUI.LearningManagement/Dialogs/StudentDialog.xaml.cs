using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Dialogs;

public partial class StudentDialog : ContentPage
{
    public StudentDialog()
    {
        InitializeComponent();
    }

    private void SaveClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentDialogViewModel)?.AddStudent();
        Shell.Current.GoToAsync("//StudentManagement");
    }
    
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentManagement");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new StudentDialogViewModel();
    }
}
