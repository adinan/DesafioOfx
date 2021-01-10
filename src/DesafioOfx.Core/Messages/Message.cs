using System;

namespace DesafioOfx.Core.Messages
{
    public abstract class Message
    {
        public string MassageType { get; set; }
        public int AgregateId { get; set; }

        public Message()
        {
            MassageType = GetType().Name;
        }
    }
}


