using System;
using NServiceBus;
using NServiceBus.Logging;

static class Program
{

    static void Main()
    {
        LogManager.Use<DefaultFactory>().Level(LogLevel.Info);
        BusConfiguration busConfiguration = new BusConfiguration();
        busConfiguration.EndpointName("Samples.PubSub.MyPublisher");
        busConfiguration.UseSerialization<JsonSerializer>();
        busConfiguration.UsePersistence<InMemoryPersistence>();
        busConfiguration.EnableInstallers();
        busConfiguration.RegisterComponents(components =>
        {
            components.ConfigureComponent<MessageIdFromMessageMutator>(DependencyLifecycle.InstancePerCall);
        });
        using (IBus bus = Bus.Create(busConfiguration).Start())
        {
            Start(bus);
        }
    }

    static void Start(IBus bus)
    {
        Console.WriteLine("Press '1' to publish IEvent");
        Console.WriteLine("Press '2' to publish EventMessage");
        Console.WriteLine("Press '3' to publish AnotherEventMessage");
        Console.WriteLine("Press 'Enter' to publish a message.To exit, Ctrl + C");

        var ns = SequentialUuid.NewGuid();

        #region PublishLoop
        while (true)
        {
            var now = DateTime.UtcNow;

            ConsoleKeyInfo key = Console.ReadKey();

            // Generates a id every second
            var eventId = GuidUtility.Create(ns, now.ToString("s"));
            // var eventId = SequentialUuid.NewGuid();


            switch (key.Key)
            {
                case ConsoleKey.D1:
                    bus.Publish<IMyEvent>(m =>
                    {
                        m.MessageId = eventId;
                        m.Time = now.Second > 30 ? (DateTime?)now : null;
                        m.Duration = TimeSpan.FromSeconds(99999D);
                    });
                    Console.WriteLine("Published IMyEvent with Id {0}.", eventId);
                    continue;
                case ConsoleKey.D2:
                    EventMessage eventMessage = new EventMessage
                    {
                        MessageId = eventId,
                        Time = now.Second > 30 ? (DateTime?)now : null,
                        Duration = TimeSpan.FromSeconds(99999D)
                    };
                    bus.Publish(eventMessage);
                    Console.WriteLine("Published EventMessage with Id {0}.", eventId);
                    continue;
                case ConsoleKey.D3:
                    AnotherEventMessage anotherEventMessage = new AnotherEventMessage
                    {
                        MessageId = eventId,
                        Time = now.Second > 30 ? (DateTime?)now : null,
                        Duration = TimeSpan.FromSeconds(99999D)
                    };
                    bus.Publish(anotherEventMessage);
                    Console.WriteLine("Published AnotherEventMessage with Id {0}.", eventId);
                    continue;
                default:
                    return;
            }
        }
        #endregion
    }
}