using Windows.UI.Xaml.Controls;

namespace App
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainPageViewModel();
        }

        public MainPageViewModel ViewModel => DataContext as MainPageViewModel;
    }
}
