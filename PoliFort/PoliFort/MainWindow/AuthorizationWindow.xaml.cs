using System;
using System.Data;
using System.Windows;
using System.Windows.Media.Imaging;
using MySql.Data.MySqlClient;
using SSSSTOCK;


namespace PoliFort
{
    public partial class AuthorizationWindow : Window
    {
        private DataBase dataBase = new DataBase();
       
        public AuthorizationWindow()
        {
            InitializeComponent();
            this.Loaded += AuthorizationWindow_Loaded;
            LoadTheme();
            
        }

        private void LoadTheme() // Проверка темы
        {
            if (PoliFort.Properties.Settings.Default.ThisTheme == "Dark")
            {
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri("\\Theme\\DarkDictionary.xaml", UriKind.Relative)
                });
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri("\\Theme\\WhiteDictionary.xaml", UriKind.Relative)
                });
            }
        }
        
        private void AuthorizationWindow_Loaded(object sender, RoutedEventArgs e) // Проверка на запоминаемого пользователя
        {
            if (!string.IsNullOrEmpty(PoliFort.Properties.Settings.Default.UserrPassword))
            {
                string userName = PoliFort.Properties.Settings.Default.UserName;
                DataTable table = new DataTable();

                string query = "SELECT role_us FROM users WHERE login_us = @UserName";
                MySqlCommand command = new MySqlCommand(query, dataBase.getConnection());
                command.Parameters.AddWithValue("@UserName", userName);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(table);

                if (table.Rows.Count > 0) // Проверяем, что данные были получены
                {
                    string userRole = table.Rows[0]["role_us"].ToString();

                    if (userRole == "Admin")
                        OpenMainWindow();
                    else
                        OpenSecondWindow();
                }
                else
                {
                    MessageBox.Show("Системная ошибка. Повторите попытку позже", "Ошибка");
                }
            }
        }

        private void OpenMainWindow()
        {
            this.Hide();
            MainMainWindow mainMainWindow = new MainMainWindow();
            mainMainWindow.Show();
        }

        private void OpenSecondWindow()
        {
            this.Hide();
            MainPolifortUser mainPolifortWindow = new MainPolifortUser();
            mainPolifortWindow.Show();
        }

        private void Go_Click(object sender, RoutedEventArgs e) // Вход
        {
            try
            {
                string loginUser = TextBox_Login.Text;
                PoliFort.Properties.Settings.Default.UserName = loginUser;
                PoliFort.Properties.Settings.Default.Save();

                var loginPassword = Hesh.hashPassword(TextBox_Passwword.Text);

                DataTable table = new DataTable();
                string query = $"SELECT iduser, login_us, role_us FROM users WHERE login_us = '{loginUser}' AND password_us = '{loginPassword}'";
                MySqlCommand command = new MySqlCommand(query, dataBase.getConnection());

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    adapter.Fill(table);
                }

                // Проверка на нажатый chekbox Rememberme для запоминания пользователя программой.

                if (table.Rows.Count == 1)
                {
                    if (Chekbox_RememberMe.IsChecked == true)
                    {
                        PoliFort.Properties.Settings.Default.UserrPassword = loginPassword;
                        PoliFort.Properties.Settings.Default.Save();
                    }

                    // Определение роли пользоваетеля
                    string userRole = table.Rows[0]["role_us"].ToString();

                    if (userRole == "Admin")
                        OpenMainWindow();
                    else
                        OpenSecondWindow();
                }
                else
                {
                    MessageBox.Show("Введен неверный логин или пароль. Повторите попытку еще раз.", "Ошибка", MessageBoxButton.OK);
                }
            } catch (Exception ex) {
                MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message, "Ошибка", MessageBoxButton.OK);
            }
        }

        private void Chip_Click(object sender, RoutedEventArgs e)  // Открытие формы регистрации
        {
            AddAccountWindow addAccountWindow = new AddAccountWindow();
            addAccountWindow.Show();
            this.Hide();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e) { }
    }
}

