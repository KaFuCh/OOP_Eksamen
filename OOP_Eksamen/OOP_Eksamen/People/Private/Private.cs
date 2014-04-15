using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public abstract class Private : Person{
        private string _cpr;
        public string CPR {
            get {
                return _cpr.Substring(0, 6) + "-****";
            }
            set {
                if(value.Length == 10 && value.All(char.IsDigit))
                    _cpr = value;
                else
                    throw new ArgumentOutOfRangeException("CPR", value, "The CPR Number is not valid");
            }
        }
    }
}
