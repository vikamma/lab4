using FontAwesome.WPF;
using lab_04.Tools;
using lab_04.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace lab_04
{

    public partial class MainWindow : Window
    {
        private ImageAwesome _loader;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new PersonViewModel(ShowLoader);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void ShowLoader(bool isShow)
        {
            LoaderManager.OnRequestLoader(GridPersonView, ref _loader, isShow);
        }
    
}
}
