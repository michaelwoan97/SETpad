/**
 *      FILE            :       About.xaml.cs
 *      PROJECT         :       Assignment 2
 *      PROGRAMMER      :       NGHIA NGUYEN 861831
 *      DESCRIPTION     :       The purpose of this window is to create the About box
 *      FIRST VERSION   :       2020-09-27
 */

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

namespace nnguyen6831_A2
{
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
