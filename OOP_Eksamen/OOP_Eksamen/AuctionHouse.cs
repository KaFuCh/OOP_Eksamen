using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public class AuctionHouse {
        private decimal _balance;
        public Dictionary<int, Vehicle> ForSale = new Dictionary<int, Vehicle>();

        public decimal Balance {
            get {
                return _balance;
            }
        }
        //A function to make the next function take the standard notification method is nothing else is specified
        public int SetSale(Vehicle v, Seller s) {
            return SetSale(v, s, s.RecieveNotification);
        }
        //A function to set a car for sale
        public int SetSale(Vehicle v, Seller s, Action<Vehicle, decimal> notificationMethod) {
            int AuctionNumber = v.RegNumber.GetHashCode();
            ForSale.Add(AuctionNumber, v);
            v.VehicleSeller = s;
            v.notify = notificationMethod;
            return AuctionNumber;
        }

        public bool RecieveBid(Buyer b, int auctionNo, decimal bid) {
            //If the list contains the car and the balance can be reserved
            if(ForSale.ContainsKey(auctionNo) && b.reserveBalance(bid, auctionNo, this)) {
                //If the car does not have any bids and the bid is higher then the minimum price or if there are bids and the new bid is higher
                if((!ForSale[auctionNo].Bids.Any() && ForSale[auctionNo].MinPrice <= bid) 
                    || (ForSale[auctionNo].MinPrice <= bid && ForSale[auctionNo].Bids.Max(x => x.Value) < bid)) {
                    ForSale[auctionNo].notify(ForSale[auctionNo], bid);
                }
                //If the bids already contains the buyer the bid is changed else the buyer and bid is added
                if(ForSale[auctionNo].Bids.ContainsKey(b.GetHashCode())) {
                    ForSale[auctionNo].Bids[b.GetHashCode()] = bid;
                } else {
                    ForSale[auctionNo].Bids.Add(b.GetHashCode(), bid);
                    ForSale[auctionNo].Biders.Add(b);
                }
                return true;
            }
            return false;
        }

        public bool AcceptBid(Buyer inputBuyer, int auctionNo) {
            if(ForSale.ContainsKey(auctionNo)) {
                int key = inputBuyer.GetHashCode();
                int fee = 0;
                //The choosen bidders balance is redeced and all the bidders reserved balance is decresed
                inputBuyer.Balance -= ForSale[auctionNo].Bids[key];
                foreach(Buyer b in ForSale[auctionNo].Biders) {
                    b.ReservedBalance -= ForSale[auctionNo].Bids[b.GetHashCode()];
                }
                
                if(ForSale[auctionNo].Bids[key] < 10000)
                    fee = 1900;
                else if(ForSale[auctionNo].Bids[key] < 50000)
                    fee = 2250;
                else if(ForSale[auctionNo].Bids[key] < 100000)
                    fee = 2550;
                else if(ForSale[auctionNo].Bids[key] < 150000)
                    fee = 2850;
                else if(ForSale[auctionNo].Bids[key] < 200000)
                    fee = 3400;
                else if(ForSale[auctionNo].Bids[key] < 300000)
                    fee = 3700;
                else
                    fee = 4400;
                
                _balance += fee;
                ForSale[auctionNo].VehicleSeller.Balance += ForSale[auctionNo].Bids[key] - fee;
                ForSale.Remove(auctionNo);
                return true;
            }
            return false;
        }

        public List<Vehicle> SearchString(string searchKey) {
            return ForSale.Values.Where(x => x.Name.Contains(searchKey)).ToList();
        }

        public List<Vehicle> SearchSeatsAndToilets(uint minSeats, bool hasToilet) {
            List<Vehicle> returnList = ForSale.Values.OfType<RV>().Where(x => x.Toilet == hasToilet && x.NoOfSeats >= minSeats).ToList<Vehicle>();
            returnList.AddRange(ForSale.Values.OfType<Bus>().Where(x => x.Toilet == hasToilet && x.NoOfSeats >= minSeats).ToList<Vehicle>());
            return returnList;
        }

        public List<Vehicle> SearchLicence(int maxWeight) {
            List<Vehicle> returnList = ForSale.Values.OfType<Truck>().Where(x => x.Weight <= maxWeight).ToList<Vehicle>();
            returnList.AddRange(ForSale.Values.OfType<Bus>().Where(x => x.Weight <= maxWeight).ToList<Vehicle>());
            return returnList;
        }

        public List<Vehicle> SearchPrivateCar(int maxKm, decimal maxPrice) {
            return ForSale.Values.OfType<CarPrivate>().Where(x => x.MinPrice <= maxPrice && x.Km <= maxKm).OrderBy(x => x.Km).ToList<Vehicle>();
        }

        public List<Vehicle> SearchZipCode(int zipCodeRange, int initZipCode) {
            return ForSale.Values.Where(x => x.VehicleSeller.ZipCode <= initZipCode + initZipCode && x.VehicleSeller.ZipCode >= initZipCode - zipCodeRange).ToList();
        }

        public Vehicle.EnergyClassType averageEnergyClassType() {
            return (Vehicle.EnergyClassType)Math.Round(ForSale.Values.Average(x => (int)x.EnergyClass));
        }
    }
}
