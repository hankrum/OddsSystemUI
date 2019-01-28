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
            //IEnumerable<SportEvent> models = new List<SportEvent>
            //{
            //    new SportEvent
            //    {
            //        EventName = "LiverPool-Juventus",
            //        OddsForFirstTeam = 1.95,
            //        OddsForDraw = 3.15,
            //        OddsForSecondTeam = 2.20,
            //        EventStartDate = new DateTime(2019,12,25,22,0, 0)
            //    },
            //     new SportEvent
            //   {
            //        EventName = "Grigor Dimitrov-Rafael Nadal",
            //        OddsForFirstTeam = 1.95,
            //        OddsForDraw = 3.15,
            //        OddsForSecondTeam = 2.20,
            //        EventStartDate = new DateTime(2019,12,25,22,0, 0)
            //    },
            //    new SportEvent
            //    {
            //        EventName = "Barcelona-Ludogorets",
            //        OddsForFirstTeam = 1.95,
            //        OddsForDraw = 3.15,
            //        OddsForSecondTeam = 2.20,
            //        EventStartDate = new DateTime(2019,01,25,22,0, 0)
            //    },
            //};

            IEnumerable<SportEvent> models = await this.restService.GetSportEvents();

            return models;
        }
    }
}
