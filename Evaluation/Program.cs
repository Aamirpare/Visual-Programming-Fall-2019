using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evaluation.Database;

namespace Examination
{
    class Program
    {
        static void Main(string[] args)
        {
            var evaluation = new Evaluation.Database.Evaluation()
            {
                FullName = "Aamir Ahmed",
                Marks = 54,
            };

            var moreStudents = new List<Evaluation.Database.Evaluation>()
            {
                new Evaluation.Database.Evaluation()
                {
                    FullName = "Anil Ahmed",
                    Marks = 55,
                },
                new Evaluation.Database.Evaluation()
                {
                    FullName = "Sara Khan",
                    Marks = 58,
                },

            };

            //Create Operation

            var context = new ExaminationDBEntities();
            //context.Evaluations.Add(evaluation);

            //context.Evaluations.AddRange(moreStudents);

            var updated = context.Evaluations.Find(2);

            //updated.Marks = 78;

            //context.Evaluations.Remove(updated);

            //if (context.SaveChanges() > 0)
            //{
            //    Console.WriteLine("The evaluation is saved");
            //}
            var all = from e in context.Evaluations
                      select e;
            foreach (var o in all)
            {
                Console.WriteLine($"ID : {o.StudentID}");
                Console.WriteLine($"Full Name : {o.FullName}");
                Console.WriteLine($"Marks : {o.Marks}");
            }


            Console.ReadKey();
        }
    }
}
