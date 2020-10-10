using System.Collections.Generic;
using TaskListV2.Model;

namespace TaskListV2.UI.Data
{
    public interface ITaskListV2DataService
    {
        IEnumerable<Task> GetAll();
        IEnumerable<Task> Planned();
        IEnumerable<Task> Today();
        IEnumerable<Task> Important();
    }
}