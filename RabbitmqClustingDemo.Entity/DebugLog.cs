using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSharing.Frameworks.RabbitMQ;

namespace RabbitmqClustingDemo.Entity
{
    [RabbitMQQueue("Log.Queue.DebugLog", ExchangeName = "Log.Exchange.DebugLog", IsProperties = true)]
    public class DebugLog
    {
        public int Id { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
