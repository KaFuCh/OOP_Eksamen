using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    class Program {
        static void Main(string[] args) {
            if(args.Any() && args[0] == "--test") {
                testExample();
            }
        }

        public static void testExample() {
            AuctionHouse testAuctionHouse = new AuctionHouse();
            List<Seller> sellers = new List<Seller> {new BusinessSeller("12629885", 8300, 1000000, 500000), new PrivateSeller("0104931839", 9000, 100000)};
            List<Buyer> buyers = new List<Buyer>{new BusinessBuyer("48570658", 200000, 200000), new PrivateBuyer("0606941137", 40000)};

            int testBusKey = testAuctionHouse.SetSale(new Bus("Mercedes Benz Travego", "AB87232", 2005, Vehicle.LicenceType.D, Vehicle.FuelType.Diesel, 120000), sellers[0]);
            int testCarPrivateKey = testAuctionHouse.SetSale(new CarPrivate("Audi A2", "SD82738", 1996, Vehicle.LicenceType.B, Vehicle.FuelType.Petrol, 32000), sellers[1]);
            int testCarCommercial = testAuctionHouse.SetSale(new CarCommercial("Mercedes Benz Sprinter", "HK65434", 2001, Vehicle.LicenceType.BE, Vehicle.FuelType.Diesel, 25000), sellers[0]);
            int testRVKey = testAuctionHouse.SetSale(new RV("Ford Carado A241", "DK34587", 2005, Vehicle.LicenceType.B, Vehicle.FuelType.Diesel, 280000), sellers[1]);
            int testTruckKey = testAuctionHouse.SetSale(new Truck("Scania L80", "ÅF39847", 2001, Vehicle.LicenceType.CE, Vehicle.FuelType.Diesel, 500000), sellers[0]);

            foreach(Vehicle v in testAuctionHouse.SearchString("Mercedes")) {
                Console.WriteLine(v);
            }

            foreach(Vehicle v in testAuctionHouse.SearchLicence(1)) {
                Console.WriteLine(v);
            }

            foreach(Vehicle v in testAuctionHouse.SearchPrivateCar(0, 32000)) {
                Console.WriteLine(v);
            }

            testAuctionHouse.RecieveBid(buyers[0], testBusKey, 120000);
            testAuctionHouse.AcceptBid(buyers[0], testBusKey);

            Console.WriteLine(testAuctionHouse.Balance);

            Console.ReadLine();
        }
    }
}
