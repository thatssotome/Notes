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
