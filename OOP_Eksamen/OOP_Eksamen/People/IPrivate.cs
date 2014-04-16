using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public interface IPrivate{
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
