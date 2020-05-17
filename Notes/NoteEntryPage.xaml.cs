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
            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                //save to a randomly generated filename(GETRANDOMFILE)
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt"); //combine string array for filepath 
                File.WriteAllText(filename, note.Text);
            }
            else
            {
                //update
                File.WriteAllText(note.Filename, note.Text);
            }
            await Navigation.PopAsync(); //method naviagates back to the previous page 
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }
            await Navigation.PopAsync();
        }
    } //close public partial class 
}