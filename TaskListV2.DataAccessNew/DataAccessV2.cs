using Dapper;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TaskListV2.Model;


namespace TaskListV2.DataAccessNew
{
    public class DataAccessV2 : IDataAccessV2
    {
        public IEnumerable<Task> GetTasks()
        {
            string getTasks = "SELECT * FROM Tasks";

            return Connect(getTasks);
        }

        public IEnumerable<Task> Important()
        {
            string getTasks = "SELECT * FROM Tasks WHERE IsImportant = 'true'";

            return Connect(getTasks);
        }
        public IEnumerable<Task> Today()
        {
            string getTasks = "SELECT * FROM Tasks WHERE IsImportant = 'true'";

            return Connect(getTasks);
        }

        public IEnumerable<Task> Planned()
        {
            string getTasks = "SELECT * FROM Tasks WHERE IsImportant = 'true'";

            return Connect(getTasks);
        }
        public IEnumerable<Task> Connect(string sqlQuery)
        {
            using var con = HelperDataAccess.Conn();

            con.Open();

            IEnumerable<Task> taskList = new ObservableCollection<Task>(con.Query<Task>(sqlQuery).ToList());

            con.Close();

            return taskList;
        }

    }
}
