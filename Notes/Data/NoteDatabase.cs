using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Notes.Models;


namespace Notes.Data
{
    public class NoteDatabase
    {
        readonly SQLiteAsyncConnection _database; //a readonly connection, without writing

        public NoteDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath); //path of the database, dbPath in App.xaml
            _database.CreateTableAsync<Note>().Wait(); //creates table with Note Instance in the database 
        }

        public Task<List<Note>> GetNotesAsync()
        {
            return _database.Table<Note>().ToListAsync();
        } //get a Note instance from the _database, and synchronize, and display the Note instance in a List on the app 

        public Task<Note> GetNoteAsync(int id)
        {
            return _database.Table<Note>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        } //get a Note instance and synchronize, and set the autoincrement first value of the Note instance or a single file=i in the _database

        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.ID != 0)
            {
                return _database.UpdateAsync(note);
            }
            else 
            {
                return _database.InsertAsync(note);
            }
        } //if the note file already existed, and changes were made, update and return to the database 
            //else insert a new note file and save and return to the database 

        public Task<int> DeleteNoteAsync(Note note)
        {
            return _database.DeleteAsync(note);
        } //function to delete the single note in the Note instance, and update the Note instance in the database
    }
}
