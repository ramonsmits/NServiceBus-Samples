﻿using Messages;
using NServiceBus;

namespace Server
{
    class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.Conventions().DefiningMessagesAs(t => t == typeof (CancelOrder));
        }
    }
}