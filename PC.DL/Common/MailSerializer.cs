using Confluent.Kafka;
using MessagePack;

namespace EqClient.DataLayer.Common
{
    public class MailSerializer<T> : ISerializer<T>
    {
        public byte[] Serialize(T data, SerializationContext context)
        {
            return MessagePackSerializer.Serialize<T>(data);
        }
    }
}
