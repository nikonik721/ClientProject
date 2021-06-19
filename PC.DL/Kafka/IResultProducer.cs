using PS.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PC.DL.Kafka
{
    public interface IResultProducer
    {
        Task ProduceResultAsync(Mail envelopes);
    }
}
