using System;
using NServiceBus;
using NServiceBus.MessageMutator;

public class MessageIdFromMessageMutator : IMutateOutgoingMessages
{
    readonly IBus bus;

    public MessageIdFromMessageMutator(IBus bus)
    {
        this.bus = bus;
    }

    public object MutateOutgoing(object message)
    {
        var m = message as IMyMessage;
        if (m != null)
        {
            bus.SetMessageHeader(message, "NServiceBus.MessageId", m.MessageId.ToString());
            Console.WriteLine("Override message id: {0}", m.MessageId);
        }

        return message;
    }
}