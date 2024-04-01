using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Dialogs;

public partial class StudentDialog : ContentPage
{
    public StudentDialog()
    {
        InitializeComponent();
        BindingContext = new StudentDialogViewModel();
    }
    
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }
}
