using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    class Program {
        static void Main(string[] args) {
            if(true /*args.Any() && args[0] == "--test"*/) {
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
            int testRVKey = testAuctionHouse.SetSale(new RV("Ford Carado A241", "DK34587", 2005, Vehicle.LicenceType.B, Vehicle.FuelType.Diesel, 280000, RV.HeatingSystemType.Electric), sellers[1]);
            int testTruckKey = testAuctionHouse.SetSale(new Truck("Scania L80", "ÅF39847", 2001, Vehicle.LicenceType.CE, Vehicle.FuelType.Diesel, 500000), sellers[0]);

            Console.WriteLine("Test Cases:\n" +
                              "1: Trade example\n" +
                              "2: Search examples\n");
            char key;
            do
                key = Console.ReadKey().KeyChar;
            while(key != '1' && key != '2');
            switch(key) {
                case '1':

                break;
                case '2':
                Console.WriteLine("\nSearch examples:\n" +
                                  "1: String search example\n" +
                                  "2: Min seats and toilet search\n" +
                                  "3: Big licence type and maximal weight\n" +
                                  "4: Private cars; max km and max price and sorted\n" +
                                  "5: Zip code radius\n" +
                                  "6: Energyclass average\n");
                do
                    key = Console.ReadKey().KeyChar;
                while(key != '1' && key != '2' && key != '3' && key != '4' && key != '5' && key != '6');
                List<Vehicle> sortedList = new List<Vehicle>();
                switch(key) {
                    case '1':
                        Console.WriteLine("\nEnter string:");
                        string searchString = Console.ReadLine();
                        sortedList = testAuctionHouse.SearchString(searchString);
                        break;
                    case '2':
                        Console.WriteLine("\nEnter minimum seats:");
                        uint minSeats = Convert.ToUInt32(Console.ReadLine());
                        Console.WriteLine("Toilet? (Y/N)");
                        char hasToiletChar = Console.ReadKey().KeyChar;
                        bool hasToilet = false;

                        if(hasToiletChar == 'Y' || hasToiletChar == 'y')
                            hasToilet = true;
                        else
                            hasToilet = false;

                        sortedList = testAuctionHouse.SearchSeatsAndToilets(minSeats, hasToilet);
                        break;
                    case '3':
                        Console.WriteLine("\nEnter max weight:");
                        int maxWeight = Convert.ToInt32(Console.ReadLine());
                        sortedList = testAuctionHouse.SearchLicence(maxWeight);
                        break;
                    case '4':
                        Console.WriteLine("\nEnter max km");
                        int maxKm = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter max price");
                        decimal maxPrice = Convert.ToDecimal(Console.ReadLine());
                        sortedList = testAuctionHouse.SearchPrivateCar(maxKm, maxPrice);
                        break;
                    case '5':
                        Console.WriteLine("\nEnter zipcode");
                        int zipCode = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\nEnter range");
                        int range = Convert.ToInt32(Console.ReadLine());
                        sortedList = testAuctionHouse.SearchZipCode(range, zipCode);
                        break;
                    case '6':
                        Console.WriteLine("\nEnergy Class: " + testAuctionHouse.avrageEnergyClassType());
                        break;
                }
                foreach(Vehicle v in sortedList) {
                    Console.WriteLine(v);
                }
                break;
            }

            /*testAuctionHouse.RecieveBid(buyers[0], testBusKey, 120000);
            testAuctionHouse.AcceptBid(buyers[0], testBusKey);

            Console.WriteLine(testAuctionHouse.Balance);*/

            Console.ReadLine();
        }
    }
}
