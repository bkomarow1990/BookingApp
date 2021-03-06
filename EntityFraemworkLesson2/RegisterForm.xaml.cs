using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EntityFraemworkLesson2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        MainWindow mw = null;
        public Window1(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }


        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            (mw.DataContext as ViewModel).context.Register(this.loginTxtBox.Text, ComputeSha256Hash(this.passwordTxtBox.Password));
            this.Close();
            mw.Show();
        }
        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            mw.Show();
        }
    }
}
