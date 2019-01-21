using Hotel.CQRS.Events;
using Hotel.CQRS.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.CQRS.EventHandlers
{
   public class RoomCheckedInEventHandler : IEventHandler<RoomCheckedInEvent>
    {
        private readonly IReportDatabase _reportDatabase;
        public RoomCheckedInEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }
        public void Handle(RoomCheckedInEvent handle)
        {
            var item = _reportDatabase.GetById(handle.AggregateId);
            item.IsCheckedIn = handle.IsCheckedIn;
            item.Version = handle.Version;
        }
    }
}
