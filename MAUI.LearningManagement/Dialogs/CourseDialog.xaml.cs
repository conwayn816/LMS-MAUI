using MAUI.LearningManagement.ViewModels;
using LMS.Models;

namespace MAUI.LearningManagement.Dialogs;

public partial class CourseDialog : ContentPage
{
    public CourseDialog(Course courseToEdit = null)
    {
        InitializeComponent();
        BindingContext = new CourseDialogViewModel(courseToEdit);
    }

    private void SaveClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.AddOrUpdateCourse();
        Shell.Current.GoToAsync("//CourseManagement");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CourseManagement");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {

    }
}
