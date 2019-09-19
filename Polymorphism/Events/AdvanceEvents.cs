using System;

namespace Polymorphism.Events.Advance
{
    public delegate void MessageHandler();
    public class MessageEventArgs : EventArgs
    {
        public int Size { get; set; }
        public int BandWidth { get; set; }
    }

    public class Message
    {
        //public event MessageHandler BeforeSent;
        //public event MessageHandler AfterSent;

        public event EventHandler<MessageEventArgs> BeforeSent;
        public event EventHandler<MessageEventArgs> AfterSent;
        public string Content { get; set; }
        public void Send(MessageEventArgs e)
        {
            this.OnBeforeSend(e);
            Console.WriteLine($"Content: {Content}{Environment.NewLine} Size : {e.Size}");
            this.OnAfterSent(e);
        }
        protected virtual void OnBeforeSend(MessageEventArgs e)
        {
            BeforeSent?.Invoke(this, e);
        }

        protected virtual void OnAfterSent(MessageEventArgs e)
        {
            AfterSent?.Invoke(this, e);
        }
        
    }

    public class SimpleMessageService
    {

        Message message = new Message();
        MessageEventArgs args = new MessageEventArgs
        {
            Size = 90,
            BandWidth = 1000
        };

        public SimpleMessageService()
        {
            message.AfterSent += Message_AfterSent;
            message.BeforeSent += Message_BeforeSent;
        }


        public void Send()
        {
            message.Content = "This is a very simple message, required to send immidiately";
            message.Send(args);
        }
        public void Message_BeforeSent(object sender, EventArgs e)
        {
            MessageEventArgs args = e as MessageEventArgs;
            Console.WriteLine("Before sms sent event. {0}", args.Size);
        }

        public void Message_AfterSent(object sender, EventArgs e)
        {
            Console.WriteLine("After sms sent event.");
        }
    }

    public class EmailService
    {
        private Message Message = new Message();
        MessageEventArgs args = new MessageEventArgs()
        {
            Size = 80
        };
        public EmailService()
        {
            this.Message.AfterSent += OnAfterSent;
            this.Message.BeforeSent += OnBeforeSent;
        }
        public void Send()
        {
            this.Message.Content = "The task assigned to me was very difficult to manage but as alwasys i enjoy challengs,\n i completed it with a lot of fun.";
            this.Message.Send(args);
        }

        private void OnAfterSent(object sender, EventArgs e)
        {
            Console.WriteLine("After email event sent");
        }
        private void OnBeforeSent(object sender, EventArgs e)
        {
            Console.WriteLine("Before email sent event");
        }
    }

    public static class AdvanceEventDemo
    {
        static void Main(string[] args)
        {
            SimpleMessageService sm = new SimpleMessageService();
            sm.Send();
            Console.WriteLine("");

            EmailService es = new EmailService();
            es.Send();
            Console.ReadKey();
        }
    }
}
