using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Windows;
using System;

namespace PoliFort
{
    internal class DataBase
    {

        public MySqlConnection sqlConnection = new MySqlConnection("server=YOURSERVERNAME;user=YOURUSERNAME;database=YOURDATABSENAME;password=YOURPASSWORD");
        public void openConnetction()
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message, "Ошибка", MessageBoxButton.OK);
            }

        }

        public void CloseConnetction()
        {
            try {  sqlConnection.Close(); }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message, "Ошибка", MessageBoxButton.OK);
            }
        }

        public MySqlConnection getConnection()
        {
            return sqlConnection;
        }
    }
}