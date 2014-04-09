using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    class CarPrivate : Car {
        public bool IsoFix {
            get;
            set;
        }
        public override int NoOfSeats{
            get {
                return _noOfSeats;
            }
            set {
                if(value > 1 && value < 8)
                    _noOfSeats = value;
                else
                    throw new ArgumentOutOfRangeException("Number of seats", value, "The number of seats is not valid for the vehicle type.");
            }
        }
    }
}
