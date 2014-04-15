using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public class AuctionHouse {
        private decimal _balance;

        public int SetSale(Vehicle v, Seller s, decimal minPrice) {
            return 0;
        }
        public int SetSale(Vehicle v, Seller s, decimal minPrice, Func<Seller> notificationMethod) {
            return 0;
        }

        public bool ReciveBid(Buyer b, int auctionNo, decimal bid) {
            return false;
        }

        public bool AcceptBid(Seller s, int auctionNo) {
            return false;
        }
    }
}
