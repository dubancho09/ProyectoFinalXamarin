using ProyectoFinalXamarin.Models;
using ProyectoFinalXamarin.ViewModels.Base;
using ProyectoFinalXamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinalXamarin.ViewModels
{
    public class VMPeopleList : BaseViewModel
    {
        #region VARIABLES
        public ObservableCollection<Person> PersonList { get; set; }
        #endregion
        #region CONSTRUCTOR
        public VMPeopleList(INavigation navigation)
        {
            Navigation = navigation;
            GetPerson();
        }
        #endregion
        
        #region PROCESOS
        //Navegar Atras
        public async Task BackAsyncrono()
        {
            await Navigation.PopAsync();
        }

        //Navegar Pagina Inicio
        public async Task HomeAsyncrono()
        {
            await Navigation.PushAsync(new InsertPerson());
        }

        //LLenar la lista personas
        public async void GetPerson()
        {
            PersonList = new ObservableCollection<Person>();

            try
            {
                var mylist = await App.Repo.GetAllPerson();

                foreach (var person in mylist)
                {
                    //await DisplayAlert("Datos", person.Id.ToString(), "Ok");
                    PersonList.Add(new Person
                    {
                        Id = person.Id,
                        Name = person.Name,
                        NumberPhone = person.NumberPhone,
                        Address = person.Address,
                    });

                    
                }



                
            }
            catch
            {
                await DisplayAlert("Error", "Ha ocurrido un error mientras se intentaba mostrar la lista de personas, itenta mas tarde...", "Ok");
            }
            
        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand HomeAsyncCommand => new Command(async () => await HomeAsyncrono());
        public ICommand BackAsyncCommand => new Command(async () => await BackAsyncrono());
        public ICommand ProcespSimpleCommand => new Command(ProcesoSimple);
        #endregion
    }
}
