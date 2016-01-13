using System;
using NServiceBus;

public class ResponseHandler : IHandleMessages<Response>
{
    public void Handle(Response message)
    {
        var backup = Console.ForegroundColor;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Response received: {0}", message.MessageId);

        Console.ForegroundColor = backup;
    }
}