using System;

namespace TaskListV2.Model
{
    public enum Category
    {
        Aufgaben,
        Privat,
        Arbeit,
        Familie,
        Programmieren
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


    public class Task
    {
        
        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public bool TaskComplete {  get; set; }

        public bool IsImportant { get; set; }

        public Category TaskCategory { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime Reminder { get; set; }

        public Repetition TaskRepetition { get; set; }
    }
}
