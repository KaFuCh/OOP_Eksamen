using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public class Truck : Vehicle {
        public int LoadCapacity {
            get;
            set;
        }
        public int Height {
            get;
            set;
        }
        public int Weight {
            get;
            set;
        }
        public int Length {
            get;
            set;
        }

        public override LicenceType Licence {
            get {
                return _licence;
            }
            set {
                if(value == LicenceType.CE || (value == LicenceType.C && !TowBar))
                    _licence = value;
                else
                    throw new ArgumentOutOfRangeException("Licence", value, "The licence type is not valid for the vehicle type.");
            }
        }

        public override string ToString() {
            return "Truck: " + this.RegNumber + ", " + this.Name + ", " + this.LoadCapacity + " kg, " + this.Height + " m";
        }

        public override double EngineSize {
            set {
                if(value >= 4.2 && value <= 15)
                    _engineSize = value;
                else
                    throw new ArgumentOutOfRangeException("EngineSize", value, "The engine size is not valid for the vehicle type.");
            }
        }
    }
}
