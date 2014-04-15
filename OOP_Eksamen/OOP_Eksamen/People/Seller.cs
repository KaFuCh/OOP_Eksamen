using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    class Seller {
        protected int _zipCode;
        public int ZipCode {
            get {
                return _zipCode;
            }
            set {
                if(value > 999 && value < 9999)
                    _zipCode = value;
                else
                    throw new ArgumentOutOfRangeException("Zip code", value, "The zip code is not valid");
            }
        }
    }
}
