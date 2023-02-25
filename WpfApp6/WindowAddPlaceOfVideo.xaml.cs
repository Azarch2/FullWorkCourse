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
using System.Windows.Shapes;

namespace WpfApp6
{
    public partial class WindowAddPlaceOfVideo : Window
    {
        public WindowAddPlaceOfVideo()
        {
            InitializeComponent();
        }

        private void AddPlaceOfVideo_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void AddPlaceAddEnter(object sender, MouseEventArgs e)
        {
            MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)AddPlaceAddButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            AddPlaceAddButton.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClickAddPlaceAddPlace";
        }

        private void AddPlaceAddLeave(object sender, MouseEventArgs e)
        {
            AddPlaceAddButton.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }

        private void ClickDoubleMouse(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.MouseCheckClick.CheckClick == "ClickAddPlaceAddPlace")
            {
                if (AddPlaceTextBoxCity.Text != "" && AddPlaceTextBoxCountry.Text != "" && AddPlaceTextBoxLandscape.Text != "")
                {
                    try
                    {
                        PlaceOfVideo item = new PlaceOfVideo();
                        item.Country = AddPlaceTextBoxCountry.Text;
                        item.City = AddPlaceTextBoxCity.Text;
                        item.Street = AddPlaceTextBoxLandscape.Text;
                        using (VideoStorageContext db = new VideoStorageContext())
                        {
                            foreach (User user in db.User)
                            {
                                if (user.Login == MainWindow.CurrentUser.currentuser.Login)
                                {
                                    int count1 = db.Catalog.ToList().Count;
                                    foreach (Video video in db.Video.Where(video=> video.CatalogId == MainWindow.CurrentCatalog.catalog.Id)) //CatalogCurrent
                                    {
                                        if (video.Name == MainWindow.CurrentVideoAll.CurrentImage.Name)
                                        {
                                            if (video.PlaceOfVideo != null)
                                            {
                                                db.PlaceOfVideo.Remove(video.PlaceOfVideo);
                                            }
                                            video.PlaceOfVideo = item;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                            db.SaveChanges();
                            MessageBox.Show("Вы успешно назначили место съёмки видео");
                            AddPlaceTextBoxCity.Text = "";
                            AddPlaceTextBoxCountry.Text = "";
                            AddPlaceTextBoxLandscape.Text = "";
                            MainWindow.ThisAddPlaceOhVideoWindow.Visibility = Visibility.Hidden;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Не все поля были заполнены верно");
                    }
                }
                else
                {
                    MessageBox.Show("Вы заполнили не все поля");
                }
            }
        }
    }
}
