using System;
using System.IO;
using Xamarin.Forms;
using Notes.Data;

namespace Notes
{
    public partial class App : Application
    {
        static NoteDatabase database;

        public static NoteDatabase Database
        {
            get
            {
                if(database == null)
                {
                    database = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                } //get the datafiles from local app 
                //passes the data files on the local app through the dbfolder path into the database 
                return database; //return as one single NoteDatabase instances 
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new NotesPage()); //initialize MainPage to be Navigation page and host an instance of new NotesPage 
        }

        protected override void OnStart()
        {
            //when app starts 
        }

        protected override void OnSleep()
        {
            //when app sleeps 
        }

        protected override void OnResume()
        {
            //when app resumes 
        }
    }
}
