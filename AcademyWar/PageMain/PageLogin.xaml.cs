using AcademyWar.ApplicationData;
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

namespace AcademyWar.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var login = Login.Text;
            var password = Password.Password;

            try
            {
                var userObject = AppConnect.model0db.User.FirstOrDefault(x => x.Login == login && x.Password == password);
                if (userObject == null)
                {
                    MessageBox.Show("Такой пользователь не найден!", "Ошибка авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var roleObject = AppConnect.model0db.Role.FirstOrDefault(r => r.Id == userObject.Id);

                if (roleObject == null)
                {
                    MessageBox.Show("Данные о роли не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show($"Здравствуйте, {roleObject.Name}!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageCreateAcc());
        }
    }
}
