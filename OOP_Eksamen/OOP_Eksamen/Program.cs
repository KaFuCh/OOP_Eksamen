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

            int testBusKey = testAuctionHouse.SetSale(new Bus("AB87232", "Mercedes Benz Travego"), sellers[0], 120000);
            int testCarPrivateKey = testAuctionHouse.SetSale(new CarPrivate("SD82738", "Audi A2"), sellers[1], 32000);
            int testCarCommercial = testAuctionHouse.SetSale(new CarCommercial("HK65434", "Mercedes Sprinter"), sellers[0], 25000);
            int testRVKey = testAuctionHouse.SetSale(new RV("DK34587", "Carado A241"), sellers[1], 280000);
            int testTruckKey = testAuctionHouse.SetSale(new Truck("HF39847", "Scania L80"), sellers[0], 500000);

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
