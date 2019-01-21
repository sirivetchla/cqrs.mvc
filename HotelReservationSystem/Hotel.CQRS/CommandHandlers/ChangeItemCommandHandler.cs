using Hotel.CQRS.Commands;
using Hotel.CQRS.Domain;
using Hotel.CQRS.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.CQRS.CommandHandlers
{
 public class ChangeItemCommandHandler : ICommandHandler<ChangeCommand>
    {
        private readonly IRepository<HotelAggregate> _repository;

        public ChangeItemCommandHandler(IRepository<HotelAggregate> repository)
        {
            _repository = repository;
        }

        public void Execute(ChangeCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            if (_repository == null)
            {
                throw new InvalidOperationException("Repository is not initialized.");
            }

            var aggregate = _repository.GetById(command.Id);

            if (aggregate.IsCheckedIn != command.IsCheckedIn)
                aggregate.RoomChekIn(command.IsCheckedIn);           

            _repository.Save(aggregate, command.Version);
        }
    }
}
