using ProyectoFinalXamarin.Models;
using ProyectoFinalXamarin.ViewModels.Base;
using ProyectoFinalXamarin.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinalXamarin.ViewModels
{
    public class VMEditPerson:BaseViewModel
    {
        #region VARIABLES
        public string UpName { get; set; }
        public string UpNumberPhone { get; set; }
        public string UpAddress { get; set; }
        #endregion
        #region CONSTRUCTOR
        public VMEditPerson(INavigation navigation)
        {
            Navigation = navigation;

            LoadData();
        }
        #endregion
        
        #region PROCESOS

        public void LoadData()
        {
            var Name =  (App.Current.Properties["name"].ToString());
            var NumberPhone = (App.Current.Properties["numberPhone"].ToString());
            var Address = (App.Current.Properties["address"].ToString());

            UpName = Name;
            UpNumberPhone = NumberPhone;
            UpAddress = Address;
        }
        public async Task EditAsync()
        {
            var id = (App.Current.Properties["id"].ToString());

            if(UpName != null)
            {
                if(UpNumberPhone != null)
                {
                    if(UpAddress != null)
                    {
                        var person = new Person()
                        {
                            Id = int.Parse(id),
                            Name = UpName,
                            NumberPhone = UpNumberPhone,
                            Address = UpAddress
                        };

                        var save = await App.Repo.InsertPerson(person);

                        if(save != 0)
                        {
                            await DisplayAlert("Registro", "El registro fue modificado con exito", "Ok");
                            await Navigation.PushAsync(new PeopleList());

                            //var existingPages = Navigation.NavigationStack.ToString();

                            //foreach (var page in existingPages)
                            //{
                            //    if (page.GetType() == typeof(PeopleList))
                            //        continue;

                            //    Navigation.RemovePage(page);
                            //}

                        }

                        else
                        {
                            await DisplayAlert("Registro", "El alumno no fue modificado", "Ok");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Alerta", "Debe ingresar la direccion", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Alerta", "Debe ingresar el numero", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Alerta", "Debe ingresar el nombre", "Ok");
            }
        }

        #endregion
        #region COMANDOS
        public ICommand EditAsyncCommand => new Command(async () => await EditAsync());
        #endregion
    }
}
