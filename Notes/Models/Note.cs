using System;


namespace Notes.Models
{
   public class Note //a class called Note that will store data of each note in the app 
    {
        public string Filename { get; set; } //get and set string of Filename, text, and date 
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
