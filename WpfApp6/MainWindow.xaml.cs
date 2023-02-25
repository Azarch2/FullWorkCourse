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
using Microsoft.Win32;
using System.Threading;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Windows.Interop;
using System.Windows.Media.Animation;
using BLSoft;
using Color = System.Windows.Media.Color;
using Image = System.Windows.Controls.Image;

namespace WpfApp6
{
    public partial class MainWindow : Window
    {
        public static VideoStorageContext db = new VideoStorageContext();
        public static MainWindow ThisMainWindow;
        public static WindowAddAuthorOfVideo ThisAddAuthorOhVideoWindow = new WindowAddAuthorOfVideo();
        public static WindowAddPlaceOfVideo ThisAddPlaceOhVideoWindow = new WindowAddPlaceOfVideo();
        public static WindowRegistration ThisRegistrationWindow = new WindowRegistration();
        public static WindowAuthorization ThisAuthorizationWindow = new WindowAuthorization();
        public static WindowMainAuthWindow ThisMainAuthWindow = new WindowMainAuthWindow();
        public static WidnowChangePassword ThisChangePasswordWindow = new WidnowChangePassword();
        public static WindowGetAdmin ThisGetAdminWindow = new WindowGetAdmin();
        public static WindowChoosedVideo ThisChoosedVideoWindow = new WindowChoosedVideo();
        public static WindowAdminPanel ThisAdminPanelWindow = new WindowAdminPanel();
        public static WindowCheckVideo ThisCheckVideoWindow = new WindowCheckVideo();
        public static WindowVideoPlayer ThisVideoPlayerWindow = new WindowVideoPlayer();
        public static WindowCatalog ThisCatalogWindow = new WindowCatalog();

        public static WindowChooseCatalogWhenAddVideo ThisChooseCatalogWhenAddVideoWindow = new WindowChooseCatalogWhenAddVideo();
        public MainWindow()
        {
            InitializeComponent();

            ThisMainWindow = this;
            ThisAddAuthorOhVideoWindow.Visibility = Visibility.Hidden;
            ThisAddPlaceOhVideoWindow.Visibility = Visibility.Hidden;
        }


        public void UpdateAllBoxes()
        {
            ThisRegistrationWindow.RegistrationTextBoxLogin.Text = "";
            ThisRegistrationWindow.RegistrationTextBoxEmail.Text = "";
            ThisRegistrationWindow.RegistrationTextBoxPassword.Password = "";
            ThisGetAdminWindow.GetAdminTextBoxKey.Text = "";
            ThisChangePasswordWindow.ChangePasswordTextBoxLogin.Text = "";
            ThisChangePasswordWindow.ChangePasswordBoxPassword.Text = "";
            ThisAuthorizationWindow.AuthTextBoxPassword.Password = "";
            ThisAuthorizationWindow.AuthTextBoxLogin.Text = "";
            ThisAddAuthorOhVideoWindow.AddAuthorTextBoxCountry.Text = "";
            ThisAddAuthorOhVideoWindow.AddAuthorTextBoxEmail.Text = "";
            ThisAddAuthorOhVideoWindow.AddAuthorTextBoxHouse.Text = "";
            ThisAddAuthorOhVideoWindow.AddAuthorTextBoxName.Text = "";
            ThisAddAuthorOhVideoWindow.AddAuthorTextBoxStreet.Text = "";
            ThisAddAuthorOhVideoWindow.AddAuthorTextBoxSurname.Text = "";
        }
        public static class CurrentVideoAll
        {
            public static string VIDEOnameFull = "";

            public static Video CurrentImage = new Video();
        }
        
        public static class NumberOfPage
        {
            public static int CurrrentPage;
        }
        public static class CurrentUser
        {
            public static User currentuser;
        }

        public static class CurrentCatalog
        {
            public static Catalog catalog;
        }

        public static class MouseCheckClick
        {
            public static string CheckClick = "";
            public static SolidColorBrush LastColor;
            public static SolidColorBrush BrushStandart = new SolidColorBrush(Color.FromRgb(94, 37, 128));
        }

        public void ClickRegister()
        {

            UpdateAllBoxes();
            this.Visibility = Visibility.Hidden;
            ThisRegistrationWindow.Visibility = Visibility.Visible;
        }

        public void ClickAuth()
        {
            UpdateAllBoxes();
            this.Visibility = Visibility.Hidden;
            ThisAuthorizationWindow.Visibility = Visibility.Visible;
        }

        private void ClickDoubleMouse(object sender, MouseButtonEventArgs e)
        {
            if (MouseCheckClick.CheckClick == "ClickRegister")
            {
                ClickRegister();
            }
            if (MouseCheckClick.CheckClick == "ClickAuth")
            {
                ClickAuth();
            }
        }
        private void RegistrationMouseEnter(object sender, MouseEventArgs e)
        {
            MouseCheckClick.LastColor = (SolidColorBrush)RegisterButton.Foreground;
            SolidColorBrush brush = MouseCheckClick.BrushStandart;
            RegisterButton.Foreground = brush;
            MouseCheckClick.CheckClick = "ClickRegister";
        }
        private void RegistrationLeave(object sender, MouseEventArgs e)
        {
            RegisterButton.Foreground = MouseCheckClick.LastColor;
            MouseCheckClick.CheckClick = "";
        }
        private void AuthMouseEnter(object sender, MouseEventArgs e)
        {
            MouseCheckClick.LastColor = (SolidColorBrush)RegisterButton.Foreground;
            SolidColorBrush brush = MouseCheckClick.BrushStandart;
            AuthButton.Foreground = brush;
            MouseCheckClick.CheckClick = "ClickAuth";
        }
        private void AuthLeave(object sender, MouseEventArgs e)
        {
            AuthButton.Foreground = MouseCheckClick.LastColor;
            MouseCheckClick.CheckClick = "";
        }

        private void Close(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
