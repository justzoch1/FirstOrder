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
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;
using static MaterialDesignThemes.Wpf.Theme;
using Google.Protobuf.WellKnownTypes;
using SSSSTOCK;
using SSSSTOCK.ModalWindow;
using PoliFort;
namespace PoliFort
{
    public partial class AddAccountWindow : Window
    {
        
        DataBase dataBase = new DataBase();
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private string Password => Hesh.hashPassword((string)TextBox_New_Passwword.Text);
        private string Login => (string)TextBox_New_Login.Text;
        private string Role
        {
            get
            {
                if (YourRole.SelectedItem != null)
                {
                    return (string)(YourRole.SelectedItem as ComboBoxItem).Content;
                }
                else
                {
                    return string.Empty; // Или другое стандартное значение по вашему выбору
                }
            }
        }

        DateTime dateTime = DateTime.Now;
        private long timestamp => (long)((DateTimeOffset)dateTime).ToUnixTimeSeconds();
        private string Agree = "False";
        public AddAccountWindow()
        {
            InitializeComponent();
        }

        // Проверка на существования пользователя
        public Boolean chekuser()
        {

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select iduser, login_us, password_us from users where login_us = '{Login}' and password_us = '{Password}'";
            MySqlCommand command = new MySqlCommand(querystring, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует. Повторите попытку", "Провал!", MessageBoxButton.OK);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Go_Back_Click(object sender, RoutedEventArgs e)
        {
            if (chekuser()) { return; }

            // В случае если пользователь выбрал роль Admin

            if (Role == "Admin")
            {
                ModalWindow modalWindow = new ModalWindow();
                if (modalWindow.ShowDialog() == true)
                {
                    if (modalWindow.Password == "9999")
                    {
                        modalWindow.Close();
                        CreateAccount();
                    }
                    else
                    {
                        MessageBox.Show("Неверный код");
                    }

                } else { MessageBox.Show("Повторите попытку позже"); }

            } else { CreateAccount(); }
        }

        private void CreateAccount()
        {
            if (Role != string.Empty && Role != null)
            {
                string querystring = $"insert into users(login_us, password_us, role_us, create_time_us, yesNo_us) values('{Login}', '{Password}', '{Role}', FROM_UNIXTIME({timestamp}), '{Agree}')";

                MySqlCommand command = new MySqlCommand(querystring, dataBase.getConnection());
                dataBase.openConnetction();

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Аккаунт успешно создан! Приятного пользования.", "Успешно!", MessageBoxButton.OK);
                    this.Hide();
                    AuthorizationWindow mainwindow = new AuthorizationWindow();
                    mainwindow.Show();
                }
                else
                {
                    MessageBox.Show("Не удалось создать аккаунт. Повторите попытку.", "Ошибка", MessageBoxButton.OK);
                }
                dataBase.CloseConnetction();
            }
            else
                MessageBox.Show("Введите роль.");

        }

        private void Password_New_TextChanged(object sender, TextChangedEventArgs e) => TextBox_New_Passwword.MaxLength = 8;

        private void Login_New_TextChanged(object sender, TextChangedEventArgs e) => TextBox_New_Passwword.MaxLength = 20;
    }
}