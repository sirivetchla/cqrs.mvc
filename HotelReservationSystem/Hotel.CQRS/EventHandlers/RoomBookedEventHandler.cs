using Hotel.CQRS.Events;
using Hotel.CQRS.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.CQRS.EventHandlers
{
    public class RoomBookedEventHandler : IEventHandler<RoomBookedEvent>
    {
        private readonly IReportDatabase _reportDatabase;
        public RoomBookedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }
        public void Handle(RoomBookedEvent handle)
        {
            HotelDto item = new HotelDto()
            {
                Id = handle.AggregateId,
                Version = handle.Version,
                CustomerName = handle.CustomerName,
                Email = handle.Email,
                PhoneNo = handle.PhoneNo,
                RoomNo = handle.RoomNo,
                CheckIn=handle.CheckIn,
                CheckOut=handle.CheckOut,
                IsCheckedIn=handle.IsCheckedIn
               
            };

            _reportDatabase.Add(item);
        }
    }
}
