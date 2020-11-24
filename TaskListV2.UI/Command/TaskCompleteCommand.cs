﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TaskListV2.UI.Data;
using TaskListV2.UI.ViewModel;

namespace TaskListV2.UI.Command
{
  class TaskCompleteCommand : ICommand
  {
    private readonly ITaskListV2DataService _taskDataService;

    public TaskCompleteCommand(ITaskListV2DataService taskDataService)
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
        _taskDataService.TaskIsComplete(mainViewModel.Complete, mainViewModel.TaskId);

        mainViewModel.RefreshTasks();

      }
    }
  }
}
