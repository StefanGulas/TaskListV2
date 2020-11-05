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
    public class CreateTaskCommand : ICommand
    {
        private readonly ITaskListV2DataService _taskDataService;

        public CreateTaskCommand()
        {

        }
        
        //public CreateTaskCommand(ITaskListV2DataService taskDataService)
        //{
        //    _taskDataService = taskDataService;
        //}


        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is MainViewModel taskList && taskList.Name != null && taskList.Name != "")
            {
                taskList.Tasks.Add(new Task() { taskList.Name, taskList.Complete, taskList.Important, taskList.Due, taskList.Reminder, taskList.Category, taskList.Repetition});
                
                taskList.Name = "";

            }
        }
    }
}
