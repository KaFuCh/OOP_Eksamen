using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    class PrivateBuyer : Buyer, IPrivate {
        Private P = new Private();

        private decimal _reservedBalance;

        public decimal ReservedBalance {
            get {
                return _reservedBalance;
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
        public decimal Balance {
            get{
                return P.Balance;
            }
            set{
                P.Balance = value;
            }
        }
        public bool CheckCPR(string cpr){
            return P.CheckCPR(cpr);
        }

        public override bool reserveBalance(decimal bid) {
            if(_reservedBalance + bid <= Balance && _reservedBalance + bid >= 0) {
                _reservedBalance += bid;
                return true;
            } else {
                return false;
            }
        }
    }
}
