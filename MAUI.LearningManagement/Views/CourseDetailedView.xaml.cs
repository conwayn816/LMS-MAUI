using MAUI.LearningManagement.ViewModels;
using MAUI.LearningManagement.Dialogs;
using LMS.Models;

namespace MAUI.LearningManagement.Views;

public partial class CourseDetailedView : ContentPage
{
    public CourseDetailedView(Course courseSelected)
    {
        InitializeComponent();
        BindingContext = new CourseDetailedViewViewModel(courseSelected);
    }

    private void EnrollClicked(object sender, EventArgs e)
    {
        // use the OpenEnrollStudentDialog to enroll a student
        (BindingContext as CourseDetailedViewViewModel)?.OpenEnrollStudentDialog();
    }

    private void UnenrollClicked(object sender, EventArgs e)
    {

    }

    private void CreateAssignmentClicked(object sender, EventArgs e)
    {

    }

    private void CreateModuleClicked(object sender, EventArgs e)
    {

    }

    private void CreateContentItemClicked(object sender, EventArgs e)
    {

    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CourseManagement");
    }

    private void ContentPage_NavigatedTo(object sender, EventArgs e)
    {
        (BindingContext as CourseDetailedViewViewModel)?.Refresh();
    }
}