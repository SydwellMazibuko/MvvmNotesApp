using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MvvmNotesApp.Models
{
    /*
     * The class defines a Note model that will store data about each note in the application.
     * The ID prop is a PrimaryKey and made to AutoIncrement to ensure that each Note in the SQLite.NET
     * database will have a unique id.
     */
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
