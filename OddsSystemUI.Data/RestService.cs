using OddsSystemUI.Data.Contracts;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;
using System.Net;

namespace OddsSystemUI.Data
{
    public class RestService<T> where T : IId   //: IRestService    TODO
    {
        private HttpClient client = new HttpClient();


        //public RestService(string url)
        //{
        //    this.url = url;
        //}

        public async Task<IEnumerable<T>> GetAll() 
        {
            string url = "http://localhost:55545/api/SportEvent"; //TODO fix the url
            IEnumerable<T> events = null;
            var response = await client.GetStringAsync(url);
            events = JsonConvert.DeserializeObject<IEnumerable<T>>(response);  //TODO inject the Json
            return events;
        }

        public async Task<Uri> Create(T model)
        {
            string url = "http://localhost:55545/api/SportEvent";
            string json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json);
            HttpResponseMessage response = await client.PostAsync(url,  httpContent);

            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        public async Task<T> Update(T model) 
        {
            string url = "http://localhost:55545/api/SportEvent";
            string json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json);

            HttpResponseMessage response = await client.PutAsync(
                $"api/SportEvent/{model.Id}", httpContent);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            json = await response.Content.ReadAsStringAsync();
            model = JsonConvert.DeserializeObject<T>(json);
            return model;
        }

        public async Task<HttpStatusCode> Delete(long id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/SportEvent/{id}");
            return response.StatusCode;
        }

    }
}
