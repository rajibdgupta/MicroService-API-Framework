using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZydusFrontline.Interface.MessageQueue
{
    public interface IMessagePublisher
    {
        public Task PublishToQueue<T>(T obj);
        public Task PublishToQueue(string raw);
        public Task PublishToTopic<T>(T obj);
    }
}
