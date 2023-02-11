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
using System.Collections;
using System.Collections.ObjectModel;

namespace first
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        #region Свойства
        public static readonly DependencyProperty PointsProperty = DependencyProperty.Register(
            "Points", typeof(ObservableCollection<Point>), typeof(MainWindow), new PropertyMetadata(default(ObservableCollection<Point>)));

        public ObservableCollection<Point> Points
        {
            get
            {
                return (ObservableCollection<Point>)GetValue(PointsProperty);
            }
            set
            {
                SetValue(PointsProperty, value);
            }
        }

        public static readonly DependencyProperty AProperty = DependencyProperty.Register(
            "A", typeof(double), typeof(MainWindow), new PropertyMetadata(-10.0));

        public double A
        {
            get
            {
                return (double)GetValue(AProperty);
            }
            set
            {
                SetValue(AProperty, value);
            }
        }

        public static readonly DependencyProperty BProperty = DependencyProperty.Register(
            "B", typeof(double), typeof(MainWindow), new PropertyMetadata(10.0));

        public double B
        {
            get
            {
                return (double)GetValue(BProperty);
            }
            set
            {
                SetValue(BProperty, value);
            }
        }

        public static readonly DependencyProperty RangeFromProperty = DependencyProperty.Register(
            "RangeFrom", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double)));

        public double RangeFrom
        {
            get
            {
                return (double)GetValue(RangeFromProperty);
            }
            set
            {
                SetValue(RangeFromProperty, value);
            }
        }

        public static readonly DependencyProperty RangeToProperty = DependencyProperty.Register(
            "RangeTo", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double)));

        public double RangeTo
        {
            get
            {
                return (double)GetValue(RangeToProperty);
            }
            set
            {
                SetValue(RangeToProperty, value);
            }
        }

        public static readonly DependencyProperty AccuracyProperty = DependencyProperty.Register(
            "Accuracy", typeof(double), typeof(MainWindow), new PropertyMetadata(1e-4));

        public double Accuracy
        {
            get
            {
                return (double)GetValue(AccuracyProperty);
            }
            set
            {
                SetValue(AccuracyProperty, value);
            }
        } 
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            List<Point> points = new List<Point>();

            for (double x = A; x <= B; x += Accuracy)
            {
                if (Math.Abs(x) < 1e-2)
                {
                    continue;
                }
                
                var y = Math.Sin(2*x);
                points.Add(new Point(x, -y));
            }
            Points = new ObservableCollection<Point>(points);
        }
    }
}