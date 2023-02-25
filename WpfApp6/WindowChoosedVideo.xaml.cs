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
    public partial class WindowChoosedVideo : Window
    {
        public WindowChoosedVideo()
        {
            InitializeComponent();
        }

        private void ClickDoubleMouse(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.MouseCheckClick.CheckClick == "ClicBackFromChoosedVideo")
            {
                ClicBackFromChoosedVideo();
            }
            if (MainWindow.MouseCheckClick.CheckClick == "ClicInfoFromChoosedVideo")
            {
                ClicInfoFromChoosedVideo();
            }
            if (MainWindow.MouseCheckClick.CheckClick == "ClicFullFromChoosedVideo")
            {
                ClicFullFromChoosedVideo();
            }
            if (MainWindow.MouseCheckClick.CheckClick == "ClicDeleteVideoFromChoosedVideo")
            {
                ClicDeleteVideoFromChoosedVideo();
            }
        }
        private void ChoosedVideoEnter(object sender, MouseEventArgs e)
        {
            MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            ChoosedVideoBackButton.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClicBackFromChoosedVideo";
        }
        private void ChoosedVideoLeave(object sender, MouseEventArgs e)
        {
            ChoosedVideoBackButton.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }
        public void ClicBackFromChoosedVideo()
        {
            MainWindow.ThisMainWindow.UpdateAllBoxes();
            this.Visibility = Visibility.Hidden;
            MainWindow.ThisMainAuthWindow.Visibility = Visibility.Visible;
            ChoosedVideo.Close();
        }
        private void ChoosedVideoInfoEnter(object sender, MouseEventArgs e)
        {
            MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            ChoosedVideoInfoButton.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClicInfoFromChoosedVideo";
        }
        private void ChoosedVideoInfoLeave(object sender, MouseEventArgs e)
        {
            ChoosedVideoInfoButton.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }
        public void ClicInfoFromChoosedVideo()
        {
            using (VideoStorageContext db = new VideoStorageContext())
            {
                foreach (User user in db.User)
                {
                    if (user.Id == MainWindow.CurrentUser.currentuser.Id)
                    {
                        foreach (Video video in db.Video.Where(video=> video.CatalogId == MainWindow.CurrentCatalog.catalog.Id))
                        {
                            if (video.Name.Equals(MainWindow.CurrentVideoAll.CurrentImage.Name))
                            {
                                string ToVivod = "";
                                ToVivod += "Видео " + video.Name + '\n';
                                ToVivod += "ID видое: " + video.Id + "\n";
                                ToVivod += "Имя видео: " + video.Name + "\n";
                                ToVivod += "Формат видео: " + video.Format + "\n";
                                ToVivod += "Разрешение видео: " + video.Resolution + "\n";
                                ToVivod += "Размер видео: " + video.Size + " KB" + "\n";
                                ToVivod += "Время создания видео: " + video.Time + "\n";
                                ToVivod += "\n";
                                if (video.AuthorOfVideo != null)
                                {
                                    ToVivod += "Автор Видео: " + video.Name + "\n";
                                    ToVivod += "Имя автора " + video.AuthorOfVideo.Name + "\n";
                                    ToVivod += "Фамилия автора " + video.AuthorOfVideo.Surname + "\n";
                                    ToVivod += "Страна автора " + video.AuthorOfVideo.Country + "\n";
                                    ToVivod += "Город автора " + video.AuthorOfVideo.City + "\n";
                                    ToVivod += "Улица автора " + video.AuthorOfVideo.Street + "\n";
                                    ToVivod += "Номер дома автора " + video.AuthorOfVideo.House + "\n";
                                    ToVivod += "Электронная почта автора " + video.AuthorOfVideo.Email + "\n";
                                }
                                ToVivod += "\n";
                                if (video.PlaceOfVideo != null)
                                {
                                    ToVivod += "Место съёмки видео: " + video.Name + "\n";
                                    ToVivod += "Страна " + video.PlaceOfVideo.Country + "\n";
                                    ToVivod += "Город " + video.PlaceOfVideo.City + "\n";
                                    ToVivod += "Улица " + video.PlaceOfVideo.Street + "\n";
                                }
                                MessageBox.Show(ToVivod);
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void ChoosedVideoFullEnter(object sender, MouseEventArgs e)
        {
            MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            ChoosedVideoFullButton.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClicFullFromChoosedVideo";
        }
        private void ChoosedVideoFullLeave(object sender, MouseEventArgs e)
        {
            ChoosedVideoFullButton.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }
        public void ClicFullFromChoosedVideo()
        {
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
                                    MainWindow.CurrentVideoAll.CurrentImage = video;
                                    MainWindow.ThisVideoPlayerWindow.VideoSlider.Maximum = ChoosedVideo.NaturalDuration.TimeSpan.TotalSeconds;
                                    ChoosedVideo.UnloadedBehavior = MediaState.Manual;
                                    ChoosedVideo.LoadedBehavior = MediaState.Manual;
                                    MainWindow.ThisVideoPlayerWindow.PleerMedia.LoadedBehavior = MediaState.Manual;
                                    MainWindow.ThisVideoPlayerWindow.PleerMedia.UnloadedBehavior = MediaState.Manual;
                                ChoosedVideo.Close();
                                MainWindow.ThisVideoPlayerWindow.PleerMedia.Close();
                                    string path2 = @"C:\Users\vbnf0\Videos\" + video.Name;
                                    FileInfo fileInf = new FileInfo(path2);
                                    if (fileInf.Exists)
                                    {
                                        fileInf.Delete();
                                    }
                                    using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(video.Preview)))
                                    {
                                        MainWindow.ThisChoosedVideoWindow.ChoosedVideoImage.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                                    }
                                    string path = @"C:\Users\vbnf0\Videos\";
                                    FileStream fs = new FileStream(@"C:\Users\vbnf0\Videos\" + video.Name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                    fs.Write(video.VideoData,0,video.VideoData.Length);
                                    fs.Close();
                                    path += video.Name;
                                    MainWindow.ThisVideoPlayerWindow.PleerMedia.Source = new Uri(path);
                                   // MainWindow.ThisVideoPlayerWindow.PleerMedia.LoadedBehavior = MediaState.Play;
                                    MainWindow.ThisVideoPlayerWindow.PleerMedia.Play();
                                    WindowVideoPlayer.timer.Start();
                                    MainWindow.ThisVideoPlayerWindow.Visibility = Visibility.Visible;
                                    
                                    break;
                                }
                            }
                        }
                    }
                }
        }
        private void ChoosedVideoDeleteButtonEnter(object sender, MouseEventArgs e)
        {
            ChoosedVideoDeleteButton.Opacity = 0.4;
            MainWindow.MouseCheckClick.CheckClick = "ClicDeleteVideoFromChoosedVideo";
        }
        private void ChoosedVideoDeleteButtonLeave(object sender, MouseEventArgs e)
        {
            ChoosedVideoDeleteButton.Opacity = 1;
            MainWindow.MouseCheckClick.CheckClick = "";
        }

        public void ClicDeleteVideoFromChoosedVideo()
        {
            //try
            //{
                using (VideoStorageContext db = new VideoStorageContext())
                {
                    foreach (User user in db.User)
                    {
                        if (user.Id == MainWindow.CurrentUser.currentuser.Id)
                        {
                            Catalog cat = db.Catalog.Where(c => c.Id == MainWindow.CurrentCatalog.catalog.Id).FirstOrDefault();
                            foreach (Video video in cat.Video)
                            {
                                if (video.Name == MainWindow.CurrentVideoAll.CurrentImage.Name)
                                {
                                    //  MainWindow.db.Video.Remove(video);
                                    cat.Video.Remove(video);
                                    MessageBox.Show("Вы успешно удалили видео: " + video.Name);
                                    break;
                                }
                            }
                        }
                    }
                    MainWindow.db.SaveChanges();
                    db.SaveChanges();
                    //  ChoosedVideo.Stop();
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

                    this.Visibility = Visibility.Hidden;
                    Catalog cat2 = db.Catalog.Where(c => c.Id == MainWindow.CurrentCatalog.catalog.Id).FirstOrDefault();
                    MainWindow.CurrentCatalog.catalog = cat2;
                    MainWindow.ThisMainAuthWindow.LoadVideosOfCurrentCatalogChoosed();
                    ChoosedVideo.Close();
                    MainWindow.ThisCheckVideoWindow.Visibility = Visibility.Visible;
                }
            //}
            //catch
            //{
            //    MessageBox.Show("Что-то пошло не так, попробуйте снова");
            //}
        }
        private void ClickLaunch(object sender, RoutedEventArgs e)
        {
            ChoosedVideo.Stop();
            ChoosedVideo.Play();
        }
        private void ClickPause(object sender, RoutedEventArgs e)
        {
            ChoosedVideo.Pause();
        }
        private void ClickContinue(object sender, RoutedEventArgs e)
        {
            ChoosedVideo.Play();
        }

        private void Close(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ClickAddAuthor(object sender, RoutedEventArgs e)
        {
            MainWindow.ThisAddAuthorOhVideoWindow.Visibility = Visibility.Visible;
            MainWindow.ThisMainWindow.UpdateAllBoxes();
            MessageBox.Show("CurrentVideo: " + MainWindow.CurrentVideoAll.CurrentImage.Name);
        }

        private void ClickAddPlace(object sender, RoutedEventArgs e)
        {
            MainWindow.ThisAddPlaceOhVideoWindow.Visibility = Visibility.Visible;
            MainWindow.ThisMainWindow.UpdateAllBoxes();
        }
    }
}