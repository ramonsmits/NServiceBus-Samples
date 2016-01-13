using System;
using NServiceBus;

public interface IMyMessage : IMessage
{
    Guid MessageId { get; set; }
}