using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public class BusinessSeller : Business {
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

        //public void NotifySeller();
    }
}
