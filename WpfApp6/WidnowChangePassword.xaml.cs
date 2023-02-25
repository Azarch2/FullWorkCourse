using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp6
{
    public partial class WidnowChangePassword : Window
    {
        public WidnowChangePassword()
        {
            InitializeComponent();
        }

        private void ClickDoubleMouse(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.MouseCheckClick.CheckClick == "ClickBackFromChangePassword")
            {
                ClickBackFromChangePassword();
            }
            if (MainWindow.MouseCheckClick.CheckClick == "ClickChangePasswordFromChangePassword") //Изменение пароля пользователя
            {
                ClickChangePasswordFromChangePassword();
            }
        }
        private void ChangePasswordBackEnter(object sender, MouseEventArgs e)
        {
           MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            ChangePasswordBackButton.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClickBackFromChangePassword";
        }
        private void ChangePasswordBackLeave(object sender, MouseEventArgs e)
        {
            ChangePasswordBackButton.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }
        public void ClickBackFromChangePassword()
        {
            this.Visibility = Visibility.Hidden;
            MainWindow.ThisMainAuthWindow.Visibility = Visibility.Visible;
        }
        private void ChangePasswordChangeButtonEnter(object sender, MouseEventArgs e)
        {
            MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            ChangePasswordChangeButton.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClickChangePasswordFromChangePassword";
        }
        private void ChangePasswordChangeButtonLeave(object sender, MouseEventArgs e)
        {
            ChangePasswordChangeButton.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }
        public void ClickChangePasswordFromChangePassword()
        {
            try
            {
                using (VideoStorageContext db = new VideoStorageContext())
                {
                    if (ChangePasswordTextBoxLogin.Text != "" && ChangePasswordBoxPassword.Text != "")
                    {
                        if (MainWindow.CurrentUser.currentuser.Password == ChangePasswordTextBoxLogin.Text)
                        {
                            MainWindow.CurrentUser.currentuser.Password = ChangePasswordTextBoxLogin.Text;
                            foreach (User user in db.User)
                            {
                                if (user.Id == MainWindow.CurrentUser.currentuser.Id)
                                {
                                    user.Password = ChangePasswordBoxPassword.Text;
                                    MessageBox.Show("Вы успешно изменили свой пароль!");
                                    this.Visibility = Visibility.Hidden;
                                    MainWindow.ThisMainAuthWindow.Visibility = Visibility.Visible;
                                    MainWindow.CurrentUser.currentuser.Password = ChangePasswordBoxPassword.Text;
                                    break;
                                }
                            }
                            db.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show("Вы неверно указали ваш старый пароль");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы заполнили не все поля!");
                    }
                    db.SaveChanges();
                }
            }
            catch
            {
                MainWindow.ThisMainWindow.UpdateAllBoxes();
                MessageBox.Show("Вы что-то ввели не верное, повторите попытку");
            }
        }

        private void Close(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}