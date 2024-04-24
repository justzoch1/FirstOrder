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
using SSSSTOCK;
using MaterialDesignThemes.Wpf;

using System.Text;
using System.Threading.Tasks;

using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using System.Windows.Forms;

namespace PoliFort
{
    public partial class MainMainWindow : Window
    {

        private DataBase dataBase = new DataBase();
        private bool isDarkTheme = false;


        private void Combobox_Table_SelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateDataGrid(); 

        private void Save_Click(object sender, RoutedEventArgs e) => SaveChangesToDatabase();
        private void Search_Chip_Click(object sender, RoutedEventArgs e)
        {
            var text = Search_Textbox.Text;
            SearchData(text);
        }

        public MainMainWindow()
        {

            InitializeComponent();
        }

        private void Click_Chip_GoOut(object sender, RoutedEventArgs e)  // Выход из аккаунта
        {
            Forget goOut = new Forget();
            goOut.ForgetMe();
        }

        private string GetSelectedDatabaseName() // Метод для получения выбранной пользователем таблицы.
        {
            string[] databaseOptions = { "users", "employees", "services", "reviews", "requests", "types_services" };
            int selectedIndex = Combobox_Table.SelectedIndex;
            return (selectedIndex >= 0 && selectedIndex < databaseOptions.Length) ? databaseOptions[selectedIndex] : "services";
        }

        public void UpdateDataGrid()  // Метод обновления данных в datagrid по выбору пользователя в combobox
        {
            try
            {
                dataBase.openConnetction();

                string selectedDatabase = GetSelectedDatabaseName();
                string cmd = "SELECT * FROM " + selectedDatabase;

                MySqlCommand createCommand = new MySqlCommand(cmd, dataBase.getConnection());

                // Получение данных
                MySqlDataAdapter dataAdp = new MySqlDataAdapter(createCommand);
                DataTable dt = new DataTable();
                dataAdp.Fill(dt);

                // Установка источника данных для DataGrid
                phonesGrid.ItemsSource = dt.DefaultView;

                // Привязка столбцов в DataGrid
                phonesGrid.Columns.Clear(); // Очищаем существующие столбцы

                foreach (DataColumn column in dt.Columns)
                {
                    // Создаем столбец только если он не соответствует скрываемому условию
                    if (!(selectedDatabase == "users" && column.ColumnName == "yesNo_us"))
                    {
                        MaterialDesignThemes.Wpf.DataGridTextColumn textColumn = new MaterialDesignThemes.Wpf.DataGridTextColumn()
                        {
                            Header = column.ColumnName,
                            Binding = new Binding(column.ColumnName) // Привязка данных
                        };
                        phonesGrid.Columns.Add(textColumn); // Добавление нового столбца
                    }
                }

                dataBase.CloseConnetction();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Ошибка", MessageBoxButton.OK);
            }
        }

        public void SearchData(string searchText) // Метод поиска по всем столбцам
        {
            try
            {
                string selectedDatabase = GetSelectedDatabaseName();
                DataTable dt = new DataTable();

                using (MySqlCommand searchCommand = new MySqlCommand($"SELECT * FROM {selectedDatabase} WHERE CONCAT(", dataBase.getConnection()))
                {
                    DataTable columnsTable = new DataTable();
                    new MySqlDataAdapter(new MySqlCommand($"SHOW COLUMNS FROM {selectedDatabase}", dataBase.getConnection())).Fill(columnsTable);

                    string searchColumns = string.Join(",", columnsTable.AsEnumerable().Select(row => row.Field<string>("Field")));
                    searchCommand.CommandText += searchColumns + $") LIKE '%{searchText}%'";
                    using (MySqlDataAdapter dataAdp = new MySqlDataAdapter(searchCommand))
                    {
                        dataAdp.Fill(dt);
                    }
                }

                phonesGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Ошибка", MessageBoxButton.OK);
            }
        }

        private void DeleteSelectedRow(string tableName, string idColumnName)  // Метод удаления выбранной строки
        {
            try
            {
                string Message = "Вы уверены, что хотите удалить эту строку?";
                if (MessageBox.Show(Message, "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    return;
                }

                // Получение ID строки
                int id = 0;
                DataRowView selectedRow = (DataRowView)phonesGrid.SelectedItem;
                if (selectedRow != null)
                {
                    id = Convert.ToInt32(selectedRow[idColumnName]);

                    // Формирование запроса DELETE
                    string sqlzapros = "DELETE FROM " + tableName + " WHERE " + idColumnName + " = " + id;

                    // Выполнение запроса
                    dataBase.openConnetction();
                    MySqlCommand command = new MySqlCommand(sqlzapros, dataBase.getConnection());
                    command.ExecuteNonQuery();
                    dataBase.CloseConnetction();

                    // Обновление DataGrid
                    UpdateDataGrid();
                }
                else
                {
                    MessageBox.Show("Ошибка! Не выбрана строка для удаления", "Ошибка", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении строки: " + ex.Message, "Ошибка", MessageBoxButton.OK);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e) // Вызов метода DeleteSelectedRow
        {
            switch (Combobox_Table.SelectedIndex)
            {
                case 0:
                    DeleteSelectedRow("users", "iduser");
                    break;
                case 1:
                    DeleteSelectedRow("employees", "idEmployee");
                    break;
                case 2:
                    DeleteSelectedRow("services", "idservices");
                    break;
                case 3:
                    DeleteSelectedRow("reviews", "idfeedback");
                    break;
                case 4:
                    DeleteSelectedRow("requests", "idrequest");
                    break;
                case 5:
                    DeleteSelectedRow("types_services", "idtypes");
                    break;
            }
        }

        public void SaveChangesToDatabase() // Сохранение изменений/добавление новых строк
        {
            try
            {
                string selectedDatabase = GetSelectedDatabaseName();
                dataBase.openConnetction();
                DataTable dt = ((DataView)phonesGrid.ItemsSource).Table;
                string cmd = "SELECT * FROM " + selectedDatabase;
                MySqlDataAdapter dataAdp = new MySqlDataAdapter(cmd, dataBase.getConnection());
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdp);
                dataAdp.Update(dt);
                UpdateDataGrid();
                dataBase.CloseConnetction();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Ошибка", MessageBoxButton.OK);
            }
        }

        private void Combobox_Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedTable = GetSelectedDatabaseName();

            if (selectedTable == "requests" || selectedTable == "services")
            {
                if (phonesGrid.ItemsSource is DataView dataView)
                {
                    if (Combobox_Filter.SelectedIndex == 0)
                    {
                        // Фильтрация по всем типам
                        dataView.RowFilter = string.Empty;
                    }
                    else
                    {
                        string selectedValue = ((ComboBoxItem)Combobox_Filter.SelectedItem).Content.ToString();
                        string[] parts = selectedValue.Split(new char[] { ':' });

                        string columnName = (selectedTable == "requests") ? "type_rst" : "type_sr";
                        string filterExpression = $"{columnName} = {parts[0].Trim()}";

                        dataView.RowFilter = filterExpression;
                    }
                }
                else { }
            }

        }

        private void Roll_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
    

 


