using MAUI.LearningManagement.ViewModels;
namespace MAUI.LearningManagement.Views;

public partial class StudentView : ContentPage
{

    public StudentView()
    {
        InitializeComponent();
        BindingContext = new StudentViewViewModel();
    }

    private void LoginClicked(object sender, EventArgs e)
    {
        
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

}

