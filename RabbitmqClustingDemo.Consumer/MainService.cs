using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSharing.Frameworks.RabbitMQ;
using RabbitmqClustingDemo.Common;
using RabbitmqClustingDemo.Entity;

namespace RabbitmqClustingDemo.Consumer
{
    public class MainService
    {
        private RabbitMQWrapper rabbitmqProxy;
        public MainService()
        {
            //rabbitmq初始化
            var rabbitmqConfig = RabbitMQHelper.GetRabbitMQConfig();
            rabbitmqProxy = new RabbitMQWrapper(rabbitmqConfig);
        }

        public bool Start()
        {
            Console.WriteLine("开始从集群中消费消息...");
            rabbitmqProxy.Subscribe<DebugLog>(item=> 
            {
                Console.WriteLine(string.Format("Id:{0},CreatedTime:{1}", item.Id, item.CreatedTime));
                System.Threading.Thread.Sleep(2 * 1000);
            });

            return true;
        }

        public bool Stop()
        {
            rabbitmqProxy.Dispose();
            return true;
        }
    }
}
