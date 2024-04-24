using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Dialogs;

public partial class ViewAssignmentDialog : ContentPage
{
    public ViewAssignmentDialog()
    {
        InitializeComponent();
        BindingContext = new ViewAssignmentDialogViewModel();
    }

    private void GradeClicked(object sender, EventArgs e)
    { 
        Shell.Current.GoToAsync("//CourseDashboard");
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CourseDashboard");
    }
}