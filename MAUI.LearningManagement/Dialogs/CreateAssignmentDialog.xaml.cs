using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Dialogs;

public partial class CreateAssignmentDialog : ContentPage
{
    public CreateAssignmentDialog()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BindingContext = new CreateAssignmentDialogViewModel();
    }

    private void SaveClicked(object sender, EventArgs e)
    {
        (BindingContext as CreateAssignmentDialogViewModel)?.SaveAssignment();
        Shell.Current.GoToAsync("//CourseManagement");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CourseManagement");
    }
}