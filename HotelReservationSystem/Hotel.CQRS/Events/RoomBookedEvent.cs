using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.CQRS.Events
{
    public class RoomBookedEvent:Event
    {
        public string CustomerName { get; internal set; }
        public string Email { get; internal set; }
        public string PhoneNo { get; internal set; }
        public int RoomNo { get; internal set; }
        public DateTime CheckIn { get; internal set; }
        public DateTime CheckOut { get; internal set; }
        public bool IsCheckedIn { get; internal set; }

        public RoomBookedEvent(Guid aggregateId, string customerName, string email, string phoneNo, int roomNo,DateTime checkIn, DateTime checkOut,bool isCheckIn)
        {
            AggregateId = aggregateId;
            CustomerName = customerName;
            Email = email;
            PhoneNo = phoneNo;
            RoomNo = roomNo;
            CheckIn = checkIn;
            CheckOut = checkOut;
            IsCheckedIn = isCheckIn;

        }
    }
}
