using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TaskListV2.Model;
using TaskListV2.UI.Command;
using TaskListV2.UI.Data;
using System.Windows;
using TaskListV2.UI.ViewModel;

namespace TaskListV2.UI.ViewModel
{
  public class MainViewModel : ViewModelBase
  {
    private ITaskListV2DataService _taskDataService;
    private Task _selectedTask;
    private string _selectedItem;
    private string _name;

    public MainViewModel(ITaskListV2DataService taskDataService)
    {
      MenuItems = TaskListV2DataService.LeftMenuItems;
      Tasks = new ObservableCollection<Task>();
      _taskDataService = taskDataService;
      //createTaskCommand = new CreateTaskCommand();
    }

    public void Load()
    {
      var tasks = _taskDataService.GetAll();
      Tasks.Clear();
  
      foreach (var task in tasks)
      {
        Tasks.Add(task);
        if (task.IsImportant) task.ImportantStar = "Visible";
        else task.ImportantStar = "Hidden";
      }

    }

    public IEnumerable<string> MenuItems { get; set; }

    private ObservableCollection<Task> _tasks;



    public string SelectedItem
    {
      get { return _selectedItem; }
      set
      {
        _selectedItem = value;
        OnPropertyChanged();
        RefreshTasks();
      }
    }
    public void RefreshTasks()
    {
      IEnumerable<Task> tasks;
      switch (SelectedItem)
      {
        case "Wichtig":
          tasks = _taskDataService.Important();
          break;
        case "Aufgaben":
          tasks = _taskDataService.GetAll();
          break;
        case "Mein Tag":
          tasks = _taskDataService.Today();
          break;
        case "Geplant":
          tasks = _taskDataService.Planned();
          break;
        default:
          tasks = _taskDataService.GetAll();
          break;
      }
      Tasks.Clear();
      foreach (var task in tasks)
      {
        Tasks.Add(task);
        if (task.IsImportant) task.ImportantStar = "Visible";
        else task.ImportantStar = "Hidden";
      }
    }

    public ObservableCollection<Task> Tasks

    {
      get { return _tasks; }
      set
      {
        _tasks = value;
        OnPropertyChanged();
      }
    }

    public Task SelectedTask
    {
      get { return _selectedTask; }
      set
      {
        _selectedTask = value;
        OnPropertyChanged();
        if(_selectedTask != null) LoadTaskEdit();
      }
    }

    void LoadTaskEdit()
    {
      Name = _selectedTask.TaskName;
      Category = _selectedTask.TaskCategory;
      Due = _selectedTask.DueDate;
      Reminder = _selectedTask.Reminder;
      Repetition = _selectedTask.TaskRepetition;
      Important = _selectedTask.IsImportant;
      //SlideGridAddTask.Width = 400;
    }
    public IList<Category> TaskCategories
    {
      get
      {
        return Enum.GetValues(typeof(Category)).Cast<Category>().ToList<Category>();
      }
      set { }
    }

    private Category _category = 0;
    public Category Category
    {
      get { return _category; }
      set
      {
        _category = value;
        OnPropertyChanged();
      }

    }

    public IList<Reminder> ReminderList
    {
      get
      {
        return Enum.GetValues(typeof(Reminder)).Cast<Reminder>().ToList<Reminder>();
      }
      set { }
    }

    private Reminder _reminder = 0;
    public Reminder Reminder
    {
      get { return _reminder; }
      set
      {
        _reminder = value;
        OnPropertyChanged();
      }

    }

    public IList<Repetition> RepetitionList
    {
      get
      {
        return Enum.GetValues(typeof(Repetition)).Cast<Repetition>().ToList<Repetition>();
      }
      set { }
    }

    private Repetition _repetition = 0;
    public Repetition Repetition
    {
      get { return _repetition; }
      set
      {
        _repetition = value;
        OnPropertyChanged();
      }

    }


    public string Name
    {
      get { return _name; }
      set
      {
        _name = value;
        OnPropertyChanged();
      }
    }

    private bool _complete;

    public bool Complete
    {
      get { return _complete; }
      set
      {
        _complete = value;
        //OnPropertyChanged();
        _taskDataService.IsComplete(Name, Complete);
      }
    }

    public bool Important { get; set; }

    private DateTime _due = DateTime.Now;
    public DateTime Due
    {
      get { return _due; }
      set
      {
        _due = value;
        OnPropertyChanged();

      }
    }

    private string _isVisible;

    public string IsVisible
    {
      get { return _isVisible; }
      set { _isVisible = "Hidden"; }
    }


    public ICommand createTaskCommand { get { return new CreateTaskCommand(_taskDataService); } }
    public ICommand completeTaskCommand { get { return new CompleteTaskCommand(_taskDataService); } }

    //public DateTime DisplayTaskDateStart
    //{
    //  get { return DateTime.Today; }
    //}
  }



}
