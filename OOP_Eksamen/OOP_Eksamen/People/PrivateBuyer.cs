using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    class PrivateBuyer : Buyer, IPrivate {
        Private P = new Private();

        private decimal _reservedBalance;

        public override decimal ReservedBalance {
            get {
                return _reservedBalance;
            }
            set {
                _reservedBalance = value;
            }
        }

        public string CPR {
            get{
                return P.CPR;
            }
            set{
                P.CPR = value;
            }
        }
        public override decimal Balance {
            get{
                return P.Balance;
            }
            set{
                P.Balance = value;
            }
        }
        public PrivateBuyer(string inputCPR, decimal inputBalance) : base(inputBalance) {
            CPR = inputCPR;
        }

        public bool CheckCPR(string cpr){
            return P.CheckCPR(cpr);
        }

        public override bool reserveBalance(decimal bid, int auctionNo, AuctionHouse AH) {
            int key = base.GetHashCode();
            if(AH.ForSale[auctionNo].Bids.ContainsKey(key)) { //Has the buyer already bid on the vehicle?
                if(bid > AH.ForSale[auctionNo].Bids[key] && bid + _reservedBalance - AH.ForSale[auctionNo].Bids[key] <= Balance) {
                    _reservedBalance += bid - AH.ForSale[auctionNo].Bids[key];
                    return true;
                }
                else
                    return false;
            }
            else {
                if(_reservedBalance + bid <= Balance && _reservedBalance + bid >= 0) {
                    _reservedBalance += bid;
                    return true;
                }
                else
                    return false;
            }
        }
    }
}
