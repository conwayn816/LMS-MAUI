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

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CourseManagement");
    }

    private void ContentPage_NavigatedTo(object sender, EventArgs e)
    {
        (BindingContext as CourseDetailedViewViewModel)?.Refresh();
    }
}