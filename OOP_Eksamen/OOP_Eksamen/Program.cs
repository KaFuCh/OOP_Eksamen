using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    class Program {
        static void Main(string[] args) {
            AuctionHouse bælumAH = new AuctionHouse();
            CarCommercial dla = new CarCommercial("AB12345", "John Deere");
            BusinessSeller johnny = new BusinessSeller();
            dla.Fuel = Vehicle.FuelType.Diesel;
            dla.Year = 2005;
            dla.MinPrice = 3;
            int auNo = bælumAH.SetSale(dla, johnny, dla.MinPrice);
            BusinessBuyer jessie = new BusinessBuyer();
            jessie.Balance = 3;
            bælumAH.RecieveBid(jessie, auNo, 2);
            bælumAH.RecieveBid(jessie, auNo, 3);
            Console.WriteLine("Johnny's balance: {0}, Jessie's balance: {1}", johnny.Balance, jessie.Balance);
            bælumAH.AcceptBid(johnny, jessie, auNo);
            Console.WriteLine("Johnny's balance: {0}, Jessie's balance: {1}", johnny.Balance, jessie.Balance);

            Console.ReadLine();
        }
    }
}
