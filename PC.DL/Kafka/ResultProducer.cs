using Confluent.Kafka;
using EqClient.DataLayer.Common;
using Microsoft.Extensions.Logging;
using PS.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PC.DL.Kafka
{
    public class ResultProducer : IResultProducer
    {
        private readonly ILogger<ResultProducer> _logger;
        private readonly IProducer<int, Mail> _producer;

        public ResultProducer(ILogger<ResultProducer> logger)
        {
            _logger = logger;

            var config = new ProducerConfig()
            {
                BootstrapServers = "localhost:9092"
            };

            _producer = new ProducerBuilder<int, Mail>(config)
                .SetValueSerializer(new MailSerializer<Mail>())
                .Build();


        }

        public async Task ProduceResultAsync(Mail envelopes)
        {

            var msg = new Message<int, Mail>()
            {
                Key = envelopes.Id,
                Value = envelopes
            };

            await _producer.ProduceAsync("results", msg);

        }
    }
}
