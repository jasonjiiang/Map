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
using Microsoft.Maps.MapControl.WPF;

namespace Map
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeCombo.SelectedIndex == 0)
            {
                DirectionCombo.IsEnabled = true;
            }
            else
            {
                DirectionCombo.IsEnabled = false;
            }
        }

        private void MapWithPushpins_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MapLayer mapLayer = new MapLayer();
            Image myPushPin = new Image();
            myPushPin.Source = null;
            myPushPin.Width = 32;
            myPushPin.Height = 32;

            if (TypeCombo.SelectedIndex != -1)
            {
                e.Handled = true;

                Point mousePosition = e.GetPosition(this);
                Location pinLocation = myMap.ViewportPointToLocation(mousePosition);

                mapLayer.AddChild(myPushPin, pinLocation, PositionOrigin.Center);

                myMap.Children.Add(mapLayer);
            }
            else 
            {
                MessageBox.Show("Nothing selected in 'Type' combobox!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (TypeCombo.SelectedIndex == 1)
            {
                myPushPin.Source = new BitmapImage(new Uri(@"/Map;component/Images/trafficlights.png", UriKind.Relative));
            }
            else 
            {
                switch (DirectionCombo.SelectedIndex)
                {
                    case 0:
                        myPushPin.Source = new BitmapImage(new Uri(@"/Map;component/Images/nuclearN.png", UriKind.Relative));
                        break;
                    case 1:
                        myPushPin.Source = new BitmapImage(new Uri(@"/Map;component/Images/nuclearNE.png", UriKind.Relative));
                        break;
                    case 2:
                        myPushPin.Source = new BitmapImage(new Uri(@"/Map;component/Images/nuclearE.png", UriKind.Relative));
                        break;
                    case 3:
                        myPushPin.Source = new BitmapImage(new Uri(@"/Map;component/Images/nuclearSE.png", UriKind.Relative));
                        break;
                    case 4:
                        myPushPin.Source = new BitmapImage(new Uri(@"/Map;component/Images/nuclearS.png", UriKind.Relative));
                        break;
                    case 5:
                        myPushPin.Source = new BitmapImage(new Uri(@"/Map;component/Images/nuclearSW.png", UriKind.Relative));
                        break;
                    case 6:
                        myPushPin.Source = new BitmapImage(new Uri(@"/Map;component/Images/nuclearW.png", UriKind.Relative));
                        break;
                    case 7:
                        myPushPin.Source = new BitmapImage(new Uri(@"/Map;component/Images/nuclearNW.png", UriKind.Relative));
                        break;
                    default:
                        MessageBox.Show("Nothing in 'Direction from' combobox!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;
                }
            }
        }
    }
}
