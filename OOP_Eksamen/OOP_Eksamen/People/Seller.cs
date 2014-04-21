using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public abstract class Seller {
        public abstract decimal Balance {
            get;
            set;
        }

        protected int _zipCode;
        public int ZipCode {
            get {
                return _zipCode;
            }
            set {
                if(value > 999 && value < 10000)
                    _zipCode = value;
                else
                    throw new ArgumentOutOfRangeException("Zip code", value, "The zip code is not valid");
            }
        }

        public Seller(int inputZipCode) {
            ZipCode = inputZipCode;
        }

        public void RecieveNotification (Vehicle v, decimal bid) {
            Console.WriteLine("\nAn interesting bid has been placed on:\n{0}\nThe bid is: {1:C}", v, bid);
        }
    }
}
