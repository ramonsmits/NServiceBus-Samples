using System;
using System.Runtime.InteropServices;

public class SequentialUuid
{
    [DllImport("rpcrt4.dll", SetLastError = true)]
    static extern int UuidCreateSequential(out Guid guid);

    public static Guid NewGuid()
    {
        const int RPC_S_OK = 0;
        Guid g;
        int hr = UuidCreateSequential(out g);
        if (hr != RPC_S_OK) throw new ApplicationException("UuidCreateSequential failed: " + hr);
        return g;
    }
}