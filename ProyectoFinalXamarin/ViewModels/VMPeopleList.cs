using ProyectoFinalXamarin.Models;
using ProyectoFinalXamarin.ViewModels.Base;
using ProyectoFinalXamarin.Views;
using System;
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
        public Person PersonSelect { get; set; }
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        //Eliminar Persona
        public async Task DeletePersonAsync()
        {
            if (PersonSelect != null)
            {
                var resp = await DisplayAlert("Alerta", "¿Desea eliminar el registro seleccionado?", "Si", "No");
                if (resp)
                {
                    var del = App.Repo.DeletePerson(PersonSelect);
                    await DisplayAlert("Alerta", "El registro ha sido eliminado con exito", "ok");
                    await Navigation.PushAsync(new PeopleList());
                }
                else
                {
                    await DisplayAlert("Alerta", "El registro no ha sido eliminado", "ok");
                    await Navigation.PushAsync(new PeopleList());
                }
            }
            else
            {
                await DisplayAlert("Alerta", "Debe seleccionar un registro", "Ok");
            }
        }

        //Editar persona
        public async Task EditPageAsync()
        {
            if(PersonSelect != null)
            {
                App.Current.Properties["id"] = PersonSelect.Id;
                App.Current.Properties["name"] = PersonSelect.Name;
                App.Current.Properties["numberPhone"] = PersonSelect.NumberPhone;
                App.Current.Properties["address"] = PersonSelect.Address;
                await Navigation.PushAsync(new EditPerson());
            }
            else
            {
                await DisplayAlert("Alerta", "Debe seleccionar un registro", "Ok");
            }
            
        }

        //Ubicacion Persona
        public async Task LocationAsync()
        {
            if(PersonSelect != null)
            {
                App.Current.Properties["address"] = PersonSelect.Address;
                await Navigation.PushAsync(new Location());
            }
            else
            {
                await DisplayAlert("Alerta", "Debe seleccionar un registro", "Ok");
            }
        }
        #endregion
        #region COMANDOS

        public ICommand LocationAsyncCommand => new Command(async () => await LocationAsync());
        public ICommand EditAsyncCommand => new Command(async () => await EditPageAsync());
        public ICommand HomeAsyncCommand => new Command(async () => await HomeAsyncrono());
        public ICommand BackAsyncCommand => new Command(async () => await BackAsyncrono());
        public ICommand DeletePersonAsyncCommad => new Command(async () => await DeletePersonAsync());
        #endregion
    }
}
