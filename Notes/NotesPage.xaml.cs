using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Notes.Models; //still storing data back in the Note class in Model folder 


namespace Notes
{
    
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing() 
        {
            base.OnAppearing(); //populate a list view of any notes from the local application folder 
            var notes = new List<Note>();

            var files = Directory.EnumerateFiles(App.FolderPath, "*.notes.txt"); //class system IO directory 
            foreach (var filename in files) //for each of the filename in the files, read text and get date 
            {
                notes.Add(new Note
                { 
                    Filename = filename, 
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                });
            }
            listView.ItemsSource = notes
                .OrderBy(d => d.Date)
                .ToList(); //order by date 
        }
        async void OnNoteAddedClicked(object sender, EventArgs e)//OnNoteAddedClicked event handler, would navigate to the Note Entry Page
        {
            await Navigation.PushAsync(new NoteEntryPage { BindingContext = new Note() }); //Binding Context of the NoteEntryPage with the new Note instance 
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e) //OnListviewItemSelected would navigate to the NoteEntryPage when clicked the selected item 
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NoteEntryPage { BindingContext = e.SelectedItem as Note }); //BindingContext of the NoteEntryPage to the selected Note Instace 
            }
        }

    }
}