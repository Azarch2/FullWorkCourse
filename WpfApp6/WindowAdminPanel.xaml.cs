using System.ComponentModel;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp6
{
    public partial class WindowAdminPanel : Window
    {
        public WindowAdminPanel()
        {
            InitializeComponent();
        }

        private void ClickDoubleMouse(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.MouseCheckClick.CheckClick == "ClickAdminPanelBackButton") 
            {
                ClickAdminPanelBackButton();
            }
        }
        private void AdminPanelBackButtonEnter(object sender, MouseEventArgs e)
        {
            MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            AdminPanelBackButton.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClickAdminPanelBackButton";
        }
        private void AdminPanelBackButtonLeave(object sender, MouseEventArgs e)
        {
            AdminPanelBackButton.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }
        public void ClickAdminPanelBackButton()
        {
            this.Visibility = Visibility.Hidden;
            MainWindow.ThisMainAuthWindow.Visibility = Visibility.Visible;
            MainWindow.ThisMainAuthWindow.AfterAuthGetAdmin.Visibility = Visibility.Hidden;
            MainWindow.ThisMainAuthWindow.AfterAuthAdminPanelButton.Visibility = Visibility.Visible;
            try
            {
                int counter = 0;
                using (VideoStorageContext db = new VideoStorageContext())
                {
                    foreach (User item in AdminPanelGrid1.Items)
                    {
                        User toChange = db.User.ToList().Find(us => us.Id == item.Id);
                        toChange.Email = item.Email;
                        toChange.Password = item.Password;
                        toChange.MaxStorage = item.MaxStorage;
                        toChange.Login = item.Login;
                        toChange.Role = item.Role;
                        counter++;
                    }
                    db.SaveChanges();
                    MessageBox.Show("Данные были успешно обновлены");
                }
            }
            catch
            {
                MessageBox.Show("Мы не смогли обновить данные, так как они были введены неверно");
            }
        }

        private void Close(object sender, CancelEventArgs e)
        {
          Application.Current.Shutdown();
        }
    }
}