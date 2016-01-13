using System;
using NServiceBus;

public interface IMyEvent : IEvent, IMyMessage
{
    DateTime? Time { get; set; }
    TimeSpan Duration { get; set; }
}