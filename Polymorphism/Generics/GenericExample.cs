using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Generics
{
    public interface Authorize
    {

    }
    public delegate void ChangeHumidityHandler<TKey, TValue>(TKey key, TValue val);
    public interface IEntity<T> 
    {
        bool Create(T entity);
        bool Retrieve();

        void Delete();
    }
    public class GenericExample<T> : IEntity<T>
    {
        T member;

        public bool Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Display(T val)
        {
            this.member = val;
            Console.WriteLine("Member : " + member);
        }

        public bool Retrieve()
        {
            throw new NotImplementedException();
        }
    }

    public class ExecuteDemo
    {
        public static void Main__sdfasd(string[] args)
        {
            GenericExample<int> g = new GenericExample<int>();
            g.Display(90);
        
            GenericExample<string> s = new GenericExample<string>();
            s.Display("Aamir");

            GenericExample<float> f = new GenericExample<float>();
            f.Display(9333.98f);
            Console.ReadKey();
        }
    }
}
