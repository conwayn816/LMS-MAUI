using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Dialogs
{
    public partial class ModuleDialog : ContentPage
    {
        public ModuleDialog()
        {
            InitializeComponent();
        }

        private void SaveClicked(object sender, EventArgs e)
        {
            // Handle the save button click event
        }

        private void CancelClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//CourseManagement");
        }
    }
}