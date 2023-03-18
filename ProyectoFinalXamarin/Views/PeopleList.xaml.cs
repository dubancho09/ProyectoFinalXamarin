using ProyectoFinalXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeopleList : ContentPage
    {
        
        public PeopleList()
        {
            BindingContext = new VMPeopleList(Navigation);
            InitializeComponent();
        }
    }
}