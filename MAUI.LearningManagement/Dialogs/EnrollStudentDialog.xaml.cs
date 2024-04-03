using MAUI.LearningManagement.ViewModels;
using LMS.Models;

namespace MAUI.LearningManagement.Dialogs;

public partial class EnrollStudentDialog : ContentPage
{
    public EnrollStudentDialog(Course courseToEnroll)
    {
        InitializeComponent();
        BindingContext = new EnrollStudentDialogViewModel(courseToEnroll);
    }

    private void SaveClicked(object sender, EventArgs e)
    {
        (BindingContext as EnrollStudentDialogViewModel)?.AddToRoster();
        Shell.Current.GoToAsync("..");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void ContentPage_NavigatedTo(object sender, NavigationEventArgs e)
    {
        (BindingContext as EnrollStudentDialogViewModel)?.Refresh();
    }

}
