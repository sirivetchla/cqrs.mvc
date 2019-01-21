﻿using Hotel.CQRS.Commands;
using Hotel.CQRS.Domain;
using Hotel.CQRS.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.CQRS.CommandHandlers
{
   public class CreateCommandHandler : ICommandHandler<CreateCommand>
    {
        private IRepository<HotelAggregate> _repository;

        public CreateCommandHandler(IRepository<HotelAggregate> repository)
        {
            _repository = repository;
        }

        public void Execute(CreateCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            if (_repository == null)
            {
                throw new InvalidOperationException("Repository is not initialized.");
            }
            var aggregate = new HotelAggregate(command.Id, command.CustomerName, command.Email, command.PhoneNo, command.RoomNo,command.CheckIn,command.CheckOut,command.IsCheckedIn);
            aggregate.Version = -1;
            _repository.Save(aggregate, aggregate.Version);
        }
    }
}
