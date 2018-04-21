using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace T.D.Project.Models
{
    public class Customer
    {
        public string DriverName { get; set; }
        public string DriverLname { get; set; }
        public string DriverPhone { get; set; }
        public string DriverCity { get; set; }
        public string DriverCar { get; set; }
        public string DriverCarYear { get; set; }
        public string DriverCarSize { get; set; }
        public string Destination { get; set; }
        public byte[] DriverImg { get; set; }
        public ImageSource imgProfile { get; set; }

        public string Error;
    }
   
 
}

