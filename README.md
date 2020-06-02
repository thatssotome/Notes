
# General Purpose of Making this App 
- [x] Test the multi-platform software used to create mobile apps 
- [x] Allow users to connect to the database  
- [x] Allow users to add, edit, and delete items(notes) on the app and the database 
- [x] Synchronizing with the local application and the database 
- [x] Run Android Simulation to test Android deployment 
- [x] Run iPhone simulation WITHOUT owning a MAC to test iOS deployment 

# MultiPage App Note 
   ![multiple](https://github.com/thatssotome/Notes/blob/Multipage/mpp_note_entry.PNG)    ![multiple](https://github.com/thatssotome/Notes/blob/Multipage/mpp_note.PNG) 
* 	Created Multiple pages: NoteEntry Page and a Notes Page 
* 	Use “async”, to sync and link multiple pages together  and navigation within 
* 	Adding instances to each other 
* 	Created Note class in the Model Folder: Notes.Models 
* 	Store all the data on the local app
* 	Database and local storage within the App
* 	Allow user to add, delete, edit, and make changes to the app 
### Note.cs 
A **Note** _class_ that sets and stores all the data in the app, such as date, time, and filename 

## Note Entry Page 
* The _**second page**_ of the app

### NoteEntryPage.xaml 
> The layout of the use interface, Button, Grid and Text Editor  

### NoteEntryPage.xaml.cs
* Stores a note instance which represent in a single note in the **BindingContext** of the page 
* `OnSaveButtonClicked` –Event Handler and IF/ELSE statement 
  * _IF_ the content (string **NullorWhitespace**) SAVE to a new file with a randomly generated filename 
  * _Else_ Update to an existing file 
* `OnDeleteButtonClicked` –event handler IF statement 
  * _IF_ the file exist then **DELETE** and then navigate to the previous page 

## Notes Page 
### NotesPage.xaml 	
* The user interface layout of the NotesPage of the app 
* `ToolbarItem` –the “**+**” text display to initiate
* `OnNoteAddedClicked` (event handler) —to add new notes 
* _**ListView**_ –display data of the input text and date through data binding 
* `OnListViewItemSelected` (event handler) –that when the item under the NotesPage is selected , navigate to its 
### NotesPage.xaml.cs 
* Functionality of the NotesPage 
* `Using Notes.Models;` --still storing the data in the local application folder 
* `OnAppearing()` Method –populate a ListView of the notes in the application folder 
* `OnNoteAddedClicked` (event handler) —to Navigate to the new NoteEntryPage and bind its context to the new Note 
* `OnListViewSelected` (event handler) – IF the item is selected, navigate to the NoteEntryPage and bind is context with the selected item 
### App.xaml.cs 
* •	Namespace declaration for the System IO 
* •	Static Declaration for the string property FolderPath throughout the app 
* •	_**Initialize**_ the MainPage Property to be a NavigationPage,  that hosts an instance of the NotePage 
=======

# Styling
- [x] Function is done 
- [ ] Work on aesthetics 

* Styling the page: App.xaml, NoteEntryPage.xaml, NotePage.xaml 
* App.xaml define values, and codes that can be used throughout the app 
* NoteEntryPage.xaml and NotePage.xaml uses implicit styles in the App.xaml resource dictionary, and also its own implicit style for each Target Type of its page 


### App.xaml 
* `Application.Resources` –add styles and values to the ResourceDictionary on application-level 
* `Thickness x:Key` –defines the Thickness values for the ResourceDictionary 
* `Color x:Key` –defines the Color values for the ResourceDictionary 
* `Style TargetType="{x:Type NavigationPage}"` –add _implicit_ styles for **NavigationPage** to the ResourceDictionary 
* `Style TargetType="{x:Type ContentPage}"` –add _implicit_ styles for **ContentPage** to the ResourceDictionary 
All the styles made in the application-level ResourceDictionary can be used throughout the app 

### NotesPage.xaml 
* `ContentPage.Resources` –added implicit styles to the **ListView** for the NotesPage ResourceDictionary
  * The styles will be used for this page and this page only 
* `StaticResource PageMargin` –set the value of the **Margin** for the _ListView_ that was define in _App.xaml_ **Application.Resources** which is **20**

### NotesEntryPage.xaml
* `ContentPage.Resources` –add  implicit styles for Editor and Button to the Resource Dictionary of the _NotesEntryPage.xaml_  
* _Editor_ –the set the value of the **BackgroundColor** property to **AppBackgroundColor** in **App.xaml** 
* _Button_ –set the value for the property of **FontSize**, **BackgroundColor**, **TextColor**, **CornerRadius** 
* `ApplyToDerivedTypes` – set to be **True**, apply ONE single style to all the property of the **TargetType** button, so all the button style on the NoteEntryPage, as opposed to just one button instances, if the **ApplyToDerivedTypes** was not set 

***

# Database 
![database](https://github.com/thatssotome/Notes/blob/Database/database.PNG) ![database](https://github.com/thatssotome/Notes/blob/Database/databasenoteentry.PNG)
* The first installation of SQL Lite package, 
* Async  OnAppearing method to display the notes instance from the SQLite database on the local app
* Add, edit, delete and save on to the database
* Local application database = SQLite database NoteDatabase class contains code to create database, and allow read, write, and delete 
* Uses the asynchronous SQLite.Net APIs to move the database operations to the background 

> Installed NuGet Package Manager: sqlite-net-pcl, 
  <br>Author(s): Frank A. Krueger</br>
  <br>Id: sqlite-net-pcl </br>
  <br> NuGet link: sqlite-net-pcl</br>

* Add a folder named **Data** 
  * Add a **NoteDatabase** class in the Data folder 

> For the rest of the app, the **_note_ = a single note file**, in the app being added and update, the **_Note_ is class and instances of the database**

### Note.cs in Models
* Marked the `ID` of the Note class with `PrimaryKey` and `AutoIncrement` 
* So that each Note instance in the SQLite database will have its _own unique id_

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

# SinglePage App Note 
   ![single](https://github.com/thatssotome/Notes/blob/master/newapp.PNG)    ![single](https://github.com/thatssotome/Notes/blob/master/single_entry.PNG) 
* Add entry to the app 
* Save Button Save the Notes 
* Delete Button clears the note 

## MainPage.xaml
Layout of the User Interface 
* 	Label –to display the text 
* 	Grid –where to map out the text 
* 	Editor –the text input, for user to input the text 
* 	Button –2 buttons: Save and Delete 

## MainPage.xaml.cs 
The function of the User Interface 
* Creates a string for **_fileName** = the file Path 
* Initialize opening the file IF the file Exists 
* SaveButton—save the text input to _fileName string 
* DeleteButton –IF/ELSE statement, to delete IF **_fileName** exists, ElSE empty 



