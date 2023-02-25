using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public partial class WindowAddAuthorOfVideo : Window
    {
        public WindowAddAuthorOfVideo()
        {
            InitializeComponent();
        }

        private void AddAuthorAddEnter(object sender, MouseEventArgs e)
        {
           MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)AddAuthorAddButton.Foreground;
           SolidColorBrush brush =MainWindow.MouseCheckClick.BrushStandart;
           AddAuthorAddButton.Foreground = brush;
           MainWindow.MouseCheckClick.CheckClick = "ClickAddAuthorAddAuthor";
        }

        private void AddAuthorAddLeave(object sender, MouseEventArgs e)
        {
            AddAuthorAddButton.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }

        private void ClickDoubleMouse(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.MouseCheckClick.CheckClick == "ClickAddAuthorAddAuthor")
            {
                if (AddAuthorTextBoxCity.Text != "" && AddAuthorTextBoxCountry.Text != "" && AddAuthorTextBoxEmail.Text != "" && AddAuthorTextBoxHouse.Text != "" && AddAuthorTextBoxName.Text != "" && AddAuthorTextBoxStreet.Text != "" && AddAuthorTextBoxSurname.Text != "")
                {
                    try
                    {
                        AuthorOfVideo item = new AuthorOfVideo();
                        item.Country = AddAuthorTextBoxCountry.Text;
                        item.Surname = AddAuthorTextBoxSurname.Text;
                        item.House = AddAuthorTextBoxHouse.Text;
                        item.Email = AddAuthorTextBoxEmail.Text;
                        item.Name = AddAuthorTextBoxName.Text;
                        item.City = AddAuthorTextBoxCity.Text;
                        item.Street = AddAuthorTextBoxStreet.Text;
                        using (VideoStorageContext db = new VideoStorageContext())
                        {
                            foreach (User user in db.User)
                            {
                                if (user.Login == MainWindow.CurrentUser.currentuser.Login)
                                {
                                    foreach (Video video in db.Video.Where(video=> video.CatalogId == MainWindow.CurrentCatalog.catalog.Id))
                                    {
                                        //if (video.Name == MainWindow.CurrentVideoAll.CurrentImage.Name)
                                        if (video.Name == MainWindow.CurrentVideoAll.CurrentImage.Name)
                                        {
                                            if (video.AuthorOfVideo != null)
                                            {
                                                db.AuthorOfVideo.Remove(video.AuthorOfVideo);
                                            }
                                            video.AuthorOfVideo = item;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                            db.SaveChanges();
                            MessageBox.Show("Вы успешно назначили автора видео");
                            AddAuthorTextBoxCountry.Text = "";
                            AddAuthorTextBoxEmail.Text = "";
                            AddAuthorTextBoxHouse.Text = "";
                            AddAuthorTextBoxName.Text = "";
                            AddAuthorTextBoxStreet.Text = "";
                            AddAuthorTextBoxSurname.Text = "";
                            AddAuthorTextBoxCity.Text = "";
                            MainWindow.ThisAddAuthorOhVideoWindow.Visibility = Visibility.Hidden;
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
        private void AddAuthorOfVideo_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
