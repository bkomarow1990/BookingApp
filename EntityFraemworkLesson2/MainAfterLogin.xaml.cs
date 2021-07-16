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
    /// Interaction logic for MainAfterLogin.xaml
    /// </summary>
    public partial class MainAfterLogin : Window
    {
        MainWindow mw;
        public MainAfterLogin(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
            this.DataContext = mw.DataContext; 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel wm = (this.mw.DataContext as ViewModel);
            ViewModel.logined_user = null;
            mw.Show();
            this.Close();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            bool approvedDecimalPoint = false;

            if (e.Text == ".")
            {
                if (!((TextBox)sender).Text.Contains("."))
                    approvedDecimalPoint = true;
            }

            if (!(char.IsDigit(e.Text, e.Text.Length - 1) || approvedDecimalPoint))
                e.Handled = true;
        }
        private bool Filtring(Room r)
        {
            var context = (mw.DataContext as ViewModel);
            if (r.Area < context.Room.AreaFrom || r.Area > context.Room.AreaTo )
            {
                return false;
            }
            if (context.Room.DateFrom >= context.Room.DateTo || r.Rents.Any(e => e.DateTo >= context.Room.DateFrom ) )
            {
                return false;
            }
            if (!String.IsNullOrEmpty(context.Room.City))
            {
                return context.Room.City == r.City;
            }
            
            return true;
        }
        private void ShowBtn_Click(object sender, RoutedEventArgs e)
        {
            var context = (mw.DataContext as ViewModel);
            itemsListBox.ItemsSource = context.context.Rooms.Where(Filtring);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            mw.Close();
        }

        private void RentBtn_Click(object sender, RoutedEventArgs e)
        {
            var selected = itemsListBox.SelectedItem as Room;
            if (selected == null)
            {
                return;
            }
            var context = (mw.DataContext as ViewModel);
            if (FromDatePicker.SelectedDate <= DateTime.Now || ToDatePicker.SelectedDate > DateTime.Now)
            {
                MessageBox.Show("Room is reserved");
                return;
            }
            context.context.Rents.Add(new Rents { UserId = ViewModel.logined_user.Id, RoomId  = selected.Id , DateFrom = (DateTime)FromDatePicker.SelectedDate, DateTo = (DateTime)ToDatePicker.SelectedDate, IsAvailable = false});
            context.context.SaveChanges();
        }

        private void ShowRentsBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowRents showRents = new ShowRents(mw);
            showRents.ShowDialog();
        }
    }
}
