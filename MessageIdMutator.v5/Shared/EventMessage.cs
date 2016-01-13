using System;

public class EventMessage : IMyEvent
{
    public Guid MessageId { get; set; }
    public DateTime? Time { get; set; }
    public TimeSpan Duration { get; set; }
}