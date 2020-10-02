using System.Collections.Generic;
using TaskListV2.Model;

namespace TaskListV2.UI.Data
{
    interface ITaskListV2DataService
    {
        IEnumerable<Task> GetAll();
    }
}