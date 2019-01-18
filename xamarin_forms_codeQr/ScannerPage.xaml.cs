using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace xamarin_forms_codeQr
{
    public partial class ScannerPage : ContentPage
    {
        //ZXingScannerView zxing;
        //ZXingDefaultOverlay overlay;
        public ScannerPage()
        {
            InitializeComponent();

            scanner.OnScanResult += Zxing_OnScanResult;
            overlay.FlashButtonClicked += Overlay_FlashButtonClicked;
            overlay.BottomText = "A scannear...";
            overlay.TopText = "Xamarin Forms #gerador e leitor de codigo qr ";
            overlay.ShowFlashButton = scanner.HasTorch; 

            //zxing = new ZXingScannerView
            //{
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    AutomationId = "zxingScannerView",
            //};
            //zxing.OnScanResult += Zxing_OnScanResult;

            //overlay = new ZXingDefaultOverlay
            //{
            //    TopText = "Xamarin Forms #gerador e leitor de codigo qr ",
            //    BottomText = "A scannear...",
            //    ShowFlashButton = zxing.HasTorch,
            //    AutomationId = "zxingDefaultOverlay",
            //};
            //overlay.FlashButtonClicked += (sender, e) => {
            //    zxing.IsTorchOn = !zxing.IsTorchOn;
            //};
            //var grid = new Grid
            //{
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //};
            //grid.Children.Add(zxing);
            //grid.Children.Add(overlay); 
            //Content = grid;
        }

        void Overlay_FlashButtonClicked(Button sender, EventArgs e)
        {
            scanner.IsTorchOn = !scanner.IsTorchOn;
        }


        async void Zxing_OnScanResult(ZXing.Result result)
        {
             
                Device.BeginInvokeOnMainThread(async () => {
                    scanner.IsAnalyzing = false;
                    var r = await DisplayAlert("Scanned Barcode", result.Text, "Repetir", "Ok");
                    if (r.Equals("Repetir"))
                    {
                        scanner.IsAnalyzing = true;
                        scanner.IsScanning = true;
                    }
                });

           
        }

         


        protected override void OnAppearing()
        {
            base.OnAppearing();
            scanner.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            scanner.IsScanning = false;
            base.OnDisappearing();
        }
    }
}