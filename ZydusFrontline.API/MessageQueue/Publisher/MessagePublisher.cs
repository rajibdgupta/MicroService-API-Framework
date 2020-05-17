using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZydusFrontline.Interface.MessageQueue;

namespace ZydusFrontline.API.MessageQueue.Publisher
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly IQueueClient _queueClient;
        private readonly ITopicClient _topicClient;
        public MessagePublisher(IQueueClient queueClient, ITopicClient topicClient)
        {
            _queueClient = queueClient;
            _topicClient = topicClient;
        }
        public Task PublishToQueue<T>(T obj)
        {
            var objAsText = JsonConvert.SerializeObject(obj);
            var message = new Message(Encoding.UTF8.GetBytes(objAsText));
            return _queueClient.SendAsync(message);
        }

        public Task PublishToQueue(string raw)
        {
            var message = new Message(Encoding.UTF8.GetBytes(raw));
            return _queueClient.SendAsync(message);
        }

        public Task PublishToTopic<T>(T obj)
        {
            var objAsText = JsonConvert.SerializeObject(obj);
            var message = new Message(Encoding.UTF8.GetBytes(objAsText));
            message.UserProperties["messageType"] = typeof(T).Name;
            return _topicClient.SendAsync(message);
        }
    }
}
