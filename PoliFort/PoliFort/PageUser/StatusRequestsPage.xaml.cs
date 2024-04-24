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
#pragma warning disable CS0105 // Директива Using уже использовалась в этом пространстве имен
using PoliFort;
#pragma warning restore CS0105 // Директива Using уже использовалась в этом пространстве имен
using static PoliFort.PageUser.MainPage;
using System.Windows.Navigation;
using MaterialDesignThemes.Wpf;

namespace PoliFort.PageUser
{
    public partial class StatusRequestsPage : Page
    {
        public StatusRequestsPage()
        {
            InitializeComponent();
            UpdateListView();
        }

        private void GotoSecond_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new PageUser.MainPage());
        private void usersList_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

        private DataBase dataBase = new DataBase();

        string UserName = PoliFort.Properties.Settings.Default.UserName;
        double SelectedStars => ratingBar.Value;
        string CodeFb => TextBoxCode.Text;
        string DescriptionFb => TextBoxFeedback.Text;
        public int UserId { get; private set; }

        public class RequestItem
        {
            public int CodeReq { get; set; }
            public string TitleReq { get; set; }
            public string StatusReq { get; set; }
            public string EmployeeReq { get; set; }
            public float PriceReq { get; set; }

        }
        
        // Отражение данных для listview
        public void UpdateListView()
        {
            usersList.Items.Clear();
            try
            {
                dataBase.openConnetction();

                // Получаем id пользователя по fullname
                string queryUserId = "SELECT iduser FROM users WHERE login_us = @UserName";
                MySqlCommand commandUserId = new MySqlCommand(queryUserId, dataBase.getConnection());
                commandUserId.Parameters.AddWithValue("@UserName", UserName);
                UserId = Convert.ToInt32(commandUserId.ExecuteScalar());

                // Получаем информацию о заявках и услугах
                string queryRequests = $@"SELECT r.idrequest AS RequestID, s.name_sr AS ServiceName, e.fullname_emp AS Employee, s.price_sr AS Price, r.status_is_rst AS Status
FROM `ISPr23-35_KoshelevaYA_OOO_Polifort1`.requests r 
INNER JOIN `ISPr23-35_KoshelevaYA_OOO_Polifort1`.services s ON r.services_id_rst = s.idservices
INNER JOIN `ISPr23-35_KoshelevaYA_OOO_Polifort1`.employees e ON r.empoyee_rst = e.idEmployee
WHERE r.login_us_id_rst = {UserId}"
    ;

                MySqlCommand commandRequests = new MySqlCommand(queryRequests, dataBase.getConnection());
                commandRequests.Parameters.AddWithValue("@UserId", UserId);

                // Создаем адаптер данных и заполняем им DataTable
                MySqlDataAdapter adapter = new MySqlDataAdapter(commandRequests);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Создаем список объектов для представления информации
                List<RequestItem> requestItems = new List<RequestItem>();
                foreach (DataRow row in dataTable.Rows)
                {
                    requestItems.Add(new RequestItem
                    {
                        CodeReq = Convert.ToInt32(row["RequestID"]),
                        TitleReq = row["ServiceName"].ToString(),
                        EmployeeReq = row["Employee"] == null ? "Гуляев не определенен" : row["Employee"].ToString(),
                        PriceReq = Convert.ToInt32(row["Price"]),
                        StatusReq = row["Status"].ToString()
                    });
                }

                // Привязываем данные к ListView
                usersList.ItemsSource = requestItems;

                dataBase.CloseConnetction();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Ошибка", MessageBoxButton.OK);
            }
        }

        private void Click_Chip_GoOut(object sender, RoutedEventArgs e)
        {
            Forget goOut = new Forget();
            goOut.ForgetMe();
        }


        private void Search_Textbox_Changed(object sender, TextChangedEventArgs e)
        {
            string searchText = Search_Textbox.Text.ToLower();

            ICollectionView view = CollectionViewSource.GetDefaultView(usersList.ItemsSource);
            if (view != null)
            {
                view.Filter = item =>
                {
                    RequestItem service = item as RequestItem;
                    if (int.TryParse(Search_Textbox.Text, out int intValue))
                    {
                        return service.CodeReq.ToString().ToLower().Contains(searchText) || service.PriceReq.ToString().Contains(searchText) || service.PriceReq.ToString().Contains(searchText);
                    }
                    else if (!string.IsNullOrEmpty(Search_Textbox.Text))
                    {
                        return service.TitleReq.ToLower().Contains(searchText) || service.EmployeeReq.ToLower().Contains(searchText) ||  service.StatusReq.ToLower().Contains(searchText);
                    }
                    else
                    {
                        return true;
                    }
                };
            }
        }

        private void Request_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dataBase.openConnetction();
                string queryFeedBack = $"insert into reviews(code_rq_fb, user_id_fb, description_fb, score_fb) values(@CodeFb, @UserId, @DescriptionFb, @SelectedStars)";
                MySqlCommand commandFeedBack = new MySqlCommand(queryFeedBack, dataBase.getConnection());
                commandFeedBack.Parameters.AddWithValue("@CodeFb", CodeFb);
                commandFeedBack.Parameters.AddWithValue("@UserId", UserId);
                commandFeedBack.Parameters.AddWithValue("@DescriptionFb", DescriptionFb);
                commandFeedBack.Parameters.AddWithValue("@SelectedStars", SelectedStars);

                if (commandFeedBack.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Отзыв успешно добавлен", "Ошибка", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Возникла ошибка. Пожалуйста повторите попытку позже", "Ошибка", MessageBoxButton.OK);
                }
                dataBase.CloseConnetction();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Ошибка", MessageBoxButton.OK);
            }
        }

        private void Roll_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Window.GetWindow(this).WindowState = WindowState.Minimized;
        }
    }
}


