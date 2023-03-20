using ProyectoFinalXamarin.Google;
using ProyectoFinalXamarin.ViewModels;
using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Location : ContentPage
    {
        public Location()
        {
            BindingContext = new VMLocation(Navigation);
            InitializeComponent();
        }

        private async void OnFrameClicked(object sender, EventArgs e)
        {
            var main = (VMLocation)BindingContext;
            if (!string.IsNullOrEmpty(main.Address))
            {
                map.Pins.Clear();
                var location = await GoogleApi.GetLocation(main.Address);
                var coordinates =  location.results.FirstOrDefault().geometry.location;
                var pin = new Pin
                {
                    Position = new Position(coordinates.lat, coordinates.lng),
                    Label = location.results.FirstOrDefault().formatted_address,
                    Type = PinType.SearchResult
                };
                map.Pins.Add(pin);
            }
        }
    }
}