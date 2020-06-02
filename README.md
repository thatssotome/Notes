# General Purpose of Making this App 
- [x] Test the multi-platform software used to create mobile apps 
- [x] Allow users to connect to the database  
- [x] Allow users to add, edit, and delete items(notes) on the app and the database 
- [x] Synchronizing with the local application and the database 
- [x] Run Android Simulation to test Android deployment 
- [x] Run iPhone simulation WITHOUT owning a MAC to test iOS deployment 

![final](https://github.com/thatssotome/Notes/blob/master/finalnote.JPG)
![database](https://github.com/thatssotome/Notes/blob/Database/databasenoteentry.PNG)


# 1. First is the [SinglePage ](https://github.com/thatssotome/Notes/blob/Singlepage/README.md)
- [x] Add, edit, save, and delete entry within ONE page 
- [x] Layouts and buttons functions 

![single](https://github.com/thatssotome/Notes/blob/master/single_entry.PNG) 

# 2. Turning the SinglePage to a [MultiPage](https://github.com/thatssotome/Notes/blob/Multipage/README.md)
- [x] Addition to the functions of SinglePage
- [x] Created Multiple pages: NoteEntry Page and a Notes Page 
- [x] Use “async”, to sync and link multiple pages together  and navigation within 
- [x] Database and local storage within the App
- [x] Allow user to add, edit, save 

   ![multiple](https://github.com/thatssotome/Notes/blob/Multipage/mpp_note_entry.PNG)    ![multiple](https://github.com/thatssotome/Notes/blob/Multipage/mpp_note.PNG) 

# 3. Connect  to a [Database](https://github.com/thatssotome/Notes/blob/Database/README.md)
- [x] Connect to a Database and API testing 
- [x] Synchronize local application storage to Database storage
- [x] Allow user to add, edit, save, and delete to database 
# Database 
![database](https://github.com/thatssotome/Notes/blob/Database/database.PNG) ![database](https://github.com/thatssotome/Notes/blob/Database/databasenoteentry.PNG)



# 4. Finally Styling
- [x] All the functions and layouts are done 
- [x] Aesthetics and Customization

***


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Comparison: Multipage vs Database    
 ------
![notecscomparison](https://github.com/thatssotome/Notes/blob/Database/notecscomp.PNG)

***	
### NoteDatabase.cs 
* NoteDatabase`(string dbPath)` –string name `_database `with a connection to the SQLite database through the `dbPath` provided in _App.xaml_ 
* `CreateTableAsync` –Creates a table of the Note instances and sync with SQLite 
* `GetNotesAsync` –get the Note instance in the database, and display 
  * `ToListAsync` –display the return of the Note instance in the database into a ListView of the app 
  * `Task<Note> GetNoteAsync(int id)` –return the value of the Note instance, where the first or default value of the first instances of the Note or each file of the note is `AutoIncremented` and given a unique `ID` 
* `SaveNoteAsync` –**_IF/ELSE_** and return statements for each single _note_ in the _Note_ Instance
  * `IF` there were a change saved to a single note, then update the change and return it to the database 
  * `Else`, insert a new note and return it to the database 
* `DeleteNoteAsync` –**delete** a note and return the deletion to the database 
* NoteDatabase class contains code to create database, and allow read, write, and delete 
* Uses the asynchronous SQLite.Net APIs to move the database operations to the background 

### App.xaml.cs 
> Defines the Database property creates an instance of NoteDatabase and passes it as a singleton in the filename as a NoteDatabase constructor.  The advantage would be allowing the user to make single connections to the database, and then perform functions such as read and write, without having to open and close the database each time 

_**If / return**_ statement 
<br>If the database is _null_, string folder path connection to the database and the local application as a SINGLE instance</br>  

`get` the data files from the local application and 
<br>`IF `the database exist, 
  `null` for an object property, 
<br>pass the `get` data files through the `dbPath`, previously defined, into the database, and 
<br>`return` the display the database as one single `new NoteDatabase` instance </br>
 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Comparison: Multipage vs Database    
 ------
![noteappcomparison](https://github.com/thatssotome/Notes/blob/Database/noteappcomp.PNG)

***
### NotesPage.xaml.cs 
Make changes to the `async OnAppearing` method to populate the notes in the database 
<br>Populates a `listView` of the `ItemSource` from the note in the Database 

 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Comparison: Multipage vs Database    
 ------
   ![notespagecomparison](https://github.com/thatssotome/Notes/blob/Database/notespagecomp.PNG)

***

### NoteEntryPage.xaml.cs 
Define the files in the app as _var note_ to the `(Note)BindingContext` of the Database 
<br>Once defined the _**var note = Note Database**_,  the execution code is already taken care of in the _**NoteDatabase.cs**_ 

`OnSaveButtonClicked`  (event handler )–the   event handler is executed, the Note instance is saved to the Database, with its own IF/else statement from the `NoteDatabase` class in the **Data** folder

<br>`OnDeleteButtonClicked` event handler delete the Note instance in the database, with its own IF/ELSE statement written in the `NoteDatabase` class in the **Data** folder 

 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Comparison: Multipage vs Database    
 ------
![noteentrycomparison](https://github.com/thatssotome/Notes/blob/Database/noteentrycomp.PNG) 

***

