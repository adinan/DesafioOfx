namespace DesafioOfx.Core.Messages
{
    public abstract class Message
    {
        public string MessageType { get; set; }
        public int AgregateId { get; set; }

        public Message()
        {
            MessageType = GetType().Name;
        }
    }
}


