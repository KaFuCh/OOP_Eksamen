using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    class Program {
        static void Main(string[] args) {
            CarCommercial dla = new CarCommercial("AB12345", "John Deere");
            dla.Fuel = Vehicle.FuelType.Diesel;
            dla.Year = 2005;
            dla.MinPrice = 300000000000;
            Console.WriteLine("{0}", dla);
            Console.ReadKey();
        }
    }
}
