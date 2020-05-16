using System;
using System.IO;
using Xamarin.Forms;

namespace Notes 
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
   
    public partial class MainPage : ContentPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt"); // string that defines the file constructor 
        //file name stores "notes.txt" in the local app data, basically STORING WITHIN THE APP
        public MainPage()
        {
            InitializeComponent(); //FIRST INITIALIZE COMPONENTS IN THE MAIN PAGE READ THE EDITOR 
            if (File.Exists(_fileName)) //IF ELSE statement. IF the file EXIST, then READ it 
            {
                editor.Text = File.ReadAllText(_fileName); 
            }
        }
        void OnSaveButtonClicked(object sender, EventArgs e) //when CLICKED on the SAVE BUTTON execute the event handler 
        {
            File.WriteAllText(_fileName, editor.Text); //event handler: to save the written text to file 
        }
        void OnDeleteButtonClicked (object sender, EventArgs e) //when CLICKed  on the DELETE BUTTON 
        {
            if (File.Exists(_fileName)) //IF ELSE STATEMENT WITHIN DELETE EVENT HANDLER 
            {
                File.Delete(_fileName); //IF the file EXIST DELETE IT 
            }
            editor.Text = string.Empty;
        }
    }
}
