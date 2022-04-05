using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileEncryptor
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_Drop(object sender, System.Windows.DragEventArgs e)
        {
            string[] files = ((string[])e.Data.GetData(System.Windows.DataFormats.FileDrop));
            foreach (string item in files)
            {
                ListBoxFileNames.Items.Add(item);
            }
        }

        private void CheckBoxChageDir_Checked(object sender, RoutedEventArgs e)
        {
            ButtonBrowse.Visibility = Visibility.Visible;
            TextBoxLocation.Visibility = Visibility.Visible;
        }

        private void CheckBoxChageDir_Unchecked(object sender, RoutedEventArgs e)
        {
            ButtonBrowse.Visibility = Visibility.Hidden;
            TextBoxLocation.Visibility = Visibility.Hidden;
        }

        private void ButtonBrowse_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if(result == System.Windows.Forms.DialogResult.OK)
                {
                    TextBoxLocation.Text = dialog.SelectedPath;
                }
            }
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            byte[] bytepass = Encoding.ASCII.GetBytes(hash.hash.Create(TextBoxPassword.Text));
            //check if there are files to encrypt or decrypt
            if (ListBoxFileNames.Items.Count != 0)
            {
                if (TextBoxLocation.Text != "")
                {
                    foreach (string item in ListBoxFileNames.Items)
                    {
                        if (CheckIfFileIsAES(item))
                        {
                            //decrypt
                            Decrypt(item, item.Replace(".aes", ""), bytepass);
                        }
                        else
                        {
                            //encrypt
                            Encrypt(item, item, bytepass, item);
                        }
                    }
                }
                else
                    System.Windows.MessageBox.Show("Please select location or uncheck 'Change location?'");
            }
            else
            {
                //throw a messagebox at user for being a monkey
                System.Windows.MessageBox.Show("There aren't any files to process!");
            }
        }
        private bool CheckIfFileIsAES(string file)
        {
            if (!file.EndsWith(".aes"))
            {
                return false;
            }
            return true;
        }

        private void Decrypt(string inputfile, string outputfile, byte[] passoword)
        {
            if ((bool)CheckBoxChageDir.IsChecked)
            {
                AES.rijndaelManaged.Decrypt(inputfile, TextBoxLocation.Text + "/" + System.IO.Path.GetFileName(outputfile.Replace(".aes", "")), passoword, Convert.ToInt32(TextBoxKeySize.Text), Convert.ToInt32(TextBoxBlockSize.Text), Encoding.ASCII.GetBytes(TextBoxSaltBytes.Text));
            }
            else
            {
                AES.rijndaelManaged.Decrypt(inputfile, outputfile, passoword, Convert.ToInt32(TextBoxKeySize.Text), Convert.ToInt32(TextBoxBlockSize.Text), Encoding.ASCII.GetBytes(TextBoxSaltBytes.Text));
            }
        }
        private void Encrypt(string inputfile, string outputfile, byte[] passoword, string item)
        {
            if ((bool)CheckBoxChageDir.IsChecked)
            {
                AES.rijndaelManaged.Encrypt(inputfile, TextBoxLocation.Text + "/" + System.IO.Path.GetFileName(item) + ".aes", passoword, Convert.ToInt32(TextBoxKeySize.Text), Convert.ToInt32(TextBoxBlockSize.Text), Encoding.ASCII.GetBytes(TextBoxSaltBytes.Text));
            }
            else
            {
                AES.rijndaelManaged.Encrypt(inputfile, outputfile + ".aes", passoword, Convert.ToInt32(TextBoxKeySize.Text), Convert.ToInt32(TextBoxBlockSize.Text), Encoding.ASCII.GetBytes(TextBoxSaltBytes.Text));
            }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            ListBoxFileNames.Items.Clear();
        }

        private void ButtonInfo_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infowindows = new InfoWindow();
            infowindows.Show();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Delete)
            {
                ListBoxFileNames.Items.Remove(ListBoxFileNames.SelectedItem);
            }
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(ListBoxFileNames.SelectedItem.ToString());
        }
    }
}
