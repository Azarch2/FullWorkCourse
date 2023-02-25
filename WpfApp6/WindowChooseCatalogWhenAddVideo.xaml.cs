using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;

namespace WpfApp6
{
    public partial class WindowChooseCatalogWhenAddVideo : Window
    {
        public WindowChooseCatalogWhenAddVideo()
        {
            InitializeComponent();
        }

        private void ClickDoubleMouse(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.MouseCheckClick.CheckClick == "ClicAddVideoToCatalog")
            {
                if (CatalogNamesList.SelectedIndex < 0)
                {
                    MessageBox.Show("Вы не выбрали каталог");
                }
                else
                {
                    MainWindow.CurrentCatalog.catalog = (CatalogNamesList.SelectedItem as Catalog);
                    MainWindow.ThisMainAuthWindow.AddVideo();
                }
            }
        }

        private void AddAuthorOfVideo_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;

        }

        private void AddAuthorAddEnter(object sender, MouseEventArgs e)
        {
            MainWindow.MouseCheckClick.LastColor = (SolidColorBrush)MainWindow.ThisMainWindow.RegisterButton.Foreground;
            SolidColorBrush brush = MainWindow.MouseCheckClick.BrushStandart;
            AddVideoButton.Foreground = brush;
            MainWindow.MouseCheckClick.CheckClick = "ClicAddVideoToCatalog";
        }

        private void AddAuthorAddLeave(object sender, MouseEventArgs e)
        {
            AddVideoButton.Foreground = MainWindow.MouseCheckClick.LastColor;
            MainWindow.MouseCheckClick.CheckClick = "";
        }
    }
}