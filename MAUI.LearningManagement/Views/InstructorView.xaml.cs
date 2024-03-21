namespace MAUI.LearningManagement.Views;

public partial class InstructorView : ContentPage
{

    public InstructorView()
    {
        InitializeComponent();
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

}
