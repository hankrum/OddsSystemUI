using OddsSystemUI.Data.Contracts;
using OddsSystemUI.Data.Models;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace OddsSystemUI.Data
{
    public class RestService : IRestService
    {
        private HttpClient client = new HttpClient();

        string url = "http://localhost:55545/api/SportEvent";

        //public RestService(string url)
        //{
        //    this.url = url;
        //}


        public async Task<IEnumerable<SportEvent>> GetSportEvents()
        {
            IEnumerable<SportEvent> events = null;
            var response = await client.GetStringAsync(this.url);
            var serializer = new DataContractJsonSerializer(typeof(IEnumerable<SportEvent>));
            events = JsonConvert.DeserializeObject<IEnumerable<SportEvent>>(response);
            return events;
        }
    }
}
