using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Views;

public partial class CourseManagementView : ContentPage
{
    public CourseManagementView()
    {
        InitializeComponent();
        BindingContext = new CourseManagementViewViewModel();
    }

    private void AddCourseClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CourseDetail");
    }

    private void RemoveCourseClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseManagementViewViewModel)?.RemoveCourse();
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void ContentPage_NavigatedTo(object sender, EventArgs e)
    {
        (BindingContext as CourseManagementViewViewModel)?.Refresh();
    }
}