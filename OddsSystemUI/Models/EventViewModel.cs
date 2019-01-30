using OddsSystemUI.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace OddsSystemUI.Models
{
    public class EventViewModel
    {
        public long? Id { get; set; }

        [Required]
        public string EventName { get; set; }

        [Range(1.0, double.MaxValue)]
        public double OddsForFirstTeam { get; set; }

        [Range(1.0, double.MaxValue)]
        public double OddsForDraw { get; set; }

        [Range(1.0, double.MaxValue)]
        public double OddsForSecondTeam { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EventStartDate { get; set; }

        public EventViewModel()
        {

        }

        public EventViewModel(SportEvent sportEvent)
        {
            this.Id = sportEvent.Id;
            this.EventName = sportEvent.EventName;
            this.OddsForFirstTeam = sportEvent.OddsForFirstTeam;
            this.OddsForDraw = sportEvent.OddsForDraw;
            this.OddsForSecondTeam = sportEvent.OddsForSecondTeam;
            this.EventStartDate = sportEvent.EventStartDate;
        }

        public SportEvent ToDataModel()
        {
            var result = new SportEvent();
            result.Id = this.Id ?? 0;
            result.EventName = this.EventName;
            result.OddsForFirstTeam = this.OddsForFirstTeam;
            result.OddsForDraw = this.OddsForDraw;
            result.OddsForSecondTeam = this.OddsForSecondTeam;
            result.EventStartDate = this.EventStartDate;

            return result;
        }
    }
}
