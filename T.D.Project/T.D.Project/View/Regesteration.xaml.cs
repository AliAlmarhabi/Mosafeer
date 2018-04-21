using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using T.D.Project.Models;
using System.IO;

namespace T.D.Project.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Regesteration : ContentPage
    {
        Customer customer = new Models.Customer();
        private string  destList = null;
        string[] desCity = new string[10];
        public Regesteration()
        {
            InitializeComponent();
            pickCity.ItemsSource = HelperClass.cityList();
            pickCar.ItemsSource = HelperClass.carType();
            pickYear.ItemsSource = HelperClass.carModel();
            //set tap Gesture
            var imagTag = new TapGestureRecognizer();
            imagTag.Tapped += ImagTag_Tapped;
            imgProfile.GestureRecognizers.Add(imagTag);
        }
        private void ImagTag_Tapped(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            HelperClass obj = new HelperClass();
            //based on Device to set porperty AspectFill.
            if (Device.RuntimePlatform == Device.Android)
            {
                imgProfile.Aspect = Aspect.AspectFill;
            }
            obj.PickPhot(imgProfile);
        }
        private void btnRegster_Clicked(object sender, EventArgs e)
        {
            if (txtFname.Text == null || txtLname.Text == null || txtPhone.Text == null || txtCarSeat.Text == null
               || pickCar.Items.Count == 0 || pickCity.Items.Count == 0
               || pickYear.Items.Count == 0)
            {
                lblMsg.IsVisible = true;
            }
            else
            {
                customer.DriverName = txtFname.Text;
                customer.DriverLname = txtLname.Text;
                customer.DriverPhone = txtPhone.Text;
                customer.DriverCity = pickCity.SelectedItem.ToString();
                customer.DriverCar = pickCar.SelectedItem.ToString();
                customer.DriverCarYear = pickYear.SelectedItem.ToString();
                customer.DriverCarSize = stpSeat.Value.ToString();
                customer.DriverImg =  HelperClass.imgBinary;
                
                for (int i = 0; i < 9; i++)
                {
                    if (i == 0 && checkBox1.Checked)
                    {
                        destList = checkBox1.CheckedText;
                    }
                    else if ( i == 1 && checkBox2.Checked)
                    {
                        destList += checkBox2.CheckedText;
                    }
                    else if (i == 2 && checkBox3.Checked)
                    {
                        destList = checkBox3.CheckedText;
                    }
                    else if (i == 3 && checkBox4.Checked)
                    {
                        destList = checkBox4.CheckedText;
                    }
                    else if (i == 4 && checkBox5.Checked)
                    {
                        destList = checkBox5.CheckedText;
                    }
                    else if (i == 5 && checkBox6.Checked)
                    {
                        destList = checkBox6.CheckedText;
                    }
                    else if (i == 6 && checkBox7.Checked)
                    {
                        destList = checkBox7.CheckedText;
                    }
                    else if (i == 7 && checkBox8.Checked)
                    {
                        destList = checkBox8.CheckedText;
                    }
                    else if (i == 8 && checkBox9.Checked)
                    {
                        destList = checkBox9.CheckedText;
                    }
                    desCity[i] += destList;
                    destList = "";
                }

                foreach (var item in desCity)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        customer.Destination += item + ",";
                    }
                }
                customer.Destination = customer.Destination.Remove(customer.Destination.Length-1, 1);
                //customer.Destination = destinationCity.Text;
                Services.AzureService service = new Services.AzureService();
                bool response = service.AddNewUser(customer);
                if (response)
                {
                    lblMsg.IsVisible = true;
                    lblMsg.Text = "لقد تم التسجل بنجاح";
                    lblMsg.TextColor = Color.Green;
                }
                else
                {
                    DisplayAlert("مشكلة في الخدمة", "لم تتم عملية التسجيل بنجاح لوجود خلل في الخدمة الرجاء المحاول في وقت لاحق وعذراّ على الازعاج", "موافق");
                }
            }
        }
        private void stpSeat_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            txtCarSeat.Text = stpSeat.Value.ToString();
        }

        private void pickCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            StackLayoutGrid.IsVisible = true;
            List<string> city = new List<string>();
            city.Add("الرياض");
            city.Add("جدة");
            city.Add("مكة");
            city.Add("المدينة المنورة");
            city.Add("الطائف");
            city.Add("الدمام");
            city.Add("القصيم");
            city.Add("ابها");
            city.Add("جازان");
            city.Add("تبوك");

            for (int i = 0; i < city.Count; i++)
            {
                if (city[i].Contains((string)pickCity.SelectedItem))
                {
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                    checkBox6.Checked = false;
                    checkBox7.Checked = false;
                    checkBox8.Checked = false;
                    checkBox9.Checked = false;
                    //remove the city which is selected from dropDownList.
                    city.RemoveAt(i);
                }
            }
            checkBox1.UncheckedText = city[0];
            checkBox1.CheckedText = city[0];
            checkBox2.UncheckedText = city[1];
            checkBox2.CheckedText = city[1];
            checkBox3.UncheckedText = city[2];
            checkBox3.CheckedText = city[2];
            checkBox4.UncheckedText = city[3];
            checkBox4.CheckedText = city[3];
            checkBox5.UncheckedText = city[4];
            checkBox5.CheckedText = city[4];
            checkBox6.UncheckedText = city[5];
            checkBox6.CheckedText = city[5];
            checkBox7.UncheckedText = city[6];
            checkBox7.CheckedText = city[6];
            checkBox8.UncheckedText = city[7];
            checkBox8.CheckedText = city[7];
            checkBox9.UncheckedText = city[8];
            checkBox9.CheckedText = city[8];
        }
    }
}