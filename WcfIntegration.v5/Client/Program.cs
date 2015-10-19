using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Messages;

namespace Client
{
    class Program
    {
        private static void Main()
        {
            Console.WriteLine("This will send requests to the CancelOrder WCF service");
            Console.WriteLine("Press 'Enter' to send a message.To exit, Ctrl + C");

            var orderId = 1;

            while (Console.ReadLine() != null)
            {
                var client = new CancelOrderSvc.WcfServiceOf_CancelOrder_ErrorCodesClient();
                try
                {
                    var message = new CancelOrder
                    {
                        OrderId = orderId++
                    };

                    Console.WriteLine("Sending message with OrderId {0}.", message.OrderId);

                    client.Process(message);

                    var returnCode = client.Process(message);

                    Console.WriteLine("Error code returned: " + returnCode);

                    client.Close();
                }
                catch
                {
                    client.Abort();
                }
            }
        }
    }
}