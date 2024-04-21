using MAUI.LearningManagement.ViewModels;
using LMS.Models;

namespace MAUI.LearningManagement.Views;

public partial class CourseDetailedStudentView : ContentPage
{
    public CourseDetailedStudentView()
    {
        InitializeComponent();
        BindingContext = new CourseDetailedStudentViewViewModel();
    }

    private void SubmitAssignmentClicked(object sender, EventArgs e)
    {
        
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentDashboard");
    }

    private void ContentPage_NavigatedTo(object sender, EventArgs e)
    {
        (BindingContext as CourseDetailedStudentViewViewModel)?.Refresh();
    }
}