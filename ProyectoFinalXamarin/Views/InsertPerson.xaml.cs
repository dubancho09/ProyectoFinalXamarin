using ProyectoFinalXamarin.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertPerson : ContentPage
    {
        public InsertPerson()
        {
            BindingContext = new VMInsertPerson(Navigation);
            InitializeComponent();
        }
    }
}