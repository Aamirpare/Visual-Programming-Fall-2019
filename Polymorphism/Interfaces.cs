using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.HumanResource1
{
    //interface IPayment
    //{
    //    int price = 0;
    //    void Receipt();
    //    void Pay(decimal ammount);
    //    void Transfer(decimal ammount);
    //}

    //public abstract class BasePayment
    //{
    //    protected  int price = 0;
    //    public abstract void Receipt();
    //    public abstract void Pay(decimal ammount);

    //    public abstract void Transfer(decimal ammount);
        
    //}

    //public class Student : BasePayment
    //{
    //    public override void Pay(decimal ammount)
    //    {
    //        this.price = 100;
    //        throw new NotImplementedException();
    //    }

    //    public override void Receipt()
    //    {
    //        throw new NotImplementedException();    
    //    }
    //    public override void Transfer(decimal ammount)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class OnemoreClas : BasePayment
    //{
    //    public override void Pay(decimal ammount)
    //    {
    //        throw new NotImplementedException();
    //        this.price = 3432;
    //    }

    //    public override void Receipt()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override void Transfer(decimal ammount)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}


    public class FacultyEmployee
    {
        public int EmployeeID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public decimal Salary()
        {
            return 0;
        }
    }

    public class AdminEmployee
    {
        public int EmployeeID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public decimal Salary()
        {
            return 0;
        }
    }

    public class ContractEmployee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int Hours { get; set; }
        public decimal Rate { get; set; }
        public decimal Salary()
        {
            return 0;
        }
    }
}
