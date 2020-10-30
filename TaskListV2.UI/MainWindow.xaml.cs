 using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using TaskListV2.UI.Command;
using TaskListV2.UI.ViewModel;

namespace TaskListV2.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            Loaded += MainWindow_Loaded;
            SlideGridAddTask.Width = 0;

            //Binding binding = new Binding("Text");
            //binding.Source = CreateTaskCommand;
            //lblValue.SetBinding(TextBlock.TextProperty, binding);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.Load();
        }
        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void PackIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void PackIcon_ColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color> e)
        {

        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void PopUpOpenButton_Click(object sender, RoutedEventArgs e)
        {
            SlideGridAddTask.Width = 400;
            PopUpOpenButton.Visibility = Visibility.Hidden;

        }

        private void CreateTaskButton_Click(object sender, RoutedEventArgs e)
        {
            SlideGridAddTask.Width = 0;
            PopUpOpenButton.Visibility = Visibility.Visible;

 

        }
    }
}
