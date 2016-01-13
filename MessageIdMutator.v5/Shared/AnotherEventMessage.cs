using System;

public class AnotherEventMessage : IMyEvent
{
    public Guid MessageId { get; set; }
    public DateTime? Time { get; set; }
    public TimeSpan Duration { get; set; }
}