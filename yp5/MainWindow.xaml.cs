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


namespace yp5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private hsdEntities _context = new hsdEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string userName = UsernameTextBox.Text;
            string password = PasswordBox.Password;  // скрытый ввод пароля

            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);

            if (user != null && VerifyPasswordHash(password, user.PasswordHash))
            {
                if (user.RoleID == 1) // Администратор
                {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                }
                else if (user.RoleID == 2) // Пользователь
                {
                    UserWindow userWindow = new UserWindow();
                    userWindow.Show();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            // Проверка хеша пароля
            var passwordHash = ComputeSha256Hash(password);
            return passwordHash == storedHash;
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
