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
using System.IO;
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
            if (url_txt.Text == "Please Enter a URL")//clear url text on click in
            {
                url_txt.Clear();
                url_txt.Opacity = 100;
            }
        }

        private void scrape_btn_Click(object sender, RoutedEventArgs e)
        {
            try//atempt scrape
            {
                using (WebClient getData = new())
                {
                    result_txt.Text = getData.DownloadString(url_txt.Text).Replace(">", ">\n");
                }
                result_txt.Visibility=Visibility.Visible;
            }
            catch (Exception)//if invalid Url
            {
                MessageBox.Show("The URL provided was invalid!","Error");
            }
        }

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            if(result_txt.Text != "") 
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "Scrape"; // Default file name
                dlg.DefaultExt = ".html"; // Default file extension
                dlg.Filter = "Web Pages (.html)|*.html"; // Filter files by extension

                // Show save file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process save file dialog box results
                if (result == true)
                {
                    // Save document
                    StreamWriter write = File.CreateText(dlg.FileName);
                    write.Write(result_txt.Text);
                    write.Close();
                    MessageBox.Show(dlg.FileName.Split("\\").Last() + " has been saved!", "File Saved");
                }
            }
        }

        private void url_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter) //when enter is pressed trigger scrape
            {
                scrape_btn_Click(this, e);
            }
        }
    }
}
