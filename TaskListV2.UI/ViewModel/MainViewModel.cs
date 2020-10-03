using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TaskListV2.Model;
using TaskListV2.UI.Data;

namespace TaskListV2.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ITaskListV2DataService _taskDataService;
        private Task _selectedTask;


        public MainViewModel(ITaskListV2DataService taskDataService)
        {
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

        public ObservableCollection<Task> Tasks { get; set; }

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
