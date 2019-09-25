using System;

namespace Polymorphism.Events.Basic
{
    public delegate void MessageHandler();
    public class Message
    {
        public event MessageHandler BeforeSent;
        public event MessageHandler AfterSent;
        public string Content { get; set; }
        public void Send()
        {
            this.OnBeforeSend();
            Console.WriteLine($"Content: {Content}{Environment.NewLine}");
            this.OnAfterSent();
        }
        protected virtual void OnBeforeSend()
        {
            if (BeforeSent != null)
            {
                BeforeSent();
            }
        }

        protected virtual void OnAfterSent()
        {
            //if( AfterSent != null)
            //{
            //    AfterSent();
            //}
            AfterSent?.Invoke();
        }
        
    }

    public class SimpleMessageService
    {
        Message message = new Message();
        public SimpleMessageService()
        {
            message.AfterSent += Message_AfterSent;
            message.BeforeSent += Message_BeforeSent;
        }

        public void Send()
        {
            message.Content = "Simple Message service content has been sent";
            message.Send();
        }
        public void Message_BeforeSent()
        {
            Console.WriteLine("Before sms sent event.");
        }

        public void Message_AfterSent()
        {
            Console.WriteLine("After sms sent event.");
        }
    }


    public class EmailService
    {
        private Message Message = new Message();
        public EmailService()
        {
            this.Message.AfterSent += Message_AfterSent;
            this.Message.BeforeSent += Message_BeforeSent;
        }
        public void Send()
        {
            this.Message.Content = "The task assigned to me was very difficult to manage but as alwasys i enjoy challengs, i completed it with lot of fun.";
            this.Message.Send();
        }
        private void Message_AfterSent()
        {
            Console.WriteLine("After email event sent");
        }
        private void Message_BeforeSent()
        {
            Console.WriteLine("Before email sent event");
        }
    }

    public static class EventDemo
    {
        static void Main_events(string[] args)
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
