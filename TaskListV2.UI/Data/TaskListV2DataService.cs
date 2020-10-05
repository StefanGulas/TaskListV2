using System.Collections.Generic;
using System.Collections.ObjectModel;
using TaskListV2.Model;

namespace TaskListV2.UI.Data
{
    class TaskListV2DataService : ITaskListV2DataService
    {
        public IEnumerable<Task> GetAll()
        {
            // ToDo: load data from real database
            yield return new Task { TaskName = "Einkaufen gehen", TaskCategory = (Category)1 };
            yield return new Task { TaskName = "Lernen", IsImportant = true, TaskComplete = true };
            yield return new Task { TaskName = "Esse gehen", IsImportant = false, TaskCategory = (Category)2 };
            yield return new Task { TaskName = "Gassi gehen", TaskCategory = (Category)0 };
        }

        public static List<string> LeftMenuItems = new List<string>
        {
            "Mein Tag",
            "Wichtig",
            "Aufgaben"
        };
    }
}
