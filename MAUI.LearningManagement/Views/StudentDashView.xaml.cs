using MAUI.LearningManagement.ViewModels;
namespace MAUI.LearningManagement.Views;

public partial class StudentDashView : ContentPage
{

    public StudentDashView()
    {
        InitializeComponent();
    }


    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentView");
    }

}