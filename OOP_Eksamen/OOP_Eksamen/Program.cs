using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    class Program {
        static void Main(string[] args) {
            AuctionHouse bælumAH = new AuctionHouse();
            CarPrivate dla = new CarPrivate("AB11111", "Bil1");
            CarPrivate bla = new CarPrivate("AB22222", "Bil2");
            CarPrivate ala = new CarPrivate("AB33333", "Bil3");

            BusinessSeller johnny = new BusinessSeller();
            johnny.ZipCode = 5000;
            PrivateSeller BlackBetty = new PrivateSeller();
            BlackBetty.ZipCode = 1000;

            dla.Fuel = Vehicle.FuelType.Petrol;
            dla.KmPrLiter = 5;
            dla.Year = 1000;
            Console.WriteLine(dla.EnergyClass);

            bla.Fuel = Vehicle.FuelType.Petrol;
            bla.KmPrLiter = 10;
            bla.Year = 2005;
            Console.WriteLine(bla.EnergyClass);

            ala.Fuel = Vehicle.FuelType.Petrol;
            ala.KmPrLiter = 10;
            ala.Year = 2005;
            Console.WriteLine(ala.EnergyClass);

            bælumAH.SetSale(dla, BlackBetty, 1);
            bælumAH.SetSale(bla, johnny, 1);
            bælumAH.SetSale(ala, johnny, 1);

            Console.WriteLine("\n" + bælumAH.avrageEnergyClassType());

            Console.ReadLine();
        }
    }
}
