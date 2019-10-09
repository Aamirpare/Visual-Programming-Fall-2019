using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkCoding.DependencyInjections
{
    public interface IService
    {
        void Run();
    }

    public class SmsService : IService
    {
        public void Run()
        {
            Console.WriteLine("SMS Service is running....");
        }
    }

    public class MmsService : IService
    {
        public void Run()
        {
            Console.WriteLine("MMS Service is running....");
        }
    }

    public class Message
    {
        public IService Service { get; }
        public Message(IService service)
        {
            Service = service;
        }

    }

    public class InjectionDemo
    {
        public static void Main_DI(string[] args)
        {
            Message message = new Message(new MmsService());
            message.Service.Run();
            message = new Message(new SmsService());
            message.Service.Run();

            Console.ReadKey();
        }
    }

}
