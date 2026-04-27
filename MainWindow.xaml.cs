using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Web.WebView2.Core;

namespace KitcoWidget
{
    public partial class MainWindow : Window
    {
        private const string GoldUrl = "https://www.kitco.com/charts/livegold.html";
        private const string SilverUrl = "https://www.kitco.com/charts/livesilver.html";

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // GOLD
                await GoldBrowser.EnsureCoreWebView2Async();
                GoldBrowser.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
                GoldBrowser.CoreWebView2.Settings.AreDevToolsEnabled = false;
                GoldBrowser.Source = new Uri(GoldUrl);

                // SILVER
                await SilverBrowser.EnsureCoreWebView2Async();
                SilverBrowser.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
                SilverBrowser.CoreWebView2.Settings.AreDevToolsEnabled = false;
                SilverBrowser.Source = new Uri(SilverUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"WebView2 initialization failed: {ex.Message}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}