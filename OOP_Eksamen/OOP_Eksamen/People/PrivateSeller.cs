﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    class PrivateSeller : Seller, IPrivate {
        Private P = new Private(); //Simulated multiple inheritance
        //PROPERTIES
        public string CPR {
            get {
                return P.CPR;
            }
            set {
                P.CPR = value;
            }
        }
        public override decimal Balance {
            get {
                return P.Balance;
            }
            set {
                P.Balance = value;
            }
        }

        //CONSTRUCTORS
        public PrivateSeller(string inputCPR, int inputZipCode, decimal inputBalance) : base(inputZipCode) {
            CPR = inputCPR;
            Balance = inputBalance;
        }

        //METHODS
        public bool CheckCPR(string cpr) {
            return P.CheckCPR(cpr);
        }
    }
}
