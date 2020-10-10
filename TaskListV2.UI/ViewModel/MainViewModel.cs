using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TaskListV2.Model;
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
        


    }
}
