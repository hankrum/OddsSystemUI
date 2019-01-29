using OddsSystemUI.Data.Contracts;
using OddsSystemUI.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OddsSystemUI.Data
{
    public class EventsService : IEventsService
    {
        IRestService restService = new RestService();

        public async Task<IEnumerable<SportEvent>> All()
        {

            IEnumerable<SportEvent> models = await this.restService.GetSportEvents();

            return models;
        }

        public async void Add(SportEvent sportEvent)
        {
            await this.restService.Add(sportEvent);
        }
    }
}
