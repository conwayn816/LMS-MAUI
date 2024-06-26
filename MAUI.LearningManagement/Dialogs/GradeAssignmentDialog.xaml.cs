using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Dialogs;

public partial class GradeAssignmentDialog : ContentPage
{
    public GradeAssignmentDialog()
    {
        InitializeComponent();
        BindingContext = new GradeAssignmentDialogViewModel();
    }

    private void SaveClicked(object sender, EventArgs e)
    {
        (BindingContext as GradeAssignmentDialogViewModel)?.SaveGrade();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//CourseManagement");
    }

    private void ContentPage_NavigatedTo(object sender, NavigationEventArgs e)
    {
        (BindingContext as GradeAssignmentDialogViewModel)?.Refresh();
    }
}