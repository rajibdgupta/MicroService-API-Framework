using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZydusFrontline.API.MessageQueue.Subscriber
{
    public static class SubscriptionDetails
    {
        public static string ConnectionString = "Endpoint=sb://myservicebus-zah.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=S3TVYikL0EVjIGqhKdo11/GOTur4CKOuhBnfIbOThZ4=";
        public static string TopicName = "exampletopic";
        public static string CustomerSubscription = "customers";
        public static string OrderSubscription = "orders";
    }
}
