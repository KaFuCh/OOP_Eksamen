using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    class CarCommercial : Car{
        private uint _loadCapacity;
        public bool SafetyBar {
            get;
            set;
        }
        public uint LoadCapacity {
            get {
                return _loadCapacity;
            }
            set {
                if(_licence == LicenceType.B && value > 750)
                    throw new ArgumentOutOfRangeException("Load capacity", value, "Incorrect load capacity or licence type.");
                else
                    _loadCapacity = value;
            }
        }

        public override int NoOfSeats {
            get {
                return _noOfSeats;
            }
            set {
                if(value == 2)
                    _noOfSeats = value;
                else
                    throw new ArgumentOutOfRangeException("Number of seats", value, "The number of seats is not valid for the vehicle type.");
            }
        }

        public override LicenceType Licence {
            get {
                return _licence;
            }
            set {
                if(value == LicenceType.BE || (value == LicenceType.B && LoadCapacity < 751))
                    _licence = value;
                else
                    throw new ArgumentOutOfRangeException("Licence", value, "The licence type is not valid for the vehicle type.");
            }
        }
    }
}
