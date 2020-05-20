# MultiPage App Note 
   ![single](https://github.com/thatssotome/Notes/blob/master/newapp.PNG)    ![single](https://github.com/thatssotome/Notes/blob/master/newapp.PNG) 
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


