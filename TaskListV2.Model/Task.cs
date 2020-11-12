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
        
        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public bool TaskComplete { get; set; }

        public bool IsImportant { get; set; }

        public Category TaskCategory { get; set; }

        public DateTime DueDate { get; set; }

        public Reminder TaskReminder { get; set; }

        public Repetition TaskRepetition { get; set; }
    }
}
