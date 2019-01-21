using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.CQRS.Events
{
    public class RoomCheckedInEvent : Event
    {
        public bool IsCheckedIn { get; internal set; }
        public RoomCheckedInEvent(Guid aggregateId, bool isCheckedIn)
        {
            AggregateId = aggregateId;
            IsCheckedIn = isCheckedIn;
        }
    }
}
