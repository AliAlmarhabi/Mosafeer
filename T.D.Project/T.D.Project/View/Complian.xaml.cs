using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace T.D.Project.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Complian : ContentPage
    {
        private string _segestion = string.Empty;
        public Complian()
        {
            InitializeComponent();
            SegmenSugestion.AddSegment("شكوى");
            SegmenSugestion.AddSegment("اقتراح");
        }

        private void btnSend_Clicked(object sender, EventArgs e)
        {
            if (entryName.Text != null && entryPhone.Text != null)
            {
                txtMessage.IsVisible = true;
                txtMessage.Text =string.Format("لقدتم استلام {0}", _segestion);
            }
        }

        private void SegmenSugestion_SelectedSegmentChanged(object sender, int e)
        {
           int item = SegmenSugestion.SelectedSegment;
            switch (item)
            {
                case 0:
                    _segestion = "شكواكم";
                    break;
                case 1:
                    _segestion = "اقتراحكم";
                    break;
                default:
                    break;
            }
        }
    }
}