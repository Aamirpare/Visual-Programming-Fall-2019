using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Delegates
{
    public class Options
    {
        public int MailPort { get; set; }
        public string HostName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool AutoReply { get; set; }
    }

    public class Configurations
    {
        private Options Options{set; get;}
        public Configurations(Func<Options, Options> options)
        {
            Options = options(new Options());
        }

        public Configurations(Options options)
        {
            Options = new Options();
        }
        public void Display()
        {
            Console.WriteLine($"Host Name : {Options.HostName}");
            Console.WriteLine($"Mail Port : {Options.MailPort}");
            Console.WriteLine($"User Name : {Options.UserName}");
            Console.WriteLine($"Password  : {Options.Password}");
        }
    }
    public class ExecuteDemo
    {
        public static void Main_lamdaExpression(string[] args)
        {
            var c = new Configurations( 
                (o) => 
                {
                    o.HostName = "Smtp";
                    o.Password = "sdfjs";
                    o.UserName = "Aamir Pare";
                    o.MailPort = 900;
                    return o;
                });
            c.Display();
            
            Console.ReadKey();
        }
    }
}
