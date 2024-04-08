using MAUI.LearningManagement.ViewModels;
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
        (BindingContext as CourseDetailedViewViewModel)?.UnenrollStudent();
    }

    private void CreateAssignmentClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDetailedViewViewModel)?.OpenCreateAssignmentDialog();
    }

    private void CreateModuleClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDetailedViewViewModel)?.OpenModuleDialog();
    }

    private void CreateContentItemClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDetailedViewViewModel)?.OpenContentItemDialog();
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