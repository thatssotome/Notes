using System;
using System.IO;
using Xamarin.Forms;

namespace Notes
{
    public partial class App : Application
    {
        public static string FolderPath { get; private set; }
        public App()
        {
            InitializeComponent();
            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)); //declaration static for the FolderPath string property
            MainPage = new NavigationPage(new NotesPage()); //initialize MainPage to be Navigation page and host an instance of new NotesPage 
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
