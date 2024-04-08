using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Dialogs
{
    public partial class ContentItemDialog : ContentPage
    {
        public ContentItemDialog()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ContentItemDialogViewModel();
        }

        private void SaveClicked(object sender, EventArgs e)
        {
            (BindingContext as ContentItemDialogViewModel)?.SaveContentItem();
            Shell.Current.GoToAsync("//CourseManagement");
        }

        private void CancelClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//CourseManagement");
        }
    }
}