using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public class AuctionHouse {
        //private decimal _balance;
        public Dictionary<int, Vehicle> ForSale = new Dictionary<int, Vehicle>();

        public int SetSale(Vehicle v, Seller s, decimal minPrice) {
            return SetSale(v, s, minPrice, s.RecieveNotification);
        }

        public int SetSale(Vehicle v, Seller s, decimal minPrice, Action<Vehicle, decimal> notificationMethod) {
            v.MinPrice = minPrice;
            int AuctionNumber = v.RegNumber.GetHashCode();
            ForSale.Add(AuctionNumber, v);
            v.VehicleSeller = s;
            v.notify = notificationMethod;
            return AuctionNumber;
        }

        public bool RecieveBid(Buyer b, int auctionNo, decimal bid) {
            if(ForSale.ContainsKey(auctionNo) && b.reserveBalance(bid, auctionNo, this)) {
                if((!ForSale[auctionNo].Bids.Any() && ForSale[auctionNo].MinPrice <= bid) || (ForSale[auctionNo].MinPrice <= bid && ForSale[auctionNo].Bids.Max(x => x.Value) < bid)) {
                    ForSale[auctionNo].notify(ForSale[auctionNo], bid);
                }
                if(ForSale[auctionNo].Bids.ContainsKey(b.GetHashCode())) {
                    ForSale[auctionNo].Bids[b.GetHashCode()] = bid;
                } else {
                    ForSale[auctionNo].Bids.Add(b.GetHashCode(), bid);
                }
                return true;
            }
            return false;
        }

        public void AcceptBid(Seller s, Buyer b, int auctionNo) {
            int key = b.GetHashCode();
            b.Balance -= ForSale[auctionNo].Bids[key];
            b.ReservedBalance -= ForSale[auctionNo].Bids[key];
            s.Balance += ForSale[auctionNo].Bids[key];
            ForSale.Remove(auctionNo);
        }
    }
}
