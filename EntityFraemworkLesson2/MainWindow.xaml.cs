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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EntityFraemworkLesson2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel view_model = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = view_model;
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
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User tmp = view_model.context.GetLogin(this.loginTxtBox.Text, ComputeSha256Hash(this.passwordTxtBox.Password));
                if (tmp == null)
                {
                    MessageBox.Show("Incorrect login or password");
                    return;
                }
                ViewModel.logined_user = tmp;
                MessageBox.Show($"You was logined as {tmp.Login}");
                MainAfterLogin mainForm = new MainAfterLogin(this);
                this.Hide();
                mainForm.Show();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            Window1 reg_form = new Window1(this);
            this.Hide();
            reg_form.Show();
        }
    }
}
