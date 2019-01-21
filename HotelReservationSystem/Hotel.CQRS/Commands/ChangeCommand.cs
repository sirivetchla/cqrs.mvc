using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.CQRS.Commands
{
   public class ChangeCommand : Command
    {
        public string CustomerName { get; internal set; }
        public string Email { get; internal set; }
        public string PhoneNo { get; internal set; }
        public int RoomNo { get; internal set; }
        public DateTime CheckIn { get; internal set; }
        public DateTime CheckOut { get; internal set; }
        public bool IsCheckedIn { get; internal set; }


        public ChangeCommand(Guid aggregateId, string customerName, string email, string phoneNo, int roomNo, int version, DateTime checkIn, DateTime checkOut, bool isCheckedIn)
            : base(aggregateId, version)
        {
            CustomerName = customerName;
            Email = email;
            PhoneNo = phoneNo;
            RoomNo = roomNo;
            CheckIn = checkIn;
            CheckOut = checkOut;
            IsCheckedIn = isCheckedIn;
        }
    }
}
