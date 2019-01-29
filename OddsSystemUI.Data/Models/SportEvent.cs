using System;

namespace OddsSystemUI.Data.Models
{
    public class SportEvent
    {
        public long Id { get; set; }

        public string EventName { get; set; }

        public double OddsForFirstTeam { get; set; }

        public double OddsForDraw { get; set; }

        public double OddsForSecondTeam { get; set; }

        public DateTime EventStartDate { get; set; }
    }
}
