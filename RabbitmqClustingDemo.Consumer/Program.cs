using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using SSharing.Frameworks.Common.Extends;
using RabbitmqClustingDemo.Entity;
using SSharing.Frameworks.Configurations;
using SSharing.Frameworks.RabbitMQ;
using Topshelf;

namespace RabbitmqClustingDemo.Consumer
{
    /// <summary>
    /// 消费消息
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(config =>
            {
                config.SetServiceName("RabbitmqClustingDemoService");

                config.Service<MainService>(ser =>
                {
                    ser.ConstructUsing(name => new MainService());
                    ser.WhenStarted((service, control) => service.Start());
                    ser.WhenStopped((service, control) => service.Stop());
                });
            });
        }
    }
}
