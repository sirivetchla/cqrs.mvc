using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.CQRS.Domain.Mementos
{
    public class HotelItemMemento: BaseMemento
    {
        public string CustomerName { get; internal set; }
        public string Email { get; internal set; }
        public string PhoneNo { get; internal set; }
        public int RoomNo { get; internal set; }
        public DateTime CheckIn { get; internal set; }
        public DateTime CheckOut { get; internal set; }
        public bool IsCheckedIn { get; internal set; }


        public int EventVersion { get; set; }

        public HotelItemMemento(Guid id, string customerName, string email, string phoneNo, int roomNo, DateTime checkIn, DateTime checkOut,bool isCheckIn,int version)
        {
        
            Id = id;
            Version = version;
            EventVersion = version;
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
