using OddsSystemUI.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OddsSystemUI.Data.Contracts
{
    public interface IEventsService
    {
        Task<IEnumerable<SportEvent>> All();

        void Add(SportEvent sportEvent);

        void Edit(SportEvent sportEvent);

        void Delete(SportEvent sportEvent);
    }
}
