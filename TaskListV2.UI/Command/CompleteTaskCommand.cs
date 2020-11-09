using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TaskListV2.DataAccessNew;
using TaskListV2.Model;
using TaskListV2.UI.Data;
using TaskListV2.UI.ViewModel;

namespace TaskListV2.UI.Command
{
    public class CompleteTaskCommand : ICommand
    {
        private readonly ITaskListV2DataService _taskDataService;

        public CompleteTaskCommand(ITaskListV2DataService taskDataService)
        {
            _taskDataService = taskDataService;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is MainViewModel mainViewModel)
            {
                _taskDataService.IsComplete(mainViewModel.Name, mainViewModel.Complete);
                
                mainViewModel.RefreshTasks();

            }
        }
    }
}
