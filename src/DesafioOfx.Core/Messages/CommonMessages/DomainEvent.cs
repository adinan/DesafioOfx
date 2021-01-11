using MediatR;
using System;

namespace DesafioOfx.Core.Messages.CommonMessages
{
    public abstract class DomainEvent : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected DomainEvent(Guid aggregateId)
        { 
            Timestamp = DateTime.Now;
        }
    }
}
