using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TaskListV2.Model;
using TaskListV2.UI.Command;
using TaskListV2.UI.Data;

namespace TaskListV2.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ITaskListV2DataService _taskDataService;
        private Task _selectedTask;
        private string _selectedItem;

        public MainViewModel(ITaskListV2DataService taskDataService)
        {
            MenuItems = TaskListV2DataService.LeftMenuItems;
            Tasks = new ObservableCollection<Task>();
            _taskDataService = taskDataService;
        }

        public void Load(string dataAccessMethod = "GetAll")
        {
            var tasks = _taskDataService.GetAll();
            Tasks.Clear();
            foreach (var task in tasks)
            {
                Tasks.Add(task);
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
            }
        }

        public ObservableCollection<Task> Tasks

        {
            get { return _tasks; }
            set
            {
                _tasks = value;
                OnPropertyChanged();
                //RefreshTasks(SelectedItem);
            }
        }

        public Task SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                OnPropertyChanged();
            }
        }

        public IList<Category> TaskCategory
        {
            get
            {
                return Enum.GetValues(typeof(Category)).Cast<Category>().ToList<Category>();
            }
            set { }
        }

        private Category _category;
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

        private Reminder _reminder;
        public Reminder Reminder
        {
            get { return _reminder; }
            set
            {
                _reminder = value;
                OnPropertyChanged();
            }

        }

        public string Name { get; set; }
        public bool Complete { get; set; }
        public bool Important { get; set; }
        public DateTime Due { get; set; }
        public Repetition Repetition { get; set; }

        public ICommand CreateTaskCommand { get { return new CreateTaskCommand(_taskDataService); } }


        public DateTime DisplayTaskDateStart
        {
            get { return DateTime.Today; }
        }
    }



}
