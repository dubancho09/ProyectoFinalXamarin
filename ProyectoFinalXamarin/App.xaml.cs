using ProyectoFinalXamarin.Repository;
using ProyectoFinalXamarin.Views;
using System;
using System.IO;
using Xamarin.Forms;

namespace ProyectoFinalXamarin
{
    public partial class App : Application
    {
        static PersonRepository repo;

        //Crear conexion 
        public static PersonRepository Repo
        {
            get
            {
                if (repo == null)
                {
                    repo  = new PersonRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Person.db3"));
                }

                return repo;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new InsertPerson());
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
