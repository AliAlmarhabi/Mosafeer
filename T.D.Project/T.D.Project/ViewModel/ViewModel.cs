using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using T.D.Project.Models;
using Xamarin.Forms;
namespace T.D.Project
{
    public class ViewModel : INotifyPropertyChanged 
    {

      public static ImageSource imgsource;
      public  bool busy = false;

        // public static byte[] imgasByte;
        public ImageSource ImgSource
        {
            set
            {
                imgsource = value;
                OnPropertyChanged("ImgSource");
                //img(imgasByte);
            }
            get
            {
                return imgsource;
            }
        }


        public bool IsBusy
        {
            get
            {
                return busy;
            }
            set
            {
                busy = value;
                OnPropertyChanged();
            }
           

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static ImageSource img(byte[] _imgbyte)
        {
             MemoryStream ms = new MemoryStream(_imgbyte);
             ms.Position = 0;
            imgsource = ImageSource.FromStream(() => ms);
            return imgsource;
        }
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
