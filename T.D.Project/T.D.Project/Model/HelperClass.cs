using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace T.D.Project.Models
{
   public class HelperClass
    {
        //cityList
        public static List<string> cityList()
        {
            List<string> cityName = new List<string>();
            cityName.Add("الرياض");
            cityName.Add("جدة");
            cityName.Add("مكة");
            cityName.Add("الشرقية");
            cityName.Add("المدينة");
            return cityName;
        }

        //CarTypeList
        public static List<string> carType()
        {
            List<string> carName = new List<string>();
            carName.Add("كامري");
            carName.Add("كورولا");
            carName.Add("يارس");
            carName.Add("فورد");
            return carName;
        }

        //CarModelList
        public static List<string> carModel()
        {
            List<string> carYear = new List<string>();
            carYear.Add("2010");
            carYear.Add("2011");
            carYear.Add("2012");
            carYear.Add("2013");
            carYear.Add("2014");
            carYear.Add("2015");
            carYear.Add("2016");
            carYear.Add("2017");
            carYear.Add("2018");
            return carYear;
        }
         
        public async void PickPhot(Image img)
        {
            await CrossMedia.Current.Initialize();
            var file = await CrossMedia.Current.PickPhotoAsync();
            img.Source = ImageSource.FromStream(() =>
            {
              var stream = file.GetStream();
                file.Dispose();
                if (stream.Position==0)
                {
                  convertImgToBinary(stream);
                }
                stream.Seek(0,SeekOrigin.Begin);        
                return stream;                
            });   
        }
        public static byte[] imgBinary = null; 
        public static byte[] convertImgToBinary(Stream st)
        {
           
            MemoryStream ms = new MemoryStream();
            st.CopyTo(ms);
            imgBinary = ms.ToArray();       
            return imgBinary;
        } 
        public static byte[] item()
        {
            return imgBinary;
        }
    }
}
