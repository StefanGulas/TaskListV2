using System.Collections.Generic;
using TaskListV2.Model;

namespace TaskListV2.DataAccessNew
{
    public interface IDataAccessV2
    {
        IEnumerable<Task> GetTasks();
        IEnumerable<Task> Important();
        IEnumerable<Task> Planned();
        IEnumerable<Task> Today();
    }
}