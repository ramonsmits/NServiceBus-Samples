using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Linq;
using System.Threading.Tasks;
using Messages;

namespace Client
{
    class Program
    {
        private static void Main()
        {
            Console.WriteLine("This will send requests to the CancelOrder WCF service");
            Console.WriteLine("Press 'Enter' to send a message.To exit, Ctrl + C");


            while (Console.ReadLine() != null)
            {
                Call();
                var start = Stopwatch.StartNew();
                Parallel.For(0, 100, i =>
                {
                    Call();
                });

                Console.WriteLine("Duration: {0}ms", start.ElapsedMilliseconds);
            }
        }

        private static int orderId;

        private static void Call()
        {
            using (var client = new CancelOrderSvc.WcfServiceOf_CancelOrder_ErrorCodesClient())
            {
                var message = new CancelOrder
                {
                    OrderId = System.Threading.Interlocked.Increment(ref orderId)
                };

                Console.WriteLine("Sending message with OrderId {0}.", message.OrderId);

                client.Process(message);

                var returnCode = client.Process(message);

                Console.WriteLine("Error code returned: " + returnCode);
            }
        }
    }
}