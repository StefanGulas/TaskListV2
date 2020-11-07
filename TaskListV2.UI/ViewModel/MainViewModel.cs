using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
        private string _name;

        public MainViewModel(ITaskListV2DataService taskDataService)
        {
            MenuItems = TaskListV2DataService.LeftMenuItems;
            Tasks = new ObservableCollection<Task>();
            _taskDataService = taskDataService;
            //createTaskCommand = new CreateTaskCommand();
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
        public ObservableCollection<Task> Tasks { get; set; }

        public string SelectedItem
        {
            get { return _selectedItem; }
            set { 
                _selectedItem = value;
                OnPropertyChanged();
                IEnumerable<Task> tasks;
                switch (_selectedItem)
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

        public IList<Category> TaskCategory        {
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
        
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public bool Complete { get; set; }
        public bool Important { get; set; }
        public DateTime Due { get; set; }
        public Repetition Repetition { get; set; }

        public ICommand createTaskCommand { get { return new CreateTaskCommand(); } }
        //public CreateTaskCommand createTaskCommand { get; private set; }


        public DateTime DisplayTaskDateStart
        {
            get { return DateTime.Today; }
        }


    }
}
