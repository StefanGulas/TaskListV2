using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
      string getTasks = "SELECT * FROM Tasks ORDER BY DueDate ASC";

      return Connect(getTasks);
    }

    public IEnumerable<Task> Important()
    {
      string getTasks = "SELECT * FROM Tasks WHERE IsImportant = 'true' ORDER BY DueDate ASC";

      return Connect(getTasks);
    }
    public IEnumerable<Task> Today()
    {
      string getTasks = "SELECT * FROM Tasks WHERE DueDate = CAST(CURRENT_TIMESTAMP AS DATE)";

      return Connect(getTasks);
    }

    public IEnumerable<Task> Planned()
    {
      DateTime nowTime = DateTime.Now.Date;
      string endTime = nowTime.ToString("dd.MM.yyyy");
      DateTime beforeTime = DateTime.Now.Date.AddDays(7);
      string startTime = beforeTime.ToString("dd.MM.yyyy");
      var parameters = new { StartTime = startTime, EndTime = endTime };
      string getTasks = "SELECT * FROM Tasks WHERE DueDate BETWEEN '" + endTime + "' AND '" + startTime + "' ORDER BY DueDate ASC";

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
    public void EditTask(int taskId, string name, Category category, DateTime due, Reminder reminder, Repetition repetition, bool important, bool complete)
    {
      using var con = HelperDataAccess.Conn();

      con.Open();

      //String dapperChecked = "UPDATE Tasks SET TaskName = '"+name+"', TaskCategory = '"+category+"', DueDate = '"+due+"', Reminder = '"+reminder+"', TaskRepetition = '"+repetition+"', IsImportant = '"+important+"' TaskComplete='"+complete+"' WHERE TaskId = '"+taskId+"'";

      //var affectedRows = con.Execute(dapperChecked, new { TaskName = name, TaskComplete = complete, IsImportant = important, TaskCategory = category, DueDate = due, Reminder = reminder, TaskRepetition = repetition });
      
      String dapperChecked = "UPDATE Tasks SET TaskName = '"+name+"', TaskCategory = '"+(int)category+"', DueDate = '"+due+"', Reminder = '"+(int)reminder+"', TaskRepetition = '"+(int)repetition+"', IsImportant = '"+important+"' WHERE TaskId = '"+taskId+"'";

      var affectedRows = con.Execute(dapperChecked, new { TaskName = name, IsImportant = important, TaskCategory = (int)category, DueDate = due, Reminder = (int)reminder, TaskRepetition = (int)repetition });      
      
      //String dapperChecked = "UPDATE Tasks SET TaskName = 'Golf Spielen' WHERE TaskId = '"+taskId+"'";

      //var affectedRows = con.Execute(dapperChecked, new { TaskName = "Golf Spielen" });
    }
  }
}
