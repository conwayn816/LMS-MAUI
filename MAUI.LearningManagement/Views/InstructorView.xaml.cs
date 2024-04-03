using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Views;

public partial class InstructorView : ContentPage
{

    public InstructorView()
    {
        InitializeComponent();
        BindingContext = new InstructorViewViewModel();
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    //STUDENTS
    private void StudentManagementClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentManagement");
    }

    //COURSES
    private void AddCourseClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CourseDetail");
    }

    private void RemoveCourseClicked(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel)?.RemoveCourse();
    }

    private void ContentPage_NavigatedTo(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel)?.Refresh();
    }

}
