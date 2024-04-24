using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using static MaterialDesignThemes.Wpf.Theme;
using System.Reflection.Emit;
using System.Windows.Documents;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Windows.Data;
using System.Diagnostics.Metrics;
using System.ComponentModel;
using PoliFort;
using Google.Protobuf.WellKnownTypes;
using SSSSTOCK.ModalWindow;
using System.Windows.Navigation;
using System.Drawing;


using MaterialDesignThemes.Wpf;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PoliFort.PageUser
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : System.Windows.Controls.Page
    {
        private DataBase dataBase = new DataBase();

        public class Service
        {
            public int Code { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int Type { get; set; }
            public float Price { get; set; }
            
        }

        private bool isDarkTheme = false;
        bool AgreeStatus = PoliFort.Properties.Settings.Default.AgreeStatus;
        public MainPage()
        {
            InitializeComponent();
            UpdateListView();
            GoodFail.Visibility = Visibility.Hidden;
        }
        // request
        private int? IdServices
        {
            get
            {
                if (!string.IsNullOrEmpty(textbox_idservice.Text))
                    return Convert.ToInt32(textbox_idservice.Text);
                else
                    return null;
            }
        }
        private string FullName => textbox_login.Text;

        string UserName = PoliFort.Properties.Settings.Default.UserName;

        DateTime dateTime = DateTime.Now;
        private long Timestamp => (long)((DateTimeOffset)dateTime).ToUnixTimeSeconds();

        private string Status => "На рассмотрении";

        private int userId;
        private int typeID;
        private int FullNameEmp => 59;

        private void Click_Chip_GoOut(object sender, RoutedEventArgs e)
        {
            Forget goOut = new Forget();
            goOut.ForgetMe();
        }


        private void FindId()
        {
            
                dataBase.openConnetction();

                // Получение айдишника пользователя
                string queryIdUser = "SELECT iduser FROM users WHERE login_us = @UserName";
                MySqlCommand command = new MySqlCommand(queryIdUser, dataBase.getConnection());
                command.Parameters.AddWithValue("@UserName", UserName);
                object resultIdUser = command.ExecuteScalar();

                // Получение айди типа сервиса
                string queryIdType = "SELECT type_sr FROM services WHERE idservices = @IdTypeService";
                MySqlCommand commandt = new MySqlCommand(queryIdType, dataBase.getConnection());
                commandt.Parameters.AddWithValue("@IdTypeService", IdServices);
                object resultIdType = commandt.ExecuteScalar();

                if (resultIdUser != null && resultIdType != null)
                {
                    userId = (int)resultIdUser; 
                    typeID = (int)resultIdType; 
                }
                else
                {
                MessageBox.Show("Пересмотрите данные в строках", "Ошибка");
            }
            
   
                dataBase.CloseConnetction(); // Закрытие соединения с базой данных после завершения операций
            
        }

        private void Request_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FindId(); // вызов метода для поиска id
                dataBase.openConnetction();
                string queryAgreeStatus = "select yesNo_us FROM users WHERE login_us = @UserName";
                MySqlCommand commandAgreeStatus = new MySqlCommand(queryAgreeStatus, dataBase.getConnection());
                commandAgreeStatus.Parameters.AddWithValue("@UserName", UserName);
                string yesNo = Convert.ToString(commandAgreeStatus.ExecuteScalar());

                if (yesNo == "True")
                {
                    string querystring = $"insert into requests(login_us_id_rst, services_id_rst, status_is_rst, type_rst, fullname_client, empoyee_rst, time_rst) values(@userId, @IdServices, @Status, @typeID, @FullName, @FullNameEmp, FROM_UNIXTIME(@Timestamp))";

                    MySqlCommand command = new MySqlCommand(querystring, dataBase.getConnection());
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@IdServices", IdServices);
                    command.Parameters.AddWithValue("@Status", Status);
                    command.Parameters.AddWithValue("@FullNameEmp", FullNameEmp);
                    command.Parameters.AddWithValue("@typeID", typeID);
                    command.Parameters.AddWithValue("@FullName", FullName);
                    command.Parameters.AddWithValue("@Timestamp", Timestamp);

                    if (command.ExecuteNonQuery() == 1)
                    {
                        GoodFail.Content = "Запись прошла успешно.";
                        GoodFail.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        GoodFail.Content = "Запись не прошла.";
                        GoodFail.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    MessageBox.Show("Перед тем как оставлять заявку пожалуйста прочтите договор", "Предупреждение");
                }
            }
            catch (MySqlException ex)
            {
                // Обработка ошибки, если возникла MySqlException
                GoodFail.Content = "Запись не прошла.";
                GoodFail.Visibility = Visibility.Visible;
            }

            finally
            {
                dataBase.CloseConnetction();
            }
        }

        public void UpdateListView()
        {
            usersList.Items.Clear();
            MySqlDataReader reader = null;
            try
            {
                dataBase.openConnetction();
                string cmd = "SELECT * FROM services";
                MySqlCommand createCommand = new MySqlCommand(cmd, dataBase.getConnection());
                reader = createCommand.ExecuteReader();
                List<Service> services = new List<Service>();

                while (reader.Read())
                {
                    Service service = new Service
                    {
                        Code = Convert.ToInt32(reader["idservices"]),
                        Type = Convert.ToInt32(reader["type_sr"]),
                        Description = reader["description_sr"].ToString(),
                        Title = reader["name_sr"].ToString(),
                        Price = Convert.ToInt32(reader["price_sr"])
                    };
                    services.Add(service);
                }
                usersList.ItemsSource = services;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
            }
        }

        private void Search_Textbox_Changed(object sender, TextChangedEventArgs e)
        {
            string searchText = Search_Textbox.Text.ToLower();

            ICollectionView view = CollectionViewSource.GetDefaultView(usersList.ItemsSource);
            if (view != null)
            {
                view.Filter = item =>
                {
                    Service service = item as Service;
                    if (int.TryParse(Search_Textbox.Text, out int intValue))
                    {
                        return service.Code.ToString().ToLower().Contains(searchText) || service.Price.ToString().Contains(searchText) || service.Type.ToString().Contains(searchText);
                    }
                    else if (!string.IsNullOrEmpty(Search_Textbox.Text))
                    {
                        return service.Title.ToLower().Contains(searchText) || service.Description.ToLower().Contains(searchText);
                    }
                    else
                    {
                        return true;
                    }
                };
            }
        }

        private int GetSelectedType()
        {
            int[] databaseOptions = { 0, 1, 2, 3, 4, 5 };
            int selectedIndex = Combobox_Filter.SelectedIndex;
            return (selectedIndex >= 0 && selectedIndex < databaseOptions.Length) ? databaseOptions[selectedIndex] : 0;

        }

        private void Combobox_Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedType = GetSelectedType();

            ICollectionView view = CollectionViewSource.GetDefaultView(usersList.ItemsSource);
            if (view != null)
            {
                if (selectedType == 0) // Если выбрано "Все типы"
                {
                    view.Filter = null; // Отключаем фильтрацию
                }
                else
                {
                    view.Filter = item =>
                    {
                        Service service = item as Service;
                        return service.Type == selectedType;
                    };
                }
            }
        }
       
       private void GotoSecond_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new PageUser.StatusRequestsPage());

        private void GoToDokument_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new PageUser.ContractPage());

        private void Theme_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"/Theme/DarkDictionary.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary; Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void Theme_Click_Dark(object sender, RoutedEventArgs e)
        {
            isDarkTheme = !isDarkTheme;
            UpdateTheme();
            
        }

        private void UpdateTheme()
        {

            if (isDarkTheme)
            {
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri("\\Theme\\DarkDictionary.xaml", UriKind.Relative)
                    
                });
                PoliFort.Properties.Settings.Default.ThisTheme = "Dark";

            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri("\\Theme\\WhiteDictionary.xaml", UriKind.Relative)
                });
                PoliFort.Properties.Settings.Default.ThisTheme = "White";
            }
        }

        private void Roll_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Window.GetWindow(this).WindowState = WindowState.Minimized;
        }
    }
}
