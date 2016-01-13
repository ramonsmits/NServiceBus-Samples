using System;
using System.Threading;
using NServiceBus;

public class EventMessageHandler : IHandleMessages<IMyEvent>
{
    private static Guid Subscriber1Namespace = GuidUtility.Create(new Guid("02596FD6-9B2F-4D6D-A551-AAFB8CBE33F1"), "Subscriber1");
    public IBus Bus { get; set; }

    public void Handle(IMyEvent message)
    {
        Console.WriteLine("Subscriber 2 received IEvent with Id {0}.", message.MessageId);
        Console.WriteLine("Message time: {0}.", message.Time);
        Console.WriteLine("Message duration: {0}.", message.Duration);

        Thread.Sleep(500);

        Bus.Reply(new Response
        {
            MessageId = GuidUtility.Create(Subscriber1Namespace, message.MessageId.ToString())
        });
    }
}