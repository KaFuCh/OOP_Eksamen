using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public class AuctionHouse {
        private decimal _balance;
        Dictionary<int, Vehicle> ForSale = new Dictionary<int, Vehicle>();

        public int SetSale(Vehicle v, Seller s, decimal minPrice) {
            return SetSale(v, s, minPrice, s.RecieveNotification);
        }

        public int SetSale(Vehicle v, Seller s, decimal minPrice, Action<Vehicle> notificationMethod) {
            v.MinPrice = minPrice;
            int AuctionNumber = v.RegNumber.GetHashCode();
            ForSale.Add(AuctionNumber, v);
            v.VehicleSeller = s;
            return AuctionNumber;
        }

        public bool ReciveBid(Buyer b, int auctionNo, decimal bid) {
            if(ForSale.ContainsKey(auctionNo)) {
                ForSale[auctionNo].Bids.Add(b.GetHashCode(), bid);
                if(ForSale[auctionNo].Bids.Max(x => x.Value) < bid){
                    
                }
                return true;
            }
            return false;
        }

        public bool AcceptBid(Seller s, int auctionNo) {
            return false;
        }
    }
}
