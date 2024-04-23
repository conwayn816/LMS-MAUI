using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Dialogs;

public partial class ViewAssignmentDialog : ContentPage
{
    public ViewAssignmentDialog()
    {
        InitializeComponent();

    }

    private void GradeClicked(object sender, EventArgs e)
    {
        
        Shell.Current.GoToAsync("//CourseDetailedView");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CourseDetailedView");
    }
}