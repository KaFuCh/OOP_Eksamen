using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public abstract class Car : Vehicle {
        protected int _noOfSeats;
        protected int[] _trunkDimensions = new int[3];

        public virtual int NoOfSeats {
            get;
            set;
        }

        public int[] TrunkDimensions {
            get {
                return _trunkDimensions;
            }
            set {
                _trunkDimensions = value;
            }
        }

        public override LicenceType Licence {
            get {
                return _licence;
            }
            set {
                if(value == LicenceType.B || value == LicenceType.BE)
                    _licence = value;
                else
                    throw new ArgumentOutOfRangeException("Licence", value, "The licence type is not valid for the vehicle type.");
            }
        }

        public override double EngineSize {
            set {
                if(value >= 0.7 && value <= 10)
                    _engineSize = value;
                else
                    throw new ArgumentOutOfRangeException("EngineSize", value, "The engine size is not valid for the vehicle type.");
            }
        }
    }
}
