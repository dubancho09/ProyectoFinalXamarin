using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinalXamarin.ViewModels.Base
{
    public class VMPattern : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        #endregion
        #region CONSTRUCTOR
        public VMPattern(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }

        public void ProcesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncCommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcespSimpleCommand => new Command(ProcesoSimple);
        #endregion
    }
}
