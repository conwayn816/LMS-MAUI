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

    private void AddStudentClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentDetail");
    }

    private void ContentPage_NavigatedTo(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel)?.Refresh();
    }

}
