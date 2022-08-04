using System.Windows;
using ClassLibrary1;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ISignalRService signalRService = new SignalRService();
            signalRService.ConnectAsync();
        }
    }
}
