using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp6
{
    public partial class WindowRegistration : Window
    {
        public WindowRegistration()
        {
            InitializeComponent();
        }

        private void ClickDoubleMouse(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.MouseCheckClick.CheckClick == "ClickRegistrationRegister")
            {
                ClickRegistrationRegister();
            }
            if (MainWindow.MouseCheckClick.CheckClick == "ClickBackFromRegister")
            {
                ClickBackFromRegister();
            }
        }
        public void ClickBackFromRegister()
        {
            this.Visibility = Visibility.Hidden;
            MainWindow.ThisMainWindow.Visibility = Visibility.Visible;
        }

        private void RegisterTextLeave(object sender, MouseEventArgs e)
        {
            RegistrationRegisterButton.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow. MouseCheckClick.CheckClick = "";
        }
        private void RegisterTextEnter(object sender, MouseEventArgs e)
        {
            MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)RegistrationRegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            RegistrationRegisterButton.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClickRegistrationRegister";
        }
        private void RegisterBackEnter(object sender, MouseEventArgs e)
        {
            MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)RegistrationBackButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            RegistrationBackButton.Foreground = brush;
            MainWindow. MouseCheckClick.CheckClick = "ClickBackFromRegister";
        }
        private void RegisterBackLeave(object sender, MouseEventArgs e)
        {
            RegistrationBackButton.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }
        
        public void ClickRegistrationRegister()
        {
            //try
            //{
                using (VideoStorageContext db = new VideoStorageContext())
                {
                    int check = 0;
                    if (RegistrationTextBoxEmail.Text == "" || RegistrationTextBoxLogin.Text == "" || RegistrationTextBoxPassword.Password == "")
                    {
                        check = 2;
                    }
                    foreach (User user in db.User)
                    {
                        if (user.Login == RegistrationTextBoxLogin.Text || user.Email == RegistrationTextBoxEmail.Text)
                        {
                            check = 1;
                            break;
                        }
                    }
                    if (check == 0)
                    {
                        User UserToAdd = new User();
                        UserToAdd.Login = RegistrationTextBoxLogin.Text;
                        UserToAdd.Email = RegistrationTextBoxEmail.Text;
                        UserToAdd.Password = RegistrationTextBoxPassword.Password;
                        UserToAdd.MaxStorage = 65536;
                        UserToAdd.Storage = 0;
                        UserToAdd.Role = "User";
                        db.User.Add(UserToAdd);
                        MessageBox.Show("Вы успешно зарегистрировались");
                        MainWindow.ThisMainWindow.UpdateAllBoxes();
                        this.Visibility = Visibility.Hidden;
                        MainWindow.ThisMainWindow.Visibility = Visibility.Visible;
                    }
                    else if (check == 2)
                    {
                        MainWindow.ThisMainWindow.UpdateAllBoxes();
                        MessageBox.Show("Вы заполнили не все поля!");
                    }
                    else
                    {
                        MainWindow.ThisMainWindow.UpdateAllBoxes();
                        MessageBox.Show("Такой пользователь уже зарегистрирован");
                    }
                    db.SaveChanges();
                }
            //}
            //catch
            //{
            //    MessageBox.Show("Вы ввели неверные данные, повторите попытку");
            //}
        }

        private void Close(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}