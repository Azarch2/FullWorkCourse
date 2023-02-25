using System.Collections.Immutable;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp6
{
    public partial class WindowAuthorization : Window
    {
        public WindowAuthorization()
        {
            InitializeComponent();
        }

        private void ClickDoubleMouse(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.MouseCheckClick.CheckClick == "ClickAuthorization")
            {
                ClickAuthorization();
            }
            if (MainWindow.MouseCheckClick.CheckClick == "ClickBackFromAuth")
            {
                ClickBackFromAuth();
            }
        }
        public void ClickAuthorization()
        {
            //try
            //{
                using (VideoStorageContext db = new VideoStorageContext())
                {
                    int check = 0;
                    foreach (User user in db.User)
                    {
                        if (user.Login == AuthTextBoxLogin.Text && user.Password == AuthTextBoxPassword.Password)
                        {
                            if (user.Role == "User")
                            {
                                MessageBox.Show("Вы успешно авторизовались");
                                this.Visibility = Visibility.Hidden;
                                MainWindow.ThisMainAuthWindow.AfterAuthGetAdmin.Visibility = Visibility.Visible;
                                MainWindow.ThisMainAuthWindow.AfterAuthAdminPanelButton.Visibility = Visibility.Hidden;
                                MainWindow.ThisMainAuthWindow.Visibility = Visibility.Visible;
                            }
                            else if (user.Role == "Administrator")
                            {
                                MessageBox.Show("Вы успешно авторизовались");
                                this.Visibility = Visibility.Hidden;
                                MainWindow.ThisMainAuthWindow.AfterAuthAdminPanelButton.Visibility = Visibility.Visible;
                                MainWindow.ThisMainAuthWindow.AfterAuthGetAdmin.Visibility = Visibility.Hidden;
                                MainWindow.ThisMainAuthWindow.Visibility = Visibility.Visible;
                            }
                            MainWindow.CurrentUser.currentuser = user;
                            check++;
                            break;
                        }
                    }
                    if (check == 0)
                    {
                        MessageBox.Show("Вы неверно ввели логин или пароль");
                        MainWindow.ThisMainWindow.UpdateAllBoxes();
                    }
                }
            //}
            //catch
            //{
            //    MessageBox.Show("Вы что-то неверно ввели, попробуйте снова");
            //    MainWindow.ThisMainWindow.UpdateAllBoxes();
            //}
        }
        public void ClickBackFromAuth()
        {
           MainWindow.ThisMainWindow.UpdateAllBoxes();
            MainWindow.ThisMainWindow.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
        private void AuthTextEnter(object sender, MouseEventArgs e)
        {
           MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            AuthAuthButton.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClickAuthorization";
        }
        private void AuthTextLeave(object sender, MouseEventArgs e)
        {
            AuthAuthButton.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }
        private void AuthBackEnter(object sender, MouseEventArgs e)
        {
            MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            AuthBackButton.Foreground = brush;
            MainWindow. MouseCheckClick.CheckClick = "ClickBackFromAuth";
        }
        private void AuthBackLeave(object sender, MouseEventArgs e)
        {
            AuthBackButton.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }

        private void Close(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}