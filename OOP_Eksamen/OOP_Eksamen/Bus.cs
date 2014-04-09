using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public class Bus : Vehicle {
        public uint NoOfSeats {
            get;
            set;
        }
        public uint NoOfSleepSpots {
            get;
            set;
        }
        public uint Height {
            get;
            set;
        }
        public uint Weight {
            get;
            set;
        }
        public uint Length {
            get;
            set;
        }
        public bool Toilet {
            get;
            set;
        }
        public override LicenceType Licence {
            get {
                return _licence;
            }
            set {
                if(value == LicenceType.DE || (value == LicenceType.D && !_towBar))
                    Licence = value;
                else
                    throw new ArgumentOutOfRangeException("Licence", value, "The licence type is not valid for the vehicle type.");
            }
        }
    }
}
