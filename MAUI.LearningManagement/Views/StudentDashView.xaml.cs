using MAUI.LearningManagement.ViewModels;
namespace MAUI.LearningManagement.Views;

public partial class StudentDashView : ContentPage
{

    public StudentDashView()
    {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(INavigationParameters parameters)
    {
        base.OnNavigatedTo(parameters);

        if (parameters.ContainsKey("StudentId"))
        {
            var studentId = parameters.GetValue<Guid>("StudentId");
            // Now you can use studentId to get the student's details
        }
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentView");
    }

}