using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public class BusinessBuyer : Buyer, IBusiness {
        Business B = new Business(); //Simulated multiple inheritance

        //PROPERTIES
        private decimal _reservedBalance;

        public override decimal ReservedBalance {
            get {
                return _reservedBalance;
            }
            set {
                _reservedBalance = value;
            }
        }
        
        public string CVR {
            get {
                return B.CVR;
            }
            set {
                B.CVR = value;
            }
        }
        public override decimal Balance {
            get {
                return B.Balance;
            }
            set {
                B.Balance = value;
            }
        }
        public decimal Credit {
            get {
                return B.Credit;
            }
            set {
                B.Credit = value;
            }
        }
        //METHODS
        public bool CheckCVR(string s) {
            return B.CheckCVR(s);
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
