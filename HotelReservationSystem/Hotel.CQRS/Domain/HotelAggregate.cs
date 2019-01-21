using Hotel.CQRS.Domain.Mementos;
using Hotel.CQRS.Events;
using Hotel.CQRS.Storage.Memento;
using System;

namespace Hotel.CQRS.Domain
{
    public class HotelAggregate : AggregateRoot,
        IHandle<RoomBookedEvent>,
        IHandle<RoomCanceledEvent>,
        IHandle<RoomCheckedInEvent>,
        IOriginator
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public int RoomNo { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool IsCheckedIn { get; set; }

        public HotelAggregate()
        {

        }
        public HotelAggregate(Guid id, string customerName, string email, string phoneNo, int roomNo, DateTime checkIn, DateTime checkOut,bool isCheckIn)
        {
            ApplyChange(new RoomBookedEvent(id, customerName, email, phoneNo, roomNo, checkIn, checkOut,isCheckIn));
        }

        public void RoomChekIn(bool isCheckIn)
        {
            ApplyChange(new RoomCheckedInEvent(Id, isCheckIn));
        }
        public void Delete()
        {
            ApplyChange(new RoomCanceledEvent(Id));
        }

        public void Handle(RoomCanceledEvent e)
        {

        }

        public void Handle(RoomBookedEvent e)
        {
            CustomerName = e.CustomerName;
            Email = e.Email;
            PhoneNo = e.PhoneNo;
            RoomNo = e.RoomNo;
            CheckIn = e.CheckIn;
            CheckOut = e.CheckOut;
            IsCheckedIn = e.IsCheckedIn;
            Id = e.AggregateId;
            Version = e.Version;
        }
        public void Handle(RoomCheckedInEvent e)
        {
            IsCheckedIn = e.IsCheckedIn;
        }

        public BaseMemento GetMemento()
        {
            return new HotelItemMemento(Id, CustomerName, Email, PhoneNo, RoomNo, CheckIn, CheckOut,IsCheckedIn, Version);
        }

        public void SetMemento(BaseMemento memento)
        {
            Id = memento.Id;
            Version = memento.Version;
            CustomerName = ((HotelItemMemento)memento).CustomerName;
            Email = ((HotelItemMemento)memento).Email;
            PhoneNo = ((HotelItemMemento)memento).PhoneNo;
            RoomNo = ((HotelItemMemento)memento).RoomNo;
            CheckIn = ((HotelItemMemento)memento).CheckIn;
            CheckOut = ((HotelItemMemento)memento).CheckOut;
            IsCheckedIn = ((HotelItemMemento)memento).IsCheckedIn;
        }
    }
}
