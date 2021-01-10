using DesafioOfx.Core.Messages;
using System;

namespace DesafioOfx.Core.DomainObjects
{
    public abstract class DomainEvent : Event
    {
        public DomainEvent(int agregateId)
        {
            AgregateId = agregateId;
        }

    }
}
