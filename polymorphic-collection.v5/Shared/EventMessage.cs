using System;
using System.Collections.Generic;

public class EventMessage : IMyEvent
{
    public Guid EventId { get; set; }
    public DateTime? Time { get; set; }
    public TimeSpan Duration { get; set; }

    public List<BaseItem> Items { get; set; }
}

public abstract class BaseItem
{

}

public class ItemA : BaseItem
{
    public int Myint { get; set; }

    public override string ToString()
    {
        return Myint.ToString();
    }
}

public class ItemB : BaseItem
{
    public DateTime Val { get; set; }

    public override string ToString()
    {
        return Val.ToString();
    }
}
