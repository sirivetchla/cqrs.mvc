﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.CQRS.Events
{
    public interface IEvent
    {
        Guid Id { get; }
    }
}
