using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Tests.Authentication
{ 
    public partial class Reg : Window
    {

        private static readonly Regex LoginRegex = new Regex(@"^[a-zA-Z0-9]{4,}$");
        private static readonly Regex PasswordRegex = new Regex(@"^[a-zA-Z0-9!@#$%^&*()_+\-=\[\]{}|;:'"",.<>?/]{4,}$"); private readonly TestsEntities db;
        public bool isNav = false;
        public Reg()
        {
            InitializeComponent();
            db = new TestsEntities();
            LoadRoles();
        }

        private void LoadRoles()
        {
            var roles = db.roles.ToList();
            Roles.ItemsSource = roles;
            Roles.DisplayMemberPath = "role_name";
            Roles.SelectedValuePath = "role_id";
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            string Login = UserLogin.Text;
            string Password = UserPassword.Password;
            int? UserRole = (int?)Roles.SelectedValue;

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

                if (db.users.Any(u => u.login == Login))
                {
                    MessageBox.Show("Аккаунт с таким логином уже существует\n" +
                        "Попробуйте другой",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (Roles.SelectedItem == null)
                {
                    MessageBox.Show("Выберите роль пользователя",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                var users = new user
                {
                    login = Login,
                    password = Password,
                    role_id = UserRole
                };

                db.users.Add(users);
                db.SaveChanges();

                MessageBox.Show("Вы успешно зарегистрировались в систему", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                isNav = true;
                Auth auth = new Auth();
                auth.Show();
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
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
        private void LinkAuth_Click(object sender, RoutedEventArgs e)
        {
            isNav = true;
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }
    }
}