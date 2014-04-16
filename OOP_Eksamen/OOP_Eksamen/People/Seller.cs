using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public class Seller {
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

        public void RecieveNotification (Vehicle v, decimal bid) {
            Console.WriteLine("An interesting bid has been placed on {0}, the bid is: {1}", v, bid);
        }
    }
}
