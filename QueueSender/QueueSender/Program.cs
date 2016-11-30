using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueSender
{
    class Program
    {
        static void Main(string[] args)
        {
            SendToQueue();
        }

        private static void SendToQueue()
        {
            Person per1 = new Person() { FirstName = "Vikram", LastName = "Chaudhary", Age = 33, Gender = "Male" };
            var qc = QueueClient.Create("logicappmessage", ReceiveMode.PeekLock);
            string personJson = JsonConvert.SerializeObject(per1);
            qc.Send(new BrokeredMessage(GenerateStreamFromString(personJson))
            {
                TimeToLive = TimeSpan.FromMinutes(30),
                Properties = { { "PersonData", "PersonData" } }

            });
        }

        public static Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
    }
}
