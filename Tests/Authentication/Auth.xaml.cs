using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Tests.Authentication
{
    public partial class Auth : Window
    {
        private static readonly Regex LoginRegex = new Regex(@"^[a-zA-Z0-9]{4,}$");
        private static readonly Regex PasswordRegex = new Regex(@"^[a-zA-Z0-9!@#$%^&*()_+\-=\[\]{}|;:'"",.<>?/]{4,}$");
        private readonly TestsEntities db;
        public bool isNav = false;
        public Auth()
        {
            InitializeComponent();
            db = new TestsEntities();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isNav)
            {
                return;
            }

            if (MessageBox.Show("Вы действительно хотите выйти из приложения?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string Login = UserLogin.Text;
            string Password = UserPassword.Password;

            try
            {
                if (!LoginRegex.IsMatch(Login))
                {
                    MessageBox.Show("Вы неправильно ввели логин",
                        "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    MessageBox.Show("Логин может содержать: английские символы\n" +
                        "Цифры" +
                        "Минимальное количество символов в логине: 4",
                        "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                var userToCheck = db.users.AsNoTracking().FirstOrDefault(x => x.login == Login && x.password == Password);

                if (userToCheck == null)
                {
                    MessageBox.Show("Пользователя с таким логином не существует в системе",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!PasswordRegex.IsMatch(Password))
                {
                    MessageBox.Show("Вы неправильно ввели пароль",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    MessageBox.Show("Пароль может содержать: английские символы\n" +
                        "Цифры\n" +
                        "Специальные символы" +
                        "Минимальное колчество символов в пароле: 4",
                        "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                MessageBox.Show("Вы авторизовались!");

                var app = (App)Application.Current;
                app.SetCurrentID(userToCheck.user_id);  // Устанавливаем CurrentUserID
                app.SetCurrentRole((int)userToCheck.role_id);

                if (userToCheck.role_id == 1)
                {

                    isNav = true;
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }

                else
                {
                    isNav = true;
                    TeacherWindow teacherWindow = new TeacherWindow();
                    teacherWindow.Show();
                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LinkReg_Click(object sender, RoutedEventArgs e)
        {
            isNav = true;
            Reg reg = new Reg();
            reg.Show();
            this.Close();
        }
    }
}