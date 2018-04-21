using T.D.Project.dependency;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using T.D.Project.View;

namespace T.D.Project.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactUS : ContentPage
    {
        public ContactUS()
        {
            InitializeComponent();
        }

        private void btnShare_Clicked(object sender, System.EventArgs e)
        {
            DependencyService.Get<IShareApp>().share();
        }

        private void btnInfo_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AboutUs());
        }

        private void btnContactUs_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Complian());
        }
    }
}