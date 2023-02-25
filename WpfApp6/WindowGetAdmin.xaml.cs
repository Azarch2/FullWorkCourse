using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp6
{
    public partial class WindowGetAdmin : Window
    {
        public WindowGetAdmin()
        {
            InitializeComponent();
        }

        private void ClickDoubleMouse(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.MouseCheckClick.CheckClick == "ClicBackFromGetAdmin")
            {
                ClicBackFromGetAdmin();
            }
            if (MainWindow.MouseCheckClick.CheckClick == "ClicCheckPasswordFromGetAdmin")
            {
                ClicCheckPasswordFromGetAdmin();
            }
        }
        private void GetAdminBackEnter(object sender, MouseEventArgs e)
        {
            MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            GetAdminBackButton.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClicBackFromGetAdmin";
        }
        private void GetAdminBackLeave(object sender, MouseEventArgs e)
        {
            GetAdminBackButton.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }
        public void ClicBackFromGetAdmin()
        {
           MainWindow.ThisMainWindow.UpdateAllBoxes();
            if (MainWindow.CurrentUser.currentuser.Role == "User")
            {
                this.Visibility = Visibility.Hidden;
                MainWindow.ThisMainAuthWindow.Visibility = Visibility.Visible;
                //MainWindow.ThisMainAuthWindow.AfterAuthGetAdmin.Visibility = Visibility.Visible;

            }
            else if (MainWindow.CurrentUser.currentuser.Role == "Administrator")
            {
                this.Visibility = Visibility.Hidden;
                MainWindow.ThisMainAuthWindow.Visibility = Visibility.Visible;
                MainWindow.ThisMainAuthWindow.AfterAuthGetAdmin.Visibility = Visibility.Hidden;
                MainWindow.ThisMainAuthWindow.AfterAuthAdminPanelButton.Visibility = Visibility.Visible;
            }
        }
        private void GetAdminCheckPasswordEnter(object sender, MouseEventArgs e)
        {
            MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            GetAdminCheckPassword.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClicCheckPasswordFromGetAdmin";
        }
        private void GetAdminCheckPasswordLeave(object sender, MouseEventArgs e)
        {
            GetAdminCheckPassword.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }
        public void ClicCheckPasswordFromGetAdmin()
        {
            try
            {
                using (VideoStorageContext db = new VideoStorageContext())
                {
                    if (MainWindow.CurrentUser.currentuser.Role != "Administrator")
                    {
                        if (GetAdminTextBoxKey.Text == "111222333999")
                        {
                            foreach (User user in db.User)
                            {
                                if (user.Id == MainWindow.CurrentUser.currentuser.Id)
                                {
                                    user.Role = "Administrator";
                                    MainWindow.CurrentUser.currentuser.Role = "Administrator";
                                    user.MaxStorage = 524288;
                                    MainWindow.CurrentUser.currentuser.MaxStorage = 524288;
                                    MainWindow.ThisMainWindow.UpdateAllBoxes();
                                    MessageBox.Show("Вы успешно получили права администратора!");
                                }
                            }
                        }
                        else
                        {
                            MainWindow.ThisMainWindow.UpdateAllBoxes();
                            MessageBox.Show("Вы не верно ввели секретный ключ");
                        }
                    }
                    else
                    {
                        MainWindow.ThisMainWindow.UpdateAllBoxes();
                        MessageBox.Show("Вы уже получили права администратора!");
                    }

                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Вы что-то ввелм не верно, попробуйте снова");
            }
        }

        private void Close(object sender, CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            MainWindow.ThisMainAuthWindow.Visibility = Visibility.Visible;
        }
    }
}