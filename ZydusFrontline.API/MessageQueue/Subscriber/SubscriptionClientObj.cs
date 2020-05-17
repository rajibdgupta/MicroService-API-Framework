using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZydusFrontline.API.MessageQueue.Subscriber
{
    public class SubscriptionClientObj
    {

        public ISubscriptionClient GetSubscriptionClient(string subscriptionName)
        {
            if (subscriptionName == SubscriptionDetails.OrderSubscription)
            {
                return new SubscriptionClient(SubscriptionDetails.ConnectionString, SubscriptionDetails.TopicName, SubscriptionDetails.OrderSubscription);
            }
            else if (subscriptionName == SubscriptionDetails.CustomerSubscription)
            {
                return new SubscriptionClient(SubscriptionDetails.ConnectionString, SubscriptionDetails.TopicName, SubscriptionDetails.CustomerSubscription);
            }
            return null;
        }
    }
}
