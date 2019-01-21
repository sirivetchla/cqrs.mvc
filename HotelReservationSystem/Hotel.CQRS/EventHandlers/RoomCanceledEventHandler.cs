using Hotel.CQRS.Events;
using Hotel.CQRS.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.CQRS.EventHandlers
{
   public class RoomCanceledEventHandler : IEventHandler<RoomCanceledEvent>
    {
        private readonly IReportDatabase _reportDatabase;
        public RoomCanceledEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }
        public void Handle(RoomCanceledEvent handle)
        {
            _reportDatabase.Delete(handle.AggregateId);
        }
    }
}
