using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Dialogs;

public partial class CourseDialog : ContentPage
{
    public CourseDialog()
    {
        InitializeComponent();
    }

    private void SaveClicked(object sender, EventArgs e)
    {
        //(BindingContext as StudentDialogViewModel)?.AddStudent();
        //Shell.Current.GoToAsync("//Instructor");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        //BindingContext = new StudentDialogViewModel();
    }
}
