﻿using System;
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
    /// Interaction logic for ShowRents.xaml
    /// </summary>
    public partial class ShowRents : Window
    {
        public MainWindow mw;
        public ShowRents(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
            itemsListBox.ItemsSource = ViewModel.logined_user.Rents;
        }
    }
}
