﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public class BusinessSeller : Seller, IBusiness {
        Business B = new Business(); //simulated multiple inheritance
        //PROPERTIES
        public string CVR{
            get{
                return B.CVR;
            }
            set{
                B.CVR = value;
            }
        }
        public override decimal Balance{
            get{
                return B.Balance;
            }
            set{
                B.Balance = value;
            }
        }
        public decimal Credit{
            get{
                return B.Credit;
            }
            set{
                B.Credit = value;
            }
        }

        //CONSTRUCTOR
        public BusinessSeller(string inputCVR, int inputZipCode, decimal inputBalance, decimal inputCredit) : base(inputZipCode) {
            CVR = inputCVR;
            ZipCode = inputZipCode;
            Balance = inputBalance;
        }

        //METHODS
        public bool CheckCVR(string s) { 
            return B.CheckCVR(s);
        }
    }
}
