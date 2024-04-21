using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Dialogs;

public partial class SubmitAssignmentDialog : ContentPage
{
    public SubmitAssignmentDialog()
    {
        InitializeComponent();
        BindingContext = new SubmitAssignmentDialogViewModel();
    }

    private void SaveClicked(object sender, EventArgs e)
    {
        (BindingContext as SubmitAssignmentDialogViewModel)?.SaveAssignment();
        Shell.Current.GoToAsync("//StudentDashboard");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentDashboard");
    }
}