using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSharing.Frameworks.Common.Extends;
using SSharing.Frameworks.Configurations;
using SSharing.Frameworks.RabbitMQ;

namespace RabbitmqClustingDemo.Common
{
    public static partial class RabbitMQHelper
    {
        public static RabbitMQConfig GetRabbitMQConfig()
        {
            var config = System.Configuration.ConfigurationManager.GetSection("rabbitMQ") as RabbitMQConfigurationSection;
            return new RabbitMQConfig
            {
                Host = config.HostName,
                Port = config.Port,
                VirtualHost = config.VHost,
                UserName = config.UserName,
                Password = config.Password
            };
        }


    }
}
