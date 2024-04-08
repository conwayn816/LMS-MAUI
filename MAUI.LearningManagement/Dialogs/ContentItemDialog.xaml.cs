using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Dialogs
{
    public partial class ContentItemDialog : ContentPage
    {
        public ContentItemDialog()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            
        }

        private void CancelClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//CourseManagement");
        }
    }
}