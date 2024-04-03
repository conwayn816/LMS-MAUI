using MAUI.LearningManagement.ViewModels;
using MAUI.LearningManagement.Dialogs;

namespace MAUI.LearningManagement.Views;

public partial class CourseManagementView : ContentPage
{
    public CourseManagementView()
    {
        InitializeComponent();
        BindingContext = new CourseManagementViewViewModel();
    }

    private async void AddCourseClicked(object sender, EventArgs e)
    {
        var courseDialogViewModel = new CourseDialogViewModel();
        var courseDialog = new CourseDialog { BindingContext = courseDialogViewModel };
        await Shell.Current.Navigation.PushModalAsync(courseDialog);
    }

    private void ViewSelectedCourseClicked(object sender, EventArgs e)
    {
        
    }

    private void EditCourseClicked(object sender, EventArgs e)
    {
        var viewModel = BindingContext as CourseManagementViewViewModel;
        if (viewModel != null)
        {
            var selectedCourse = viewModel.SelectedCourse;
            if (selectedCourse != null)
            {
                var courseDialogViewModel = new CourseDialogViewModel(selectedCourse);
                var courseDialog = new CourseDialog { BindingContext = courseDialogViewModel };
                Shell.Current.Navigation.PushModalAsync(courseDialog);
            }
            else
            {
                DisplayAlert("Error", "Please select a course to edit", "OK");
            }
        }
    }

    private void RemoveCourseClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseManagementViewViewModel)?.RemoveCourse();
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    private void ContentPage_NavigatedTo(object sender, EventArgs e)
    {
        (BindingContext as CourseManagementViewViewModel)?.Refresh();
    }
}