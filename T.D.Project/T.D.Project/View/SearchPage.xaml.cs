using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using T.D.Project.Models;
using T.D.Project.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace T.D.Project.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public bool busy = false;
        public SearchPage() 
        {
            InitializeComponent();           
            //populate picker with city form citylist function.
            pickerFrom.ItemsSource = HelperClass.cityList();
            pickerTo.ItemsSource = HelperClass.cityList();
            BindingContext = new ViewModel();
        }
        private async void btnSearch_Clicked(object sender, EventArgs e)
        {
            //check internet Connectivity.
            if (!Validation.checkInternet())
            {
                DisplayAlert("الرجاء المحاولة لاحقاّ", "الرجاء التاكد من الوصول الى الإنترنت ومن ثم المحاولة مرة اخرى", "حسناّ");
                return;
            }

            Services.AzureService azService = new Services.AzureService();
            try
            {
                //check inntent Connectivity.             
                List<Customer> customerData = null;
                string from = pickerFrom.SelectedItem.ToString();
                string to = pickerTo.SelectedItem.ToString();
                Task<List<Customer>> task = new Task<List<Customer>>(() => azService.getUserProfile(from, to));
                task.Start();
                btnSearch.IsEnabled = false;
                Stacksearchable.IsEnabled = false;
                loading.IsRunning = true;
                customerData = await task;
                if (customerData != null)
                {
                  btnSearch.IsEnabled = true;
                  Stacksearchable.IsEnabled = true;
                  loading.IsRunning = false;
                }
                //navigate to AvaliableTrip page
                Navigation.PushAsync(new AvaliableTrip(customerData,to));
            }
            catch (Exception)
            {
                DisplayAlert("تنبية", "الخدمة غير متوفرة حالياّ", "موافق");
            }
        }
    }
}