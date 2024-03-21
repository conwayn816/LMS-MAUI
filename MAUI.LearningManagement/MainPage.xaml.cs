namespace MAUI.LearningManagement;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private void InstructorClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//instructor");
	}

	private void StudentClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//student");
	}

}

