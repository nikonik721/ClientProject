using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Text;

namespace PC.DL.Kafka
{
    public class KafkaAdmin
    {
        public KafkaAdmin()
        {
            var config = new AdminClientConfig()
            {
                BootstrapServers = "localhost:9092",

            };
        }
    }
}
