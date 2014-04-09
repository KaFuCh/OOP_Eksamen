using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public class RV : Vehicle {
        public enum HeatingSystemType {
            Gas,
            Electric,
            Oil
        }

        public uint NoOfSeats {
            get;
            set;
        }
        public uint NoOfSleepSpots {
            get;
            set;
        }
        public HeatingSystemType HeatingSystem {
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
                if(value == LicenceType.B)
                    _licence = value;
                else
                    throw new ArgumentOutOfRangeException("Licence", value, "The licence type is not valid for the vehicle type.");
            }
        }

        public override EnergyClassType EnergyClass {
            get {
                if(HeatingSystem == HeatingSystemType.Oil)
                    return calcEnergyClass(0.7);
                else if(HeatingSystem == HeatingSystemType.Electric)
                    return calcEnergyClass(0.8);
                else if(HeatingSystem == HeatingSystemType.Gas)
                    return calcEnergyClass(0.9);
                else
                    throw new MemberAccessException("Cannot calculate energy class. Heating system not set.");
            }
        }
    }
}
