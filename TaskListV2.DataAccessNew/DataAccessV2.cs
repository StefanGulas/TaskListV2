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
            using var con = HelperDataAccess.Conn();

            con.Open();

            string getTasks = "SELECT * FROM Tasks";

            IEnumerable<Task> taskList = new ObservableCollection<Task>(con.Query<Task>(getTasks).ToList());

            con.Close();

            return taskList;
        }

        public IEnumerable<Task> Wichtig()
        {
            using var con = HelperDataAccess.Conn();

            con.Open();

            string getTasks = "SELECT * FROM Tasks WHERE IsImportant = 'true'";

            IEnumerable<Task> taskList = new ObservableCollection<Task>(con.Query<Task>(getTasks).ToList());

            con.Close();

            return taskList;
        }

    }
}
