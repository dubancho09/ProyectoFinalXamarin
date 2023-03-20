
using Newtonsoft.Json;
using ProyectoFinalXamarin.Resources;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProyectoFinalXamarin.Google
{
    public class GoogleApi
    {
        public static async Task<Root> GetLocation(string address)
        {
            var dataresponse = new Root();
            var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={address}&key=AIzaSyAdIamrxo_20mVeUmI1P87VArwT1MVgcBs";
            var http = new HttpClient();
            HttpResponseMessage response = await http.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                if (Convert.ToInt32(response.StatusCode) == 200)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    dataresponse = JsonConvert.DeserializeObject<Root>(data);
                }
            }
            return dataresponse;
        }
    }
}
