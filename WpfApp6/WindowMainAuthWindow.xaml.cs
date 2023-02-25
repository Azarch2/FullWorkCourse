using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using Image = System.Windows.Controls.Image;

namespace WpfApp6
{
    public partial class WindowMainAuthWindow : Window
    {
        public WindowMainAuthWindow()
        {
            InitializeComponent();
        }

        public void LoadCatalogWindow()
        {
            this.Visibility = Visibility.Hidden;
         using (VideoStorageContext db = new VideoStorageContext())
         {
             MainWindow.ThisCatalogWindow.CatalogsListView.ItemsSource = db.User.Where(user => user.Id == MainWindow.CurrentUser.currentuser.Id).FirstOrDefault().Catalog.ToList();
         }
         MainWindow.ThisCatalogWindow.Visibility = Visibility.Visible;
         MainWindow.ThisCatalogWindow.Visibility = Visibility.Visible;
        }
        private void AfterAuthBackEnter(object sender, MouseEventArgs e)
        {
           MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            AfterAuthBackButton.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClickBackFromAfterAuth";
        }
        private void AfterAuthBackLeave(object sender, MouseEventArgs e)
        {
            AfterAuthBackButton.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }
        public void ClickBackFromAfterAuth()
        {
            MainWindow.ThisMainWindow.UpdateAllBoxes();
            MainWindow.ThisMainWindow.Visibility = Visibility.Visible;
            MainWindow.ThisMainAuthWindow.Visibility = Visibility.Hidden;
        }
        private void ClickDoubleMouse(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.MouseCheckClick.CheckClick == "ClickBackFromAfterAuth")
            {
                ClickBackFromAfterAuth();
            }
            if (MainWindow.MouseCheckClick.CheckClick == "ClickChangePasswordFromAfterAuth")
            {
                ClickChangePasswordFromAfterAuth();
            }

            if (MainWindow.MouseCheckClick.CheckClick == "ClickAddVideoFromAfterAuth") 
            {
                ClickAddVideoFromAfterAuth();

            }
            if (MainWindow.MouseCheckClick.CheckClick == "ClickGetAdminFromAfterAuth")
            {
                ClickGetAdminFromAfterAuth();

            }
            if (MainWindow.MouseCheckClick.CheckClick == "ClicAdminPanelFromAfterAuth")  //Панель администратора
            {
                ClicAdminPanelFromAfterAuth();
            }
            if (MainWindow.MouseCheckClick.CheckClick == "ClickCheckVideoFromAfterAuth") 
            {
                ClickCheckVideoFromAfterAuth();
            }
        }
        public void ClickChangePasswordFromAfterAuth()
        {
            this.Visibility = Visibility.Hidden;
            MainWindow.ThisChangePasswordWindow.Visibility = Visibility.Visible;
        }
        public void ClickGetAdminFromAfterAuth()
        {
            MainWindow.ThisMainWindow.UpdateAllBoxes();
            MainWindow.ThisGetAdminWindow.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
        
        private void AfterAuthChangePasswordEnter(object sender, MouseEventArgs e)
        {
            MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            AfterAuthChangePassword.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClickChangePasswordFromAfterAuth";
        }
        private void AfterAuthChangePasswordLeave(object sender, MouseEventArgs e)
        {
            AfterAuthChangePassword.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }
        
        
        private void AfterAuthCheckVideoEnter(object sender, MouseEventArgs e)
        {
            MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            AfterAuthCheckVideo.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClickCheckVideoFromAfterAuth";
        }
        private void AfterAuthCheckVideoLeave(object sender, MouseEventArgs e)
        {
            AfterAuthCheckVideo.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }
       
        private void AfterAuthAddVideoEnter(object sender, MouseEventArgs e)
        {
           MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            AfterAuthAddVideo.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClickAddVideoFromAfterAuth";
        }
        private void AfterAuthAddVideoLeave(object sender, MouseEventArgs e)
        {
            AfterAuthAddVideo.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }

        public void AddVideo()
        {
            using (VideoStorageContext db = new VideoStorageContext())
            { 
                try
                {
                    OpenFileDialog Files = new OpenFileDialog();
                    Files.Filter = "Video Files(*.MP4;*.AVI;*.MKV)|*.MP4;*.AVI;*.MKV|All files (*.*)|*.*";
                    Files.ShowDialog();
                    int check = 0;
                    FileInfo FileInfo = new FileInfo(Files.FileName);
                    long storage = 0;
                    foreach (User user in db.User)
                    {
                        if (user.Id == MainWindow.CurrentUser.currentuser.Id)
                        {
                            int count1 = db.Video.ToList().Count;
                            foreach (Video video in db.Video)
                            {
                                storage += video.Size;
                            }
                        }
                    }
                    MainWindow.CurrentUser.currentuser.Storage = storage;
                    if ((storage + (int)(FileInfo.Length * 0.0009765625)) >= MainWindow.CurrentUser.currentuser.MaxStorage)
                    {
                        MessageBox.Show("Вам не хватает места в личном хранилище чтобы добавить это видео");
                        MessageBox.Show("На данный момент у вас занято " +MainWindow.CurrentUser.currentuser.Storage + " КБ и вы пытаетесь добавить видео весом в " + ((int)(FileInfo.Length * 0.0009765625)) + " КБ");
                    }
                    else
                    {
                        Catalog cat2 = db.Catalog.Where(c => c.Id == MainWindow.CurrentCatalog.catalog.Id).FirstOrDefault();
                        Video video = cat2.Video.ToList().Find(c => c.Name == FileInfo.Name);
                        if (video != null)
                        {
                            MessageBox.Show("Видео с таким именем уже существует");
                            return;
                        }
                        if (check == 0)
                        {
                            Video Video = new Video();
                            Random rnd = new Random();
                            //MessageBox.Show("CurrentCatalogId: " + MainWindow.CurrentCatalog.catalog.Id);
                            Video.CatalogId = MainWindow.CurrentCatalog.catalog.Id; //Изменение
                            //Files.Filter = "Image Files(*.MP4;*.AVI;*.MKV)|*.MP4;*.AVI;*.MKV|All files (*.*)|*.*";
                            Image MapBit = new Image();
                            var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
                            MemoryStream ms = new MemoryStream();
                            ffMpeg.GetVideoThumbnail(Files.FileName, ms, 1);
                            Bitmap map = (Bitmap)System.Drawing.Image.FromStream(ms);
                            var handle = map.GetHbitmap();
                            MapBit.Source = Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                            MemoryStream imagestream = new MemoryStream();
                            map.Save(imagestream, ImageFormat.Jpeg);
                            int gg = Convert.ToInt32(MapBit.Source.Height);
                            int gg1 = Convert.ToInt32(MapBit.Source.Width);
                            Video.Preview = Convert.ToBase64String(imagestream.GetBuffer());
                            Video.VideoData = File.ReadAllBytes(Files.FileName);
                            Video.Name = FileInfo.Name;
                            Video.Resolution = gg.ToString();
                            Video.Resolution += "x" + gg1.ToString();
                            Video.Size = (int)(FileInfo.Length * 0.0009765625);
                            Video.Time = FileInfo.CreationTimeUtc.ToString();
                            Video.Format = FileInfo.Extension;
                            foreach (User user in db.User)
                            {
                                if (user.Id == MainWindow.CurrentUser.currentuser.Id)
                                {
                                    db.Video.Add(Video);
                                    
                                    MessageBox.Show("Вы успешно добавили видео");
                                }
                            }
                            db.SaveChanges();

                          try
                          {
                              User User = db.User.Where(user => user.Id == MainWindow.CurrentUser.currentuser.Id).FirstOrDefault();
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
                              db.SaveChanges();
                          }
                          catch
                          {
                              MessageBox.Show("Возникла ошибка при обновлении размеров");
                          }
                        }
                        else
                        {
                            MessageBox.Show("У вас уже есть видео с таким именем");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Вы не выбрали видео");
                }
            }
        }

        public void LoadChoseCatalogWindow()
        {
            User userInDb = MainWindow.db.User.Where(user => user.Id == MainWindow.CurrentUser.currentuser.Id).FirstOrDefault();
            MainWindow.ThisChooseCatalogWhenAddVideoWindow.CatalogNamesList.ItemsSource = userInDb.Catalog.ToList();
        
                MainWindow.ThisChooseCatalogWhenAddVideoWindow.Visibility = Visibility.Visible;
            
        }
        public void ClickAddVideoFromAfterAuth()
        {
            LoadChoseCatalogWindow();
        }
        private void AfterAuthGetAdminEnter(object sender, MouseEventArgs e)
        {
           MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            AfterAuthGetAdmin.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClickGetAdminFromAfterAuth";
        }
        private void AfterAuthGetAdminLeave(object sender, MouseEventArgs e)
        {
            AfterAuthGetAdmin.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }

        private void AfterAuthAdminPanelButtonEnter(object sender, MouseEventArgs e)
        {
            MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            AfterAuthAdminPanelButton.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClicAdminPanelFromAfterAuth";
        }
        private void AfterAuthAdminPanelButtonLeave(object sender, MouseEventArgs e)
        {
            AfterAuthAdminPanelButton.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }

        public void ClicAdminPanelFromAfterAuth()
        {
            this.Visibility = Visibility.Hidden;
            try
            {
                using (VideoStorageContext db = new VideoStorageContext())
                {
                    MainWindow.ThisAdminPanelWindow.AdminPanelGrid1.ItemsSource = db.User.ToList();
                    MainWindow.ThisAdminPanelWindow.AdminPanelGrid2.ItemsSource = db.Video.ToList();
                    MainWindow.ThisAdminPanelWindow.TheMainOfTheMain.Height = 1000;
                    MainWindow.ThisAdminPanelWindow.TheMainOfTheMain.Width = 900;
                    MainWindow.ThisAdminPanelWindow.Visibility = Visibility.Visible;
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так, повторите попытку позже");
            }
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
                                int count = db.Video.ToList().Count;
                                using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(MainWindow.CurrentCatalog.catalog.Video.ToList()[i].Preview)))
                                {
                                    textblock.Text = MainWindow.CurrentCatalog.catalog.Video.ToArray()[i].Name;
                                    image.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
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
        public void ClickCheckVideoFromAfterAuth()
        {
            LoadCatalogWindow();
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

        private void Close(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}