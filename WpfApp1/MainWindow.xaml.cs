using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        DispatcherTimer gametimer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            gametimer.Tick += GameLoop;
            gametimer.Interval = TimeSpan.FromMilliseconds(500);
            gametimer.Start();
        }

        private void GameLoop(object? sender, EventArgs e)
        {
            var brush = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255)));
            Ellipse circle = new Ellipse()
            {
                Tag = "circle",
                Height = 100,
                Width = 100,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Fill = brush
            };

            MyCanvas.Children.Add(circle);

            Canvas.SetLeft(circle, rnd.Next(0, 1920));
            Canvas.SetTop(circle, rnd.Next(0, 1080));
            if (MyCanvas.Children.Count == 10)
            {
                MyCanvas.Children.Remove(circle);
                gametimer.Interval = TimeSpan.FromMilliseconds(10000);
            }
        }

        private void MyCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse circle = (Ellipse)e.OriginalSource;
            MyCanvas.Children.Remove(circle);
            
        }
    }
}
