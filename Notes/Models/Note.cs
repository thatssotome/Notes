using System;
using SQLite;

namespace Notes.Models
{
    public class Note //a class called Note that will store data of each note in the app 
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; } //autoincrements of each note instance and its unqiue primary key  
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
