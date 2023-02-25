using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp6
{
    public partial class WindowCheckVideo : Window
    {
        public WindowCheckVideo()
        {
            InitializeComponent();
        }

        private void ClickDoubleMouse(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.MouseCheckClick.CheckClick == "ClickBackFromCheckVideo")
            {
                ClickBackFromCheckVideo();
            }
            if (MainWindow.MouseCheckClick.CheckClick == "ClickLastFromCheckVideo")
            {
                ClickLastFromCheckVideo();
            }
            if (MainWindow.MouseCheckClick.CheckClick == "ClickNextFromCheckVideo")
            {
                ClickNextFromCheckVideo();
            }
        }
        private void CheckVideoEnter(object sender, MouseEventArgs e)
        {
            MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            CheckVideoBackButton.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClickBackFromCheckVideo";
        }
        private void CheckVideoLeave(object sender, MouseEventArgs e)
        {
            CheckVideoBackButton.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }
        public void ClickBackFromCheckVideo()
        {
            this.Visibility = Visibility.Hidden;
            MainWindow.ThisMainAuthWindow.Visibility = Visibility.Visible;
        }
        private void CheckVideoLastEnter(object sender, MouseEventArgs e)
        {
            MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            CheckVideoLastButton.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClickLastFromCheckVideo";
        }
        private void CheckVideoLastLeave(object sender, MouseEventArgs e)
        {
            CheckVideoLastButton.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }
         public void ClickLastFromCheckVideo()
        {
            double lastpage = 0;
            using (VideoStorageContext db = new VideoStorageContext())
            {
                foreach (User user in db.User)
                {
                    int count1 = db.Video.ToList().Count;
                    if (user.Id == MainWindow.CurrentUser.currentuser.Id)
                    {
                        lastpage = (MainWindow.CurrentCatalog.catalog.Video.Count / 2.0) - 1; // Изменение
                        break;
                    }
                }
            }
            if (MainWindow.NumberOfPage.CurrrentPage > 1)
            {
                CheckVideoNextButton.Visibility = Visibility.Visible;
                MainWindow.NumberOfPage.CurrrentPage--;
                CheckVideoStackPanel.Children.Clear();
                try
                {
                    CheckVideoStackPanel.Children.Clear();
                    using (VideoStorageContext db = new VideoStorageContext())
                    {
                        foreach (User user in db.User)
                        {
                            if (user.Id == MainWindow.CurrentUser.currentuser.Id)
                            {
                                for (int i = MainWindow.NumberOfPage.CurrrentPage * 2; i < (MainWindow.NumberOfPage.CurrrentPage * 2) + 2; i++)
                                {
                                    StackPanel PanelToAdd = new StackPanel();
                                    PanelToAdd.Width = 245;
                                    PanelToAdd.Margin = new Thickness(10, 0, 10, 0);
                                    PanelToAdd.Height = CheckVideoStackPanel.Height + 30;
                                    PanelToAdd.Orientation = Orientation.Vertical;
                                    Image image = new Image();
                                    TextBlock textblock = new TextBlock();
                                    textblock.FontSize = 14;
                                    textblock.FontWeight = FontWeights.Bold;
                                    textblock.TextAlignment = TextAlignment.Center;
                                    int count1 = db.Video.ToList().Count;
                                    using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(MainWindow.CurrentCatalog.catalog.Video.ToArray()[i].Preview)))
                                    {
                                        textblock.Text = MainWindow.CurrentCatalog.catalog.Video.ToArray()[i].Name;
                                        image.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);

                                    }
                                    image.Width = 245;
                                    image.Margin = new Thickness(0, 0, 10, 0);
                                    image.Height = CheckVideoStackPanel.Height - 20;
                                    PanelToAdd.Children.Add(image);
                                    PanelToAdd.Children.Add(textblock);
                                    PanelToAdd.MouseEnter += new MouseEventHandler(MouseEnter);
                                    PanelToAdd.MouseLeave += new MouseEventHandler(MouseLeave);
                                    CheckVideoStackPanel.Children.Add(PanelToAdd);
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
            }
            else
            {
                CheckVideoLastButton.Visibility = Visibility.Hidden;
                CheckVideoNextButton.Visibility = Visibility.Visible;
                MainWindow.NumberOfPage.CurrrentPage--;
                try
                {
                    CheckVideoStackPanel.Children.Clear();
                    using (VideoStorageContext db = new VideoStorageContext())
                    {
                        foreach (User user in db.User)
                        {
                            if (user.Id == MainWindow.CurrentUser.currentuser.Id)
                            {
                                for (int i = MainWindow.NumberOfPage.CurrrentPage * 2; i < (MainWindow.NumberOfPage.CurrrentPage * 2) + 2; i++)
                                {
                                    StackPanel PanelToAdd = new StackPanel();
                                    PanelToAdd.Width = 245;
                                    PanelToAdd.Margin = new Thickness(10, 0, 10, 0);
                                    PanelToAdd.Height = CheckVideoStackPanel.Height + 30;
                                    PanelToAdd.Orientation = Orientation.Vertical;
                                    Image image = new Image();
                                    TextBlock textblock = new TextBlock();
                                    textblock.FontSize = 14;
                                    textblock.FontWeight = FontWeights.Bold;
                                    textblock.TextAlignment = TextAlignment.Center;
                                    int count1 = db.Video.ToList().Count;
                                    using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(MainWindow.CurrentCatalog.catalog.Video.ToArray()[i].Preview)))
                                    {
                                        textblock.Text = MainWindow.CurrentCatalog.catalog.Video.ToArray()[i].Name;
                                        image.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                                    }
                                    image.Width = 245;
                                    image.Margin = new Thickness(0, 0, 10, 0);
                                    image.Height = CheckVideoStackPanel.Height - 20;
                                    PanelToAdd.Children.Add(image);
                                    PanelToAdd.Children.Add(textblock);
                                    PanelToAdd.MouseEnter += new MouseEventHandler(MouseEnter);
                                    PanelToAdd.MouseLeave += new MouseEventHandler(MouseLeave);
                                    CheckVideoStackPanel.Children.Add(PanelToAdd);
                                }
                            }
                        }
                    }
                }
                catch
                {

                }
            }
        }
         private void CheckVideoNextEnter(object sender, MouseEventArgs e)
         {
             MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
             SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
             CheckVideoNextButton.Foreground = brush;
             MainWindow.MouseCheckClick.CheckClick = "ClickNextFromCheckVideo";
         }
         private void CheckVideoNextLeave(object sender, MouseEventArgs e)
         {
             CheckVideoNextButton.Foreground = MainWindow.MouseCheckClick.LastColor;
             MainWindow.MouseCheckClick.CheckClick = "";
         }
        public void ClickNextFromCheckVideo()
        {
            double lastpage = 0;
            using (VideoStorageContext db = new VideoStorageContext())
            {
                foreach (User user in db.User)
                {
                    int count1 = db.Video.ToList().Count;
                    if (user.Id == MainWindow.CurrentUser.currentuser.Id)
                    {
                        lastpage = (MainWindow.CurrentCatalog.catalog.Video.Count / 2.0) - 1;

                        break;
                    }
                }
            }
            if (MainWindow.NumberOfPage.CurrrentPage < lastpage - 1)
            {
                CheckVideoLastButton.Visibility = Visibility.Visible;
                MainWindow.NumberOfPage.CurrrentPage++;
                CheckVideoStackPanel.Children.Clear();
                try
                {
                    CheckVideoStackPanel.Children.Clear();
                    using (VideoStorageContext db = new VideoStorageContext())
                    {
                        foreach (User user in db.User)
                        {
                            if (user.Id == MainWindow.CurrentUser.currentuser.Id)
                            {
                                for (int i = MainWindow.NumberOfPage.CurrrentPage * 2; i < (MainWindow.NumberOfPage.CurrrentPage * 2) + 2; i++)
                                {
                                    StackPanel PanelToAdd = new StackPanel();
                                    PanelToAdd.Width = 245;
                                    PanelToAdd.Margin = new Thickness(10, 0, 10, 0);
                                    PanelToAdd.Height = CheckVideoStackPanel.Height + 30;
                                    PanelToAdd.Orientation = Orientation.Vertical;
                                    Image image = new Image();
                                    TextBlock textblock = new TextBlock();
                                    textblock.FontSize = 14;
                                    textblock.FontWeight = FontWeights.Bold;
                                    textblock.TextAlignment = TextAlignment.Center;
                                    int count1 = db.Video.ToList().Count;
                                    using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(MainWindow.CurrentCatalog.catalog.Video.ToList()[i].Preview)))
                                    {
                                        textblock.Text = MainWindow.CurrentCatalog.catalog.Video.ToArray()[i].Name;
                                        image.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                                    }
                                    image.Width = 245;
                                    image.Margin = new Thickness(0, 0, 10, 0);
                                    image.Height = CheckVideoStackPanel.Height - 20;
                                    PanelToAdd.Children.Add(image);
                                    PanelToAdd.Children.Add(textblock);
                                    PanelToAdd.MouseEnter += new MouseEventHandler(MouseEnter);
                                    PanelToAdd.MouseLeave += new MouseEventHandler(MouseLeave);
                                    CheckVideoStackPanel.Children.Add(PanelToAdd);
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
            }
            else
            {
                CheckVideoLastButton.Visibility = Visibility.Visible;
                CheckVideoNextButton.Visibility = Visibility.Hidden;
                MainWindow.NumberOfPage.CurrrentPage++;
                try
                {
                    CheckVideoStackPanel.Children.Clear();
                    using (VideoStorageContext db = new VideoStorageContext())
                    {
                        foreach (User user in db.User)
                        {
                            if (user.Id == MainWindow.CurrentUser.currentuser.Id)
                            {
                                for (int i = MainWindow.NumberOfPage.CurrrentPage * 2; i < (MainWindow.NumberOfPage.CurrrentPage * 2) + 2; i++)
                                {
                                    StackPanel PanelToAdd = new StackPanel();
                                    PanelToAdd.Width = 245;
                                    PanelToAdd.Margin = new Thickness(10, 0, 10, 0);
                                    PanelToAdd.Height = CheckVideoStackPanel.Height + 30;
                                    PanelToAdd.Orientation = Orientation.Vertical;
                                    Image image = new Image();
                                    TextBlock textblock = new TextBlock();
                                    textblock.FontSize = 14;
                                    textblock.FontWeight = FontWeights.Bold;
                                    textblock.TextAlignment = TextAlignment.Center;
                                    int count1 = db.Video.ToList().Count;
                                    using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(MainWindow.CurrentCatalog.catalog.Video.ToArray()[i].Preview)))
                                    {
                                        textblock.Text = MainWindow.CurrentCatalog.catalog.Video.ToArray()[i].Name;
                                        image.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                                    }
                                    image.Width = 245;
                                    image.Margin = new Thickness(0, 0, 10, 0);
                                    image.Height = CheckVideoStackPanel.Height - 20;
                                    PanelToAdd.Children.Add(image);
                                    PanelToAdd.Children.Add(textblock);
                                    PanelToAdd.MouseEnter += new MouseEventHandler(MouseEnter);
                                    PanelToAdd.MouseLeave += new MouseEventHandler(MouseLeave);
                                    CheckVideoStackPanel.Children.Add(PanelToAdd);
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
            }
        }
        private void ToEventTextBlockEnter(object sender, MouseEventArgs e)
        {
           MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            TextBlock text = (TextBlock)e.Source;
            text.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClickFromDynamicEvent";
        }
        private void ToEventTextBlockLeave(object sender, MouseEventArgs e)
        {
            TextBlock text = (TextBlock)e.Source;
            text.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
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

        private void MiddleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Middle && e.ButtonState == MouseButtonState.Pressed && MainWindow.CurrentVideoAll.VIDEOnameFull != "")
            {
                MainWindow.CurrentVideoAll.CurrentImage.Name = MainWindow.CurrentVideoAll.VIDEOnameFull;
                using (VideoStorageContext db = new VideoStorageContext())
                {
                    foreach (User user in db.User)
                    {
                        if (user.Id == MainWindow.CurrentUser.currentuser.Id)
                        {
                            int countsadf = db.Video.ToList().Count;
                            foreach (Video video in MainWindow.CurrentCatalog.catalog.Video)
                            {
                                if (video.Name == MainWindow.CurrentVideoAll.CurrentImage.Name)
                                {
                                    this.Visibility = Visibility.Hidden; 
                                    MainWindow.ThisChoosedVideoWindow.Visibility = Visibility.Visible;
                                    MainWindow.CurrentVideoAll.CurrentImage = video;
                                  
                                    string path = @"C:\Users\vbnf0\Videos\";
                                    FileStream fs = new FileStream(@"C:\Users\vbnf0\Videos\" + video.Name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                    fs.Write(video.VideoData,0,video.VideoData.Length);
                                    fs.Close();
                                    path += video.Name;
                                    MainWindow.ThisChoosedVideoWindow.ChoosedVideo.Source = new Uri(path);
                                    MainWindow.ThisChoosedVideoWindow.ChoosedVideo.Play();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (e.ChangedButton == MouseButton.Right && e.ButtonState == MouseButtonState.Pressed && MainWindow.CurrentVideoAll.VIDEOnameFull != "")
            {
              //  MainWindow.ThisAddAuthorOhVideoWindow.Visibility = Visibility.Visible;
               // MainWindow.ThisMainWindow.UpdateAllBoxes();
                MainWindow.CurrentVideoAll.CurrentImage.Name = MainWindow.CurrentVideoAll.VIDEOnameFull;
                using (VideoStorageContext db = new VideoStorageContext())
                {
                    foreach (User user in db.User)
                    {
                        if (user.Id == MainWindow.CurrentUser.currentuser.Id)
                        {
                            int countsadf = db.Video.ToList().Count;
                            foreach (Video video in MainWindow.CurrentCatalog.catalog.Video)
                            {
                                if (video.Name == MainWindow.CurrentVideoAll.CurrentImage.Name)
                                {
                                    this.Visibility = Visibility.Hidden;
                                    MainWindow.ThisChoosedVideoWindow.Visibility = Visibility.Visible;
                                    MainWindow.CurrentVideoAll.CurrentImage = video;

                                    string path = @"C:\Users\vbnf0\Videos\";
                                    FileStream fs = new FileStream(@"C:\Users\vbnf0\Videos\" + video.Name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                    fs.Write(video.VideoData, 0, video.VideoData.Length);
                                    fs.Close();
                                    path += video.Name;
                                    MainWindow.ThisChoosedVideoWindow.ChoosedVideo.Source = new Uri(path);
                                    MainWindow.ThisChoosedVideoWindow.ChoosedVideo.Play();
                                    break;
                                }
                            }
                        }
                    }
                }
                // MainWindow.CurrentVideoAll.CurrentImage.Name = MainWindow.CurrentVideoAll.VIDEOnameFull;
            }
            if (e.ChangedButton == MouseButton.Left && e.ButtonState == MouseButtonState.Pressed && MainWindow.CurrentVideoAll.VIDEOnameFull != "")
            {
                MainWindow.ThisAddPlaceOhVideoWindow.Visibility = Visibility.Visible;
                MainWindow.ThisMainWindow.UpdateAllBoxes();
               // MainWindow.CurrentVideoAll.CurrentImage.Name = MainWindow.CurrentVideoAll.VIDEOnameFull;
            }
        }

        private void Close(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}