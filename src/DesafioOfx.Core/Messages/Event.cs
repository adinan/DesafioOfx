using MediatR;
using System;

namespace DesafioOfx.Core.Messages
{
    public abstract class Event : Message, INotification
    {
        public DateTime TimeStamp { get; set; }

        protected Event()
        {
            TimeStamp = DateTime.Now;
        }

    }
}


