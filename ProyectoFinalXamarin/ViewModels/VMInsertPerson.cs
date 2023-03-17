using ProyectoFinalXamarin.Models;
using ProyectoFinalXamarin.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinalXamarin.ViewModels
{
    public class VMInsertPerson : BaseViewModel
    {
        #region VARIABLES
        public Person person { get; set; }
        #endregion
        #region CONSTRUCTOR
        public VMInsertPerson(INavigation navigation)
        {
            Navigation = navigation;
            person = new Person();
        }
        #endregion
        
        #region PROCESOS
        public async Task SaveAsync()
        {
            var res = await App.Repo.InsertPerson(person);

            if(res != 0)
            {
                await DisplayAlert("Exito", "El registro se guardo correctamente", "Ok");
            }
            else
            {
                await DisplayAlert("Error", "El registro no se guardo correctamente", "Ok");
            }
        }

        //Validar campos del formulario
        public async Task ValidateAsync()
        {
            if(person == null)
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios", "Ok");
            } 
            else if(person.Name == null)
            {
                await DisplayAlert("Error", "El campo nombre es obligatorio", "Ok");
            }
            else if (person.NumberPhone == null)
            {
                await DisplayAlert("Error", "El campo teléfono es obligatorio", "Ok");
            }
            else if (person.Address == null)
            {
                await DisplayAlert("Error", "El campo dirección es obligatorio", "Ok");
            }
            else
            {
                await SaveAsync();
            }
            
            
            

        }
        #endregion
        #region COMANDOS
        public ICommand ValidateAsyncCommand => new Command(async () => await ValidateAsync());
        //public ICommand ValidateCommand => new Command(Validate);
        #endregion
    }
}
