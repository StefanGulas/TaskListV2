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

        public void Load()
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
        
        public IList<Priority> TaskPriorities
        {
            get
            {
                return Enum.GetValues(typeof(Priority)).Cast<Priority>().ToList<Priority>();
            }
            set { }
        }

    }
}
