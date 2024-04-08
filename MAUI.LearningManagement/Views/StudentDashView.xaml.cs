using MAUI.LearningManagement.ViewModels;
namespace MAUI.LearningManagement.Views;

public partial class StudentDashView : ContentPage
{

    public StudentDashView()
    {
        InitializeComponent();
        BindingContext = new StudentDashViewViewModel();
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Student");
    }

    private void ContentPage_NavigatedTo(object sender, EventArgs e)
    {
        (BindingContext as StudentDashViewViewModel)?.Refresh();
    }

}