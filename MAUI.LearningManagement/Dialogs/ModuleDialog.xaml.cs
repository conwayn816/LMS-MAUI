using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Dialogs
{
    public partial class ModuleDialog : ContentPage
    {
        public ModuleDialog()
        {
            InitializeComponent();
            BindingContext = new ModuleDialogViewModel();
        }

        private void SaveClicked(object sender, EventArgs e)
        {
            (BindingContext as ModuleDialogViewModel)?.SaveModule();
            Shell.Current.GoToAsync($"//CourseManagement");
        }

        private void CancelClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//CourseManagement");
        }
    }
}