using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T.D.Project.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace T.D.Project.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : TabbedPage
    {
        public Home()
        {
            InitializeComponent();
        }
    }
}