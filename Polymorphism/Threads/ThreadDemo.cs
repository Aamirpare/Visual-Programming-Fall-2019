using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Polymorphism.Threads
{
   
    public class Email
    {
        public string Body { get; set; }
        public string Address { get; set; }
        public bool Send(Func<string, string, bool> mail)
        {
            return mail(Body, Address);
        }

    }
    public static class ShowThreadsDemo
    {
        static readonly Func<int> Count = delegate () { return System.Diagnostics.Process.GetCurrentProcess().Threads.Count; };
        static readonly Func<ThreadStart, Thread> NewThread = (task) => { return new Thread(task); };
        public static void Print()
        {
            Console.WriteLine("Thread 1....");
            Console.ReadKey();
        }
        public static void Main_OldThreads(string[] args)
        {
            Console.WriteLine("Total Current running threads : " + Count());
            const int SIZE = 100;

            List<Thread> thread = new List<Thread>(SIZE);
            for (int i = 0; i < SIZE; i++)
            {
                var t = NewThread(Print);
                thread.Add(t);
                if ((i + 1) % 4 == 0) t.Start();
            }

            Console.WriteLine("Total Current running threads : " + Count());
            Console.ReadKey();
        }
    }
    public class ThreadsInCSharpDemo
    {
        public static void Print()
        {
            Console.WriteLine("Thread launched and start working....");
            Console.ReadKey();
        }

        public static void Print(object msg)
        {
            Console.WriteLine(msg);
            Console.ReadKey();
            Console.WriteLine("I am going to die.");
        }
        public static void CreateAndStartThreads()
        {
            int count = System.Diagnostics.Process.GetCurrentProcess().Threads.Count;
            Console.WriteLine("Total Inital Threads : " + count);

            //Creating a thread in c#

            //ThreadStart ts = new ThreadStart(Print);
            ParameterizedThreadStart pts = new ParameterizedThreadStart(Print);
            const int SIZE = 100;
            Thread[] threads = new Thread[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                threads[i] = new Thread(pts);
                //if ((i + 1) % 4 == 0)
                {
                    threads[i].Start($"Thread {i+1} has been launched....");
                }
            }

            foreach (var t in threads)
            {
                Console.WriteLine($"{ (t.IsAlive ? "Live" : "Died")}");
            }


            count = System.Diagnostics.Process.GetCurrentProcess().Threads.Count;
            Console.WriteLine("Total Inital Threads : " + count);

            Console.ReadKey();
        }

        public static Func<int> GetThreadCount = () => { return Process.GetCurrentProcess().Threads.Count;};
        public static int Count { get { return GetThreadCount(); } }

        public static void Main_threads_last(string[] args)
        {
            // CreateAndStartThreads();
            //var count  = GetThreadCount();
            //Console.WriteLine("The count : " + count);
            //Task task = new Task(() => { Console.WriteLine("Task Parallel thread is created"); Console.ReadKey(); });
            ////task.Start();
            //task = new Task(() => { Console.WriteLine("Task Parallel thread 3 is created"); Console.ReadKey(); });
            ////task.Start();
            //count = GetThreadCount();
            //Console.WriteLine("The count : " + count);

            InterrupThreads();
            Console.ReadKey();
        }
        public static void Main_oldExercise(string [] args)
        {
            Console.WriteLine("Total Inital Threads : " + Count);
            //CreateAndStartThreads();

            //Task task = new Task(() => { Console.WriteLine("The task has been launched...."); });
            //task.Start();
            //task = new Task(Print);
            //task.Start();

            Action action = Print; //() => { Console.WriteLine("the task to be launched"); };

            Task task = Task.Factory.StartNew(action);

            Task.Run(Print);

            Console.WriteLine("Total Inital Threads : " + Count);
            //InterrupThreads();
            Console.ReadKey();
        }
        public static void InterrupThreads()
        {
            // Interrupt a sleeping thread. 
            var sleepingThread = new Thread(SleepIndefinitely);
            sleepingThread.Name = "Sleeping";
            sleepingThread.Start();
            Thread.Sleep(2000);
            sleepingThread.Interrupt();

            Thread.Sleep(1000);

            sleepingThread = new Thread(SleepIndefinitely);
            sleepingThread.Name = "Sleeping2";
            sleepingThread.Start();
            Thread.Sleep(2000);
            sleepingThread.Abort();
        }
        private static void SleepIndefinitely()
        {
            Console.WriteLine("Thread '{0}' about to sleep indefinitely.",
                              Thread.CurrentThread.Name);
            try
            {
                Thread.Sleep(Timeout.Infinite);
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine("Thread '{0}' awoken.",
                                  Thread.CurrentThread.Name);
            }
            catch (ThreadAbortException)
            {
                Console.WriteLine("Thread '{0}' aborted.",
                                  Thread.CurrentThread.Name);
            }
            finally
            {
                Console.WriteLine("Thread '{0}' executing finally block.",
                                  Thread.CurrentThread.Name);
            }
            Console.WriteLine("Thread '{0} finishing normal execution.",
                              Thread.CurrentThread.Name);
            Console.WriteLine();
        }
    }


    //public class ExecuteDemo
    //{
    //    static readonly Func<int> Count = () => { return System.Diagnostics.Process.GetCurrentProcess().Threads.Count; };

    //    readonly static Func<Thread> NewThread = () => { return new Thread(Print); };
    //    public static void Print(object s)
    //    {
    //        Console.WriteLine(s.ToString());
    //        Console.ReadKey();
    //    }
    //    public static void PrintY()
    //    {
    //        Console.WriteLine("Hello world");
    //        Console.ReadKey();
    //    }
    //    public static void Run(Func<Thread> thread)
    //    {
    //        var  th = thread();
    //        th.Start("Its really a fantastic experience...");
    //    }
    //    public static void Main(string[] args)
    //    {
    //        Console.WriteLine("Thread Count : {0}", Count());


    //        bool Message(string s, string m) { return true; }

    //        Email mail = new Email();
    //        mail.Send(Message);

    //        ParameterizedThreadStart pts = new ParameterizedThreadStart(Print);

    //        ThreadStart ts = new ThreadStart(PrintY);
    //        Thread[] threads = new Thread[100];
    //        for (int i = 0; i < 5; i++)
    //        {
    //           threads[i] = new Thread(pts);
    //           threads[i].Start("Hello I am a thread");
    //        }

    //        var thread = NewThread();
    //        thread.Start("you can not eat me like a piece of cacke");

    //        Run(NewThread);

    //        Console.WriteLine("Thread Count : {0}", Count());

    //        Console.ReadKey();
    //    }
    //}

}
