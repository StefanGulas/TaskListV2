using Dapper;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TaskListV2.Model;


namespace TaskListV2.DataAccessNew
{
    public static class DataAccess
    {
        public static IEnumerable<Task> GetTasks()
        {
            using var con = HelperDataAccess.Conn();

            con.Open();

            string getTasks = "SELECT * FROM Tasks ORDER BY Complete, TaskId DESC";

            ObservableCollection<Task> taskList = new ObservableCollection<Task>(con.Query<Task>(getTasks).ToList());

            con.Close();

            return taskList;
        }
    }
}
