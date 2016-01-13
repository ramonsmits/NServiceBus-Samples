using System;
using System.Threading;
using NServiceBus;

public class EventMessageHandler : IHandleMessages<EventMessage>
{
    public void Handle(EventMessage message)
    {
        Console.WriteLine("Subscriber 1 received EventMessage with Id {0}.", message.MessageId);
        Console.WriteLine("Message time: {0}.", message.Time);
        Console.WriteLine("Message duration: {0}.", message.Duration);
    }
}