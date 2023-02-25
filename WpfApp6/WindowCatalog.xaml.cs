using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfApp6
{
    public partial class WindowCatalog : Window
    {
        public static Catalog currentCatalogChoosed;
        public WindowCatalog()
        {
            InitializeComponent();

        }
        private void ClickDoubleMouse(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.MouseCheckClick.CheckClick == "ClicBackFromWindowCatalog") 
            {
                this.Visibility = Visibility.Hidden;
                MainWindow.ThisMainAuthWindow.Visibility = Visibility.Visible;
            }
            if (MainWindow.MouseCheckClick.CheckClick == "ClicAddCatalogFromCatalog")
            {
                InputBox.Visibility = Visibility.Visible;
            }
            if (MainWindow.MouseCheckClick.CheckClick == "ClicChangeNameOfCatalog")
            {
                InputChangeBox.Visibility = Visibility.Visible;
            }
        }
        private void OpenCatalogClick(object sender, RoutedEventArgs e)
        {
            using (VideoStorageContext db = new VideoStorageContext())
            {
                Catalog cat = db.Catalog.Where(catalog => catalog.Id == ((sender as Button).DataContext as Catalog).Id).FirstOrDefault();
                MainWindow.CurrentCatalog.catalog = cat;
                int count1 = MainWindow.CurrentCatalog.catalog.Video.Count;
            }
            this.Visibility = Visibility.Hidden;
            LoadVideosOfCurrentCatalogChoosed();
        }
        public void LoadVideosOfCurrentCatalogChoosed()
        {
            MainWindow.NumberOfPage.CurrrentPage = 0;
            MainWindow.ThisCheckVideoWindow.CheckVideoLastButton.Visibility = Visibility.Hidden;
            MainWindow.ThisCheckVideoWindow.CheckVideoNextButton.Visibility = Visibility.Hidden;
            try
            {
                MainWindow.ThisCheckVideoWindow.CheckVideoStackPanel.Children.Clear();
                using (VideoStorageContext db = new VideoStorageContext())
                {
                    foreach (User user in db.User)
                    {
                        if (user.Id == MainWindow.CurrentUser.currentuser.Id)
                        {
                            int count1 = db.Video.ToList().Count;
                            if (MainWindow.CurrentCatalog.catalog.Video.Count > 2)
                            {
                                MainWindow.ThisCheckVideoWindow.CheckVideoNextButton.Visibility = Visibility.Visible;
                            }

                            if (MainWindow.CurrentCatalog.catalog.Video.Count <= 0)
                            {
                                MessageBox.Show("Каталог пустой");
                                this.Visibility = Visibility.Visible;
                                return;
                            }
                            ///   MessageBox.Show("CurrentPage: " + NumberOfPage.CurrrentPage);
                            for (int i = MainWindow.NumberOfPage.CurrrentPage * 2; i < (MainWindow.NumberOfPage.CurrrentPage * 2) + 2; i++)
                            {
                                StackPanel PanelToAdd = new StackPanel();
                                PanelToAdd.Width = 245;
                                PanelToAdd.Margin = new Thickness(10, 0, 10, 0);
                                PanelToAdd.Height = MainWindow.ThisCheckVideoWindow.CheckVideoStackPanel.Height + 30;
                                PanelToAdd.Orientation = Orientation.Vertical;
                                Image image = new Image();
                                TextBlock textblock = new TextBlock();
                                textblock.FontSize = 14;
                                textblock.FontWeight = FontWeights.Bold;
                                textblock.TextAlignment = TextAlignment.Center;
                                    // int count = db.Video.ToList().Count;
                                    //MessageBox.Show("CountIst" + MainWindow.CurrentCatalog.catalog.Video.ToList().Count);
                            using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(MainWindow.CurrentCatalog.catalog.Video.ToList()[i].Preview)))
                            {
                                    textblock.Text = MainWindow.CurrentCatalog.catalog.Video.ToArray()[i].Name;
                                   // textblock.Text = MainWindow.db.Video.Where(vid => vid.UserId == user.Id).ToList().FirstOrDefault().Preview;
                                    image.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                                    //MessageBox.Show("Image width: " + image.Width);

                            }
                                image.Width = 245;
                                image.Margin = new Thickness(0, 0, 10, 0);
                                image.Height = MainWindow.ThisCheckVideoWindow.CheckVideoStackPanel.Height - 20;
                                PanelToAdd.Children.Add(image);
                                PanelToAdd.Children.Add(textblock);
                                PanelToAdd.MouseEnter += new MouseEventHandler(MouseEnter);
                                PanelToAdd.MouseLeave += new MouseEventHandler(MouseLeave);
                                MainWindow.ThisCheckVideoWindow.CheckVideoStackPanel.Children.Add(PanelToAdd);
                            }
                        }
                    }
                }
            }
            catch
            {

            }
            MainWindow.ThisMainAuthWindow.Visibility = Visibility.Hidden;
            MainWindow.ThisCheckVideoWindow.Visibility = Visibility.Visible;
        }
        private void MouseEnter(object sender, MouseEventArgs e)
        {
            StackPanel panel1 = (StackPanel)e.Source;
            TextBlock text = (TextBlock)panel1.Children[1];
            MainWindow.CurrentVideoAll.VIDEOnameFull = text.Text;
        }
        private void MouseLeave(object sender, MouseEventArgs e)
        {
            MainWindow.CurrentVideoAll.VIDEOnameFull = "";
        }

        private void RemoveCatalog(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить каталог?", "Сделайте выбор", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Catalog toremove = MainWindow.db.Catalog.Where(catalog=> catalog.Id == ((sender as Button).DataContext as Catalog).Id).FirstOrDefault();
                MainWindow.db.Catalog.Remove(toremove);
                MainWindow.db.SaveChanges();
                try
                {
                    User User = MainWindow.db.User.Where(user => user.Id == MainWindow.CurrentUser.currentuser.Id).FirstOrDefault();
                    User.Storage = 0;
                    foreach (Catalog cat in User.Catalog)
                    {
                        cat.TotalSize = 0;
                        foreach (Video vid in cat.Video)
                        {
                            cat.TotalSize += vid.Size;
                            User.Storage += vid.Size;
                        }
                    }
                    MainWindow.db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Возникла ошибка при обновлении размеров");
                }
                MainWindow.ThisMainAuthWindow.LoadCatalogWindow();
                MessageBox.Show("Вы успешно удалили каталог");
            }
        }

        private void CatalogBackButtonEnter(object sender, MouseEventArgs e)
        {
            MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            BackButton.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClicBackFromWindowCatalog";
        }

        private void CatalogBackButtonLeave(object sender, MouseEventArgs e)
        {
            BackButton.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = ""; 
        }

        private void CataloAddButtonEnter(object sender, MouseEventArgs e)
        {
            MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            AddCatalogButton.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClicAddCatalogFromCatalog";
        }

        private void CataloAddButtonLeave(object sender, MouseEventArgs e)
        {
            AddCatalogButton.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = ""; 
        }

        private void AddCatalog(object sender, RoutedEventArgs e)
        {
            try
            {
                if (InputTextBox.Text == "")
                {
                    MessageBox.Show("Вы не заполнили поле");
                    return;
                }
                User thisUser = MainWindow.db.User.Where(user => user.Id == MainWindow.CurrentUser.currentuser.Id).FirstOrDefault();
                foreach (var item in thisUser.Catalog)
                {
                    if (item.Name == InputTextBox.Text)
                    {
                        MessageBox.Show("Каталог с таким именем уже существует");
                        return;
                    }
                }
                Catalog catalog = new Catalog();
                catalog.Name = InputTextBox.Text;
                catalog.UserId = MainWindow.CurrentUser.currentuser.Id;
                MainWindow.db.Catalog.Add(catalog);
                MainWindow.db.SaveChanges();
                MainWindow.ThisMainAuthWindow.LoadCatalogWindow();
                MessageBox.Show("Вы успешно добавили каталог");
                InputBox.Visibility = Visibility.Hidden;
            }
            catch
            { 
                MessageBox.Show("Произошла непредвиденная ошибка");
            }
        }

        private void BackFromAddCatalog(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Hidden;
            InputTextBox.Text = "";
        }

        private void entercheck(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Enter");
        }
        private void ChangeCatalogNameEnter(object sender, MouseEventArgs e)
        {
            (sender as Image).Opacity = 0.5f;
            currentCatalogChoosed = (sender as Image).DataContext as Catalog;
            TextBoxChangeName.Text = currentCatalogChoosed.Name;
            MainWindow.MouseCheckClick.CheckClick = "ClicChangeNameOfCatalog";
        }

        private void ChangeCatalogNameLeave(object sender, MouseEventArgs e)
        {
            (sender as Image).Opacity = 1f;
        }

        private void BackFromChangeCatalog(object sender, RoutedEventArgs e)
        {
            InputChangeBox.Visibility = Visibility.Hidden;
            TextBoxChangeName.Text = "";
        }

        private void ChangeCatalog(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextBoxChangeName.Text == "")
                {
                    MessageBox.Show("Вы не заполнили поле");
                    return;
                }
                User thisUser = MainWindow.db.User.Where(user => user.Id == MainWindow.CurrentUser.currentuser.Id).FirstOrDefault();
                foreach (var item in thisUser.Catalog)
                {
                    if (item.Name == TextBoxChangeName.Text)
                    {
                        MessageBox.Show("Каталог с таким именем уже существует");
                        return;
                    }
                }

                Catalog cat = MainWindow.db.Catalog.Where(c => c.Id == currentCatalogChoosed.Id).FirstOrDefault();
                cat.Name = TextBoxChangeName.Text;
                MainWindow.db.SaveChanges();
                MainWindow.ThisMainAuthWindow.LoadCatalogWindow();
                MessageBox.Show("Вы успешно изменили имя каталога");
                InputChangeBox.Visibility = Visibility.Hidden;
            }
            catch
            {
                MessageBox.Show("Произошла непредвиденная ошибка");
            }
        }

        private void Close(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}