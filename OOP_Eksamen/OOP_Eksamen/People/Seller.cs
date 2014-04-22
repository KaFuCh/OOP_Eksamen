using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public abstract class Seller {
        //FIELDS
        protected int _zipCode;
        //PROPERTIES
        public abstract decimal Balance {
            get;
            set;
        }
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

        //CONSTRUCTORS
        public Seller(int inputZipCode) {
            ZipCode = inputZipCode;
        }

        //METHODS
        public void RecieveNotification (Vehicle v, decimal bid) {
            Console.WriteLine("\nAn interesting bid has been placed on:\n{0}\nThe bid is: {1:C}", v, bid);
        }
    }
}
