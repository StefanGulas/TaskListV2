using System.Collections.Generic;
using System.Collections.ObjectModel;
using TaskListV2.Model;

namespace TaskListV2.UI.Data
{
    public interface ITaskListV2DataService
    {
        IEnumerable<Task> GetAll();
    }
}