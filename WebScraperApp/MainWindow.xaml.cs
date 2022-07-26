using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
namespace WebScraperApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void url_txt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (url_txt.Text == "Please Enter a URL")
            {
                url_txt.Clear();
                url_txt.Opacity = 100;
            }
        }

        private void scrape_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (WebClient getData = new())
                {
                    result_txt.Text = getData.DownloadString(url_txt.Text).Replace(">", ">\n");
                }
                result_txt.Visibility=Visibility.Visible;
            }
            catch (Exception)
            {
                MessageBox.Show("The URL provided was invalid!","Error");
            }
        }
    }
}
