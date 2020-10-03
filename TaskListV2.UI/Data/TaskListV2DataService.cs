﻿using System.Collections.Generic;
using TaskListV2.Model;

namespace TaskListV2.UI.Data
{
    class TaskListV2DataService : ITaskListV2DataService
    {
        public IEnumerable<Task> GetAll()
        {
            // ToDo: load data from real database
            yield return new Task { TaskName = "Einkaufen gehen", TaskPriority = (Priority)1 };
            yield return new Task { TaskName = "Lernen", TaskPriority = (Priority)2, TaskComplete = true };
            yield return new Task { TaskName = "Esse gehen", TaskPriority = (Priority)3 };
            yield return new Task { TaskName = "Gassi gehen", TaskPriority = (Priority)0 };
        }
    }
}
