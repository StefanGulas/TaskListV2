using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using TaskListV2.Model;


namespace TaskListV2.DataAccessNew
{
    public class DataAccessV2 : IDataAccessV2
    {
        public IEnumerable<Task> Connect(string sqlQuery)
        {
            using var con = HelperDataAccess.Conn();

            con.Open();

            IEnumerable<Task> taskList = new ObservableCollection<Task>(con.Query<Task>(sqlQuery).ToList());

            con.Close();

            return taskList;
        }

        public IEnumerable<Task> GetTasks()
        {
            string getTasks = "SELECT * FROM Tasks ORDER BY DueDate DESC";

            return Connect(getTasks);
        }

        public IEnumerable<Task> Important()
        {
            string getTasks = "SELECT * FROM Tasks WHERE IsImportant = 'true'";

            return Connect(getTasks);
        }
        public IEnumerable<Task> Today()
        {
            string getTasks = "SELECT * FROM Tasks WHERE DueDate = CAST(CURRENT_TIMESTAMP AS DATE)";

            return Connect(getTasks);
        }

        public IEnumerable<Task> Planned()
        {
            string getTasks = "SELECT * FROM Tasks WHERE IsImportant = 'true'";

            return Connect(getTasks);
        }

        public void CreateTask(string name, bool Complete, bool Important, DateTime Due, Reminder Reminder, Category Category, Repetition Repetition)
        {
            using var con = HelperDataAccess.Conn();

            con.Open();

            string insertTask = "INSERT INTO dbo.[Tasks] (TaskName, TaskComplete, IsImportant, TaskCategory, DueDate, Reminder, TaskRepetition) VALUES" +
                "(@TaskName, @TaskComplete, @IsImportant, @TaskCategory, @DueDate, @Reminder, @TaskRepetition)";

            var affectedRows = con.Execute(insertTask, new { TaskName = name, TaskComplete = Complete, IsImportant = Important, TaskCategory = Category, DueDate = Due, Reminder = Reminder, TaskRepetition = Repetition });

            con.Close();
        }
        public void IsComplete(string name, bool complete)
        {
            using var con = HelperDataAccess.Conn();

            con.Open();

            String dapperChecked = "UPDATE Tasks SET Complete = @Complete WHERE TaskName = @TaskName";

            var affectedRows = con.Execute(dapperChecked, new { TaskComplete = complete, TaskName = name });
        }
    }
}
