using OddsSystemUI.Data.Contracts;
using OddsSystemUI.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OddsSystemUI.Data
{
    public class EventsService : IEventsService
    {
        RestService<SportEvent> restService = new RestService<SportEvent>();    //TODO inject

        public async Task<IEnumerable<SportEvent>> All()
        {

            IEnumerable<SportEvent> models = await this.restService.GetAll();

            return models;
        }

        public async void Add(SportEvent sportEvent)
        {
           await this.restService.Create(sportEvent);   //TODO
        }
    }
}
