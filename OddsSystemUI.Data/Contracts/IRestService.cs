using OddsSystemUI.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OddsSystemUI.Data.Contracts
{
    public interface IRestService
    {
        Task<IEnumerable<SportEvent>> GetSportEvents();
    }
}
