using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public interface IPrivate { //interface used for simulated multiple inheritance
        string CPR {
            get;
            set;
        }
        decimal Balance {
            get;
            set;
        }
        bool CheckCPR(string cpr);
    }
}
