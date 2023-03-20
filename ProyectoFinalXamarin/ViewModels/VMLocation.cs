using ProyectoFinalXamarin.ViewModels.Base;
using ProyectoFinalXamarin.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinalXamarin.ViewModels
{
    public class VMLocation:BaseViewModel
    {
        #region VARIABLES
        public string Address { get; set; }
        #endregion
        #region CONSTRUCTOR
        public VMLocation(INavigation navigation)
        {
            Navigation = navigation;
            LoadData();
        }
        #endregion
        
        #region PROCESOS
        public async Task HomeAsync()
        {
            await Navigation.PushAsync(new PeopleList());
        }

        public async Task BackAsync()
        {
            await Navigation.PushAsync(new PeopleList());
        }

        public void LoadData()
        {
            var address = (App.Current.Properties["address"].ToString());

            Address = address;
        }

        #endregion
        #region COMANDOS
        public ICommand HomeAsyncCommand => new Command(async () => await HomeAsync());
        public ICommand BackAsyncCommand => new Command(async () => await BackAsync());
        #endregion
    }
}
