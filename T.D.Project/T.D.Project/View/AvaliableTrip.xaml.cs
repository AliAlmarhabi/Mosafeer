using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T.D.Project.dependency;
using T.D.Project.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace T.D.Project.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AvaliableTrip : ContentPage
    {
        private string phoneNo = string.Empty;
        public AvaliableTrip(List<Customer> _customer,string to)
        {
            List<Customer> driverProfile = new List<Customer>();
            InitializeComponent();
            foreach (var item in _customer)
            {
                if (item.DriverImg == null)
                {
                    //set image profile for none exist image.
                    item.imgProfile = ImageSource.FromFile("user.png");
                }
                else
                {
                    item.imgProfile = ImageSource.FromStream(() => new MemoryStream(item.DriverImg));
                }
                driverProfile.Add(
                         new Customer()
                         {
                             DriverName = item.DriverName,
                             DriverLname = item.DriverLname,
                             //to meas destination city that enter it by the user.
                             Destination = to,
                             DriverPhone = item.DriverPhone,
                             DriverCarSize = item.DriverCarSize,
                             DriverCar = item.DriverCar,
                             DriverCarYear = item.DriverCarYear,
                             imgProfile = item.imgProfile
                         });
            }
            //populate data from viewModel class.
            BindingContext = this;
            DriverInfo.ItemsSource = driverProfile;
        }
        private async void DriverInfo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string name = string.Empty;
            //check if no item has been selected and return null.
            if (e.SelectedItem == null)
            {
                return;
            }
            var pick = (ListView)sender;
            //casting property from list to customer object.
            var indextItem = pick.SelectedItem as Customer;
            name = indextItem.DriverName;
            bool action = await DisplayAlert("اتصال", "هل ترغب في التواصل مع " + name + "", "نعم", "لا");
            if (action)
            {
                phoneNo = indextItem.DriverPhone;
                DependencyService.Get<IDialingCall>().call(phoneNo);
            }
        }
    }
}