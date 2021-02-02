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
using MahApps.Metro.Controls;

namespace DairySolution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public static Frame mainFrame = new Frame();
        public MainWindow()
        {
            InitializeComponent();
            mainFrame = MainContentFrame;
            mainFrame.Navigate(new Diary_Page());
        }

        private void SubMenu1Radio_Unchecked(object sender, RoutedEventArgs e)
        {
            DiaryRadioBtn.IsChecked = false;
        }
        private void SubMenu1Radio_Checked(object sender, RoutedEventArgs e)
        {
            DiaryRadioBtn.IsChecked = true;
        }

        private void FeedbackRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new FeedBack());
        }

        private void DashboardRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Diary_Page());

        }

        private void MetroWindow_Initialized(object sender, EventArgs e)
        {

        }

      
    }
}
