using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    class PrivateBuyer : Buyer, IPrivate {
        Private P = new Private();
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
    }
}
