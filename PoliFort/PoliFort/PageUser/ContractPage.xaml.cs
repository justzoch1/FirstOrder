
using Microsoft.Office.Interop.Word;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data;
using PoliFort;
using MySql.Data.MySqlClient;
using SSSSTOCK;
using SSSSTOCK.ModalWindow;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;


namespace PoliFort.PageUser
{
    public partial class ContractPage : System.Windows.Controls.Page
    {
        // Получение ассетов

        private DataBase dataBase = new DataBase();
        private string UserName = PoliFort.Properties.Settings.Default.UserName;
        private static string Email;
        private static string DocxPath;

        public ContractPage()
        {
            InitializeComponent();
            System.Threading.Tasks.Task.Run(async () => await LoadDocxDocument());
        }

        private async void GoToEmail_Click(object sender, RoutedEventArgs e) => await SendMailAsync();

        private void GoToPrinter_Click(object sender, RoutedEventArgs e) // Вызов метода принта
        {
            string relativePath = "Assets\\Договор_об_оказании_услуг.pdf";
            string absolutePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), relativePath);

            PrintFile(absolutePath);
        }

        public async System.Threading.Tasks.Task LoadDocxDocument()  // Асинхронный метод отражения документа
        {
            string relativePath = "Assets\\Договор_об_оказании_услуг.docx";
            string absolutePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), relativePath);

            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Document doc = wordApp.Documents.Open(absolutePath);
            string content = doc.Content.Text;
            doc.Close();
            wordApp.Quit();
            await Dispatcher.InvokeAsync(() => { RichBox.AppendText(content); });
            DocxPath = absolutePath;
        }

        private static async System.Threading.Tasks.Task SendMailAsync() // Асинхронный метод отправки сообщения пользователю
        {
            ModalWindowEmail modalWindow = new ModalWindowEmail();

            if (modalWindow.ShowDialog() == true && modalWindow.Email != null)
            {
                Email = (string)modalWindow.Email;
                try
                {
                    MailAddress from = new MailAddress("business@gmail.com", "Business"); // Укажите почту отправителя и имя( Любое)
                    MailAddress to = new MailAddress(Email);
                    System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(from, to);
                    message.Subject = "Text";
                    message.Body = "<h2>Вашему вниманию предоставлена копия договора компании 'Business'</h2>";
                    Attachment attachment = new Attachment(DocxPath);
                    message.Attachments.Add(attachment);
                    message.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587); // Укажите порт клиента вашей почты. Здесь указан пример для почты gmail. 

                    smtp.Credentials = new NetworkCredential("business@gmail.com", "key key key key"); // Почта и пароль отправителя(Пароль для внешних приложений)
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    MessageBox.Show("Сообщение успешно отправлено.", "Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при отправке сообщения: " + ex.Message, "Ошибка");
                }
            }
        }

        // Метод печати пдф документа

        private void PrintFile(string filePath) 
        {

            if (System.IO.File.Exists(filePath))
            {
                try
                {
                    ProcessStartInfo info = new ProcessStartInfo
                    {
                        Verb = "print",
                        FileName = filePath,
                        UseShellExecute = true
                    };

                    Process.Start(info);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Файл не найден по указанному пути.", "Ошибка");
            }
        }

        private void ChekBox_Agree_Checked(object sender, RoutedEventArgs e) // Проверка статуса прочтения договора
        {
            dataBase.openConnetction();
            string agreementStatus = ChekBox_Agree.IsChecked == true ? "True" : "False";
            string query = "UPDATE users SET yesNo_us = @AgreementStatus WHERE login_us = @UserName";
            MySqlCommand command = new MySqlCommand(query, dataBase.getConnection());
            command.Parameters.AddWithValue("@AgreementStatus", agreementStatus);
            command.Parameters.AddWithValue("@UserName", UserName);
            if (command.ExecuteNonQuery() == 1) { } else { MessageBox.Show("Ошибка: не удалось обновить статус согласия", "Ошибка"); }
            dataBase.CloseConnetction();
        }

        private void Click_Chip_GoOut(object sender, RoutedEventArgs e)
        {
            Forget goOut = new Forget();
            goOut.ForgetMe();
        }

        private void GotoSecond_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new PageUser.MainPage());

        private void Roll_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Window.GetWindow(this).WindowState = WindowState.Minimized;
        }
    }
}
