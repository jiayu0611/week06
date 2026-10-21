using System.Numerics;
using System.Security.Cryptography.Xml;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace week06
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Color strokeColor = Colors.Black;
        Color fillColor = Colors.Transparent;
        int strokeThickness = 1;
        string shapeType = "Line";
        string actionType = "Draw";
        Point start = new Point { X = 0, Y = 0 };
        Point end = new Point { X = 0, Y = 0 };

        public MainWindow()
        {
            InitializeComponent();
            StrokeColorPicker.SelectedColor = strokeColor;
            FillColorPicker.SelectedColor = fillColor;
        }

        private void ShapeBotton_checked(object sender, RoutedEventArgs e)
        {
            var targetShapeButton = sender as RadioButton;
            shapeType = targetShapeButton.Tag.ToString();
            DisplayStatus();
        }

        private void StrokeColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            strokeColor = ((Color)StrokeColorPicker.SelectedColor);
            DisplayStatus();
        }

        private void DisplayStatus()
        {
            if (StatusLabel != null)
            {
                StatusLabel.Content = $"圖形 : {shapeType} 座標:({start.X}, {start.Y})-({end.X}, {end.Y})";
            }
            if (ColorLabel != null) ColorLabel.Content = $"筆刷色彩:{strokeColor}     填充色彩:{fillColor}     筆刷粗細:{strokeThickness}";
            if (ShapeLabel != null) ShapeLabel.Content = $"形狀:{shapeType}";
        }

        private void FillColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            fillColor = (Color)FillColorPicker.SelectedColor;
            DisplayStatus();
        }

        private void ThicknessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            strokeThickness = (int)ThicknessSlider.Value;
            DisplayStatus();
        }

        private void MtCanvas_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MyCanvas.Cursor = Cursors.Pen;
        }

        private void MtCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MyCanvas.Cursor = Cursors.Cross;
            start  = e.GetPosition(MyCanvas);

            if (actionType == "Draw")
            {
                switch (shapeType)
                {
                    case "Line":
                        Line line = new Line
                        {
                            X1 = start.X,
                            Y1 = start.Y,
                            X2 = end.X,
                            Y2 = end.Y,
                            Stroke = Brushes.Gray,
                            StrokeThickness = 1
                        };
                        MyCanvas.Children.Add(line);
                        break;
                    case "Rectangle":
                        break;
                    case "Ellipse":
                        break;
                    case "Polyline":
                        break;
                }
            }
        }

        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            end = e.GetPosition(MyCanvas);
            DisplayStatus();

            switch (actionType)
            {
                case "Draw":
                    if (e.LeftButton == MouseButtonState.Pressed)
                    {

                    }
                    break;
            }
        }

        private void MyCanvas_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}