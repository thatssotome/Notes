using System;
using System.IO;
using Xamarin.Forms;
using Notes.Models; //using the Notes in Models folder 


namespace Notes
{
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e) //function of the Save button event handler of the NoteEntry Page 
        {
            var note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            await App.Database.SaveNoteAsync(note); //previous IF/ELSE statement, now correlates to the IF/ELSE statement in the NoteDatabase class in Data folder
            await Navigation.PopAsync(); //method naviagates back to the previous page 
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.Database.DeleteNoteAsync(note);
            await Navigation.PopAsync();
           
        }
    } //close public partial class 
}