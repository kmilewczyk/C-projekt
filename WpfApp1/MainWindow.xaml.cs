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

namespace WpfApp1
{
    struct PointInt { public int X; public int Y; public PointInt(int x, int y) { X = x; Y = y; } };
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int BOARD_WIDTH = 1000;
        private const int BOARD_HEIGHT = 680;
        private const int PLAYER_RADIOUS = 10;
        // wykrywanie kolizji: sprawdz czy gracz zderzyl sie z nieswiezymi bitami
        // jezeli tak to przegral
        // jezeli nie to zaznacza na planszy swieze bity i usuwa stare
        private double dpiX;
        private double dpiY;

        private WriteableBitmap wb;
        public MainWindow()
        {
            InitializeComponent();
        }


        PointInt currentPoint = new PointInt(100, 100);

        private void exampleBitmap_MouseUp(object sender, MouseButtonEventArgs e)
        {
            wb.DrawLineAa(currentPoint.X, currentPoint.Y, (int)e.GetPosition(exampleBitmap).X,  (int)e.GetPosition(exampleBitmap).Y, Colors.Black, 10);
            currentPoint.X = (int)e.GetPosition(exampleBitmap).X;
            currentPoint.Y = (int)e.GetPosition(exampleBitmap).Y;
        }

        private void mainWindow_Activated(object sender, EventArgs e)
        {
            Matrix m = PresentationSource.FromVisual(mainWindow).CompositionTarget.TransformToDevice;
            dpiX = m.M11;
            dpiY = m.M22;
            wb = new WriteableBitmap(BOARD_WIDTH, BOARD_HEIGHT, dpiX, dpiY, PixelFormats.Bgra32, null);
            exampleBitmap.Source = wb;
            wb.Clear(Colors.White);

            
        }
    }

    
}
