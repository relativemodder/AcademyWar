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
    /// Логика взаимодействия для PageCreateAcc.xaml
    /// </summary>
    public partial class PageCreateAcc : Page
    {
        public PageCreateAcc()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        private void CreateAccButton_Click(object sender, RoutedEventArgs e)
        {
            if (AppConnect.model0db.User.Count(x => x.Login.ToLower() == Login.Text.ToLower()) > 0)
            {
                MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                var userObject = new User()
                {
                    Login = Login.Text,
                    Password = Password.Password,
                    Name = UserName.Text,
                    IdRole = 2
                };

                AppConnect.model0db.User.Add(userObject);
                AppConnect.model0db.SaveChanges();

                MessageBox.Show("Данные успешно сохранены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PB_PasswordChanged(object sender, RoutedEventArgs e)
        {
            CreateAccButton.IsEnabled = Password.Password == Password2.Password;
        }
    }
}
