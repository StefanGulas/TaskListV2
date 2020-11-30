using System;
using System.Windows;
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
      SlideGridEditTask.Width = 0;
      RefreshAddNewTaskFields();

    }

    private void RefreshAddNewTaskFields()
    {
      ToDoTextBox.Text = "";
      TaskCategoryComboBox.SelectedIndex = 0;
      ReminderComboBox.SelectedIndex = 0;
      RepetitionComboBox.SelectedIndex = 0;
      ImportantCheckBoxCreate.IsChecked = false;
      dt_StartDateFrom.SelectedDate = DateTime.Today;

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
      SlideGridAddTask.Width = 1100;
      PopUpOpenButton.Visibility = Visibility.Hidden;
      ListViewTaskList.SelectedValue = null;
      RefreshAddNewTaskFields();
    }

    private void CreateTaskButton_Click(object sender, RoutedEventArgs e)
    {
      SlideGridAddTask.Width = 0;
      PopUpOpenButton.Visibility = Visibility.Visible;
      //RefreshAddNewTaskFields();


    }

    private void SlideGridBackButton_Click(object sender, RoutedEventArgs e)
    {
      SlideGridAddTask.Width = 0;
      PopUpOpenButton.Visibility = Visibility.Visible;
      ListViewTaskList.SelectedValue = null;

    }


    private void ListViewTaskList_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      SlideGridEditTask.Width = 1100;
      PopUpOpenButton.Visibility = Visibility.Hidden;
      //ImportantCheckBoxEdit.IsChecked = false;


    }

    private void SlideGridEditBackButton_Click(object sender, RoutedEventArgs e)
    {
      SlideGridEditTask.Width = 0;
      PopUpOpenButton.Visibility = Visibility.Visible;
      ListViewTaskList.SelectedValue = null;

    }

    private void EditTaskButton_Click(object sender, RoutedEventArgs e)
    {
      SlideGridEditTask.Width = 0;
      PopUpOpenButton.Visibility = Visibility.Visible;
      //RefreshAddNewTaskFields();

    }

    private void GrayEditArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      SlideGridEditTask.Width = 0;
      PopUpOpenButton.Visibility = Visibility.Visible;
      ListViewTaskList.SelectedValue = null;

    }

    private void GrayCreateArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      SlideGridAddTask.Width = 0;
      PopUpOpenButton.Visibility = Visibility.Visible;
      ListViewTaskList.SelectedValue = null;
    }

    private void CheckBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      _viewModel.RefreshTasksAfterComplete();
    }

    private void CheckBox_MouseDown(object sender, MouseButtonEventArgs e)
    {
      _viewModel.RefreshTasksAfterComplete();

    }

    private void CheckBox_MouseWheel(object sender, MouseWheelEventArgs e)
    {
      _viewModel.RefreshTasksAfterComplete();

    }

    private void CheckBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      _viewModel.RefreshTasksAfterComplete();

    }

    private void CheckBox_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
      _viewModel.RefreshTasksAfterComplete();

    }

    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
      _viewModel.RefreshTasksAfterComplete();

    }
  }
}
