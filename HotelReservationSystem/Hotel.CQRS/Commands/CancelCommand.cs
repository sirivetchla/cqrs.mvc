using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.CQRS.Commands
{
    public class CancelCommand:Command
    {
        public CancelCommand(Guid id, int version) : base(id, version)
        {
        }
    }
}
