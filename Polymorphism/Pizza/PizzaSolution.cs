using System;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;

namespace Polymorphism.Pizza
{
    public class Pizza
    {
        public string[] Toppings { get; set; }
    }
    public class PizzaSolution
    {
        public static void Main_PizzaSolution(string[] args)
        {
            Pizza[] pizaList = new Pizza[] {
              new Pizza{ Toppings =  new string []{ "chees" } },
              new Pizza{ Toppings =  new string []{ "cream" } },
              new Pizza{ Toppings =  new string []{ "chicken" } },
              new Pizza{ Toppings =  new string []{ "pasta" } },
            };
            using (WebClient w = new WebClient())
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var jsonData = w.DownloadString("http://files.olo.com/pizzas.json");
                System.IO.File.WriteAllText("D:/toppings.json", jsonData);

                var pizzas = js.Deserialize<Pizza[]>(System.IO.File.ReadAllText("D:/toppings.json"));


                foreach (var p in pizzas.Where(x => x.Toppings.Contains("pepperoni")))
                {
                    foreach (var t in p.Toppings)
                    {
                        Console.WriteLine(t);
                    }
                }

                //Console.WriteLine( jsonData);
            }

            Console.ReadKey();
        }
    }
}
