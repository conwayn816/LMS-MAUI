using MAUI.LearningManagement.ViewModels;
using LMS.Models;

namespace MAUI.LearningManagement.Dialogs;

public partial class CreateAssignmentDialog : ContentPage
{
    public CreateAssignmentDialog()
    {
        InitializeComponent();
        //BindingContext = new CreateAssignmentDialogViewModel();
    }

    private void SaveClicked(object sender, EventArgs e)
    {
        // (BindingContext as CreateAssignmentDialogViewModel)?.SaveAssignment();
        Shell.Current.GoToAsync("//CourseManagement");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CourseManagement");
    }
}