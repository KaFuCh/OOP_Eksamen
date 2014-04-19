using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public class InvalidRegNoException : Exception {
        public InvalidRegNoException(string regNo) : base(string.Format("\"{0}\" is not a valid registration number", regNo)) {
        }
    }
}
