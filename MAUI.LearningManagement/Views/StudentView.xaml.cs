namespace MAUI.LearningManagement.Views;

public partial class StudentView : ContentPage
{

    public StudentView()
    {
        InitializeComponent();
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

}

