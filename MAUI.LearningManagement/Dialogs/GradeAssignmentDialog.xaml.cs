using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Dialogs;

public partial class GradeAssignmentDialog : ContentPage
{
    public GradeAssignmentDialog()
    {
        InitializeComponent();
    }

    private void SaveClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CourseDetailedView");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CourseDetailedView");
    }
}