using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DairySolution.Helper;
using DairySolution.Integrations.SolvewareAPI;
using DairySolution.Integrations.SolvewareAPI.Model;
using DairySolution.Integrations.SolvewareAPI.Services;

namespace DairySolution
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private async void LoginBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            //mainWindow.ShowDialog();
            //this.Close();
            //return;
            var loginModel = new LoginModel()
            {
                Email = EmailTxt.Text,
                Password = PasswordTxt.Password,
                OrganizationId = OrganizationTxt.Text
            };
            var contributor = await AccountService.Login(loginModel);
            if (contributor != null)
            {
                if (contributor.IsBlocked)
                {
                    MessageBox.Show("Contributor blocked by admin.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {
                    
                    var dp = SolvewareApiHelper.SiteUrl + contributor.ProfilePicture;
                    LoginHelper.loginData = contributor;
                   
                    if (contributor.ProfilePicture != null)
                    {
                        mainWindow.DisplayPicture.Source = new BitmapImage(new Uri(dp, UriKind.Absolute));

                    }
                    mainWindow.Show();
                    this.Close();

                }

            }
            else
            {
                MessageBox.Show("Invalid user info,", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }
    }
}
