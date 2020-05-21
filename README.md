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

