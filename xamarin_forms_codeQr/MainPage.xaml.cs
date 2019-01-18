using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace xamarin_forms_codeQr
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Barcode.BarcodeOptions.Width = 300;
            Barcode.BarcodeOptions.Height = 300;
            Barcode.BarcodeOptions.Margin = 10;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var value = Editors.Text.ToString();

            Barcode.BarcodeValue = value;
        }
    }
}
