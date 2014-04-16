using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public interface IBusiness{
        string CVR {
            get;
            set;
        }
        decimal Balance {
            get;
            set;
        }
        decimal Credit {
            get;
            set;
        }
        bool CheckCVR(string cvr); 
    }
}
    