using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PoliFort
{
    internal class Forget
    {
        public void ForgetMe()
        {
            string Message = "Вы точно хотите выйти из аккаунта?";
            if (MessageBox.Show(Message, "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }
            // Сбросить сохраненные данные пользователя
            PoliFort.Properties.Settings.Default.UserName = string.Empty;
            PoliFort.Properties.Settings.Default.UserrPassword = string.Empty;
            PoliFort.Properties.Settings.Default.Save();
            Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            currentWindow.Close();

            // Закрыть главное окно
            AuthorizationWindow addAccountWindow = new AuthorizationWindow();
            addAccountWindow.Show();
            
        }
    }
}
