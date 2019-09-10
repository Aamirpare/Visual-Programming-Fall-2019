namespace University.Pricipal.HR
{
    public class Employee
    {
        //int EmployeeID = 100;
        //string FullName = "Anonymous";
        //bool IsActive = true;

        public int EmployeeID { get; set; }
        //public string FullName { get; set; }
        //public bool IsActive { get; set; }

        string _fullName;
        bool _isActive;
        public string FullName{
            set{ this._fullName = "Dr. " + value; }
            get { return this._fullName; }
        }

        public bool IsActive
        {
            set { this._isActive = this.FullName.Length > 50 ? true : false; }
            get { return this._isActive; }
        }

        public Employee()
        {
            this.EmployeeID = 100;
            this.FullName = "Anonymous";
            this.IsActive = true;

            System.Console.WriteLine("Employee ID : " + this.EmployeeID);
            System.Console.WriteLine("Full Name : " + this.FullName);
            System.Console.WriteLine("Is Active : " + this.IsActive);
        }
        public Employee(string msg)
        {
            System.Console.WriteLine(msg);
        }

        public void DisplayEmployee()
        {

        }
    }
}