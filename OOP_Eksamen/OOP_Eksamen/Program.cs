using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    class Program {
        static void Main(string[] args) {
            BusinessSeller bla = new BusinessSeller();
            PrivateSeller pla = new PrivateSeller();
            CarPrivate dla = new CarPrivate();
            dla.RegNumber = "AB12345";
            dla.Fuel = Vehicle.FuelType.Petrol;
            dla.Name = "Audi RS4";
            dla.Year = 2005;
            dla.EngineSize = 4.2;
            
            bla.CVR = "12629885";
            pla.CPR = "0104931839";
            Console.WriteLine("CVR: {0}", bla.CVR);
            Console.WriteLine("CPR: {0}", pla.CPR);
            Console.WriteLine("{0}", dla);
            Console.ReadKey();
        }
    }
}
