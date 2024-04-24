using System;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Controls;

using static MaterialDesignThemes.Wpf.Theme;
using System.Reflection.Emit;
using System.Windows.Documents;
using System.Windows.Input;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Windows.Data;
using System.Diagnostics.Metrics;
using System.ComponentModel;
using PoliFort;

namespace PoliFort
{
    
    public partial class MainPolifortUser : Window
    {
        private DataBase dataBase = new DataBase();
        public MainPolifortUser()
        {
            InitializeComponent();
            UserMainWindow.Content = new PageUser.MainPage();
        }
    }
}
