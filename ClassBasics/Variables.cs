using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBasics
{
    public class Variables
    {
        int index;
        bool IsExpired;

        public Variables(int index, bool expired)
        {
            this.index = index;
            this.IsExpired = expired;
        }


        public void Display()
        {
            Console.WriteLine($"Index : { this.index}, Expired : {this.IsExpired}");
        }
    }
}
