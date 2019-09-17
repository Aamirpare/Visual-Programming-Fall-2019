using System;

namespace Polymorphism.Events
{
    //public delegate void MessageHandler();
    public class MessageEventArgs : EventArgs
    {
        public int Size { get; set; }
    }

    public class Message
    {
        //public event MessageHandler BeforeSent;
        //public event MessageHandler AfterSent;
        
        public event EventHandler<MessageEventArgs> BeforeSent;
        public event EventHandler<MessageEventArgs> AfterSent;
        public string Content { get; set; }
        public void Send(MessageEventArgs args)
        {
            this.OnBeforeSend(args);
            Console.WriteLine($"Content: {Content}{Environment.NewLine}Size : {args.Size} ");
            this.OnAfterSent(args);
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
            Size = 90
        };

        public SimpleMessageService()
        {
            message.Content = "Simple Message service ....";
            message.AfterSent += Message_AfterSent;
            message.BeforeSent += Message_BeforeSent;
            message.Send(args);
        }

        public void Message_BeforeSent(object sender, EventArgs e)
        {
            MessageEventArgs args = e as MessageEventArgs;
            Console.WriteLine("Before sms sent event. {0}", args.Size );
        }

        public void Message_AfterSent(object sender, EventArgs e)
        {
            Console.WriteLine("After sms sent event.");
        }        
    }

    public class EmailService 
    {
        Message Message = new Message();
        MessageEventArgs args = new MessageEventArgs()
        {
            Size = 80
        };
        public EmailService()
        {
            this.Message.Content = "The task assigned to me was very difficult to manage but as alwasys i enjoy challengs, i completed it with lot of fun.";
            this.Message.AfterSent += OnAfterSent;
            this.Message.BeforeSent += OnBeforeSent;
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
}
