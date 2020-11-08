using System.Collections.Generic;
using System.Collections.ObjectModel;
using TaskListV2.Model;
using TaskListV2.DataAccessNew;
using System;

namespace TaskListV2.UI.Data
{
    class TaskListV2DataService : ITaskListV2DataService
    {
        private IDataAccessV2 _dataAccessV2;

        public TaskListV2DataService(IDataAccessV2 dataAccessV2)
        {
            _dataAccessV2 = dataAccessV2;
        }

        public IEnumerable<Task> GetAll()
        {
            //DataAccessV2 dataBase = new DataAccessV2();

            //return dataBase.GetTasks();

            return _dataAccessV2.GetTasks();

            //yield return new Task { TaskName = "Einkaufen gehen", TaskCategory = (Category)1 };
            //yield return new Task { TaskName = "Lernen", IsImportant = true, TaskComplete = true };
            //yield return new Task { TaskName = "Esse gehen", IsImportant = false, TaskCategory = (Category)2 };
            //yield return new Task { TaskName = "Gassi gehen", TaskCategory = (Category)0 };
        }

        public static List<string> LeftMenuItems = new List<string>
        {
            "Mein Tag",
            "Wichtig",
            "Geplant",
            "Aufgaben"
        };

        public IEnumerable<Task> Aufgaben()
        {
            return _dataAccessV2.GetTasks();
        }

        public IEnumerable<Task> Important()
        {
            return _dataAccessV2.Important();
        }
        public IEnumerable<Task> Today()
        {
            return _dataAccessV2.Today();
        }
        public IEnumerable<Task> Planned()
        {
            return _dataAccessV2.Planned();
        }
        public void CreateTask(string name, bool Complete, bool Important, DateTime Due, Reminder Reminder, Category Category, Repetition Repetition )
        {
            _dataAccessV2.CreateTask(name, Complete, Important, Due, Reminder, Category, Repetition);
        }
        public void IsComplete(string name, bool complete)
        {
            _dataAccessV2.IsComplete(name, complete);
        }



    }
}
