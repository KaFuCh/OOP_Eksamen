using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public class BusinessBuyer : Buyer, IBusiness {
        Business B = new Business(); //Simulated multiple inheritance
        //PROPERTIES
        public string CVR {
            get {
                return B.CVR;
            }
            set {
                B.CVR = value;
            }
        }
        public decimal Balance {
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
    }
}
