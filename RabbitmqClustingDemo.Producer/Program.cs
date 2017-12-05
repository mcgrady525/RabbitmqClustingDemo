using RabbitMQ.Client;
using System;
using System.Text;
using SSharing.Frameworks.Common.Extends;
using RabbitmqClustingDemo.Entity;
using SSharing.Frameworks.RabbitMQ;
using SSharing.Frameworks.Configurations;

namespace RabbitmqClustingDemo.Producer
{
    /// <summary>
    /// 消息发布
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("开始往集群中发布消息...");
            using (var rabbitmqProxy = new RabbitMQWrapper())
            {
                for (int i = 0; i < Int32.MaxValue; i++)
                {
                    try
                    {
                        var debugLog = new DebugLog
                        {
                            Id = i,
                            CreatedTime = DateTime.Now
                        };

                        rabbitmqProxy.Publish(debugLog);
                        Console.WriteLine(string.Format("{0} OK", i));

                        System.Threading.Thread.Sleep(1 * 1000);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
