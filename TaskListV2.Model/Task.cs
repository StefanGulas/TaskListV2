using System;

namespace TaskListV2.Model
{
  public enum Category
  {
    Aufgaben = 0,
    Privat = 1,
    Arbeit = 2,
    Familie = 3,
    Programmieren = 4
  }

  public enum Repetition
  {
    Keine,
    Täglich,
    Wochentage,
    Wöchentlich,
    Monatlich,
    Jährlich
  }

  public enum Reminder
  {
    Keine,
    Eine_Stunde_vorher,
    Zwei_Stunden_vorher,
    Ein_Tag_vorher,
    Zwei_Tage_vorher
  }


  public class Task
  {

    //public Task()
    //{
    //  if (_isImportant) ImportantStar = "Visible";
    //  else if(!_isImportant) ImportantStar = "Hidden";
    //}
    
    public int TaskId { get; set; }

    public string TaskName { get; set; }

    public bool TaskComplete { get; set; }

    private bool _isImportant;
    public bool IsImportant 
    {
      get { return _isImportant; }
      set { _isImportant = value; } 
    }

    public Category TaskCategory { get; set; }

    private DateTime _dueDate;
    public DateTime DueDate
    {
      get { return _dueDate.Date; }
      set { _dueDate = value.Date; }
    }

    public Reminder TaskReminder { get; set; }

    public Repetition TaskRepetition { get; set; }
    
    public string DueString 
    {
      get { return _dueDate.Date.ToString("dd. MMM. yyyy"); }
      set {; }
    }

    public string ImportantStar { get; set; }




  }
}
