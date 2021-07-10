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
            (mw.DataContext as ViewModel).context.Register(this.loginTxtBox.Text, this.passwordTxtBox.Password);
            this.Close();
            mw.Show();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            mw.Show();
        }
    }
}
