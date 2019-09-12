using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Registration
    {
        //public string RollNo;
        //public string FullName;
        //bool IsActive;
        private string _rollNo;
        public string RollNo {
            get
            {
                return _rollNo + "-BBS";
            }
            set
            {
                _rollNo = value + "-NDS";
            }
        }



        public string FullName { get; set; }

        public bool IsActive { get; set; }

        public Registration()
        {
            RollNo = "100";
            FullName = "NA";
            IsActive = true;
            Console.WriteLine("The registration object is created");
        }

        public Registration(string rn, string fn, bool active)
        {
            this.RollNo = rn;
            this.FullName = fn;
            this.IsActive = active;
        }


        public void ShowRegistration()
        {
            Console.WriteLine("Roll # {0}, \n Full Name : {1}", this.RollNo, this.FullName); ;
        }


        public bool IsStudentActive()
        {
            return this.IsActive;
        }


        public Registration Clone()
        {
            return this; 
        }
        
    }
}


namespace Teaching
{
    public class Registration
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public Registration()
        {
            Id = 90;
            FullName = "Anonymous";
        }
        public void Display()
        {
            Console.WriteLine("ID : " + Id);
            Console.WriteLine("Full Name : " + FullName);
        }
    }
}