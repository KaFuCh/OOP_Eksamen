using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    class Program {
        static void Main(string[] args) {
            BusinessSeller bla = new BusinessSeller();
            PrivateSeller pla = new PrivateSeller();
            bla.CVR = "12629885";
            pla.CPR = "0104931839";
            Console.WriteLine("CVR: {0}", bla.CVR);
            Console.WriteLine("CPR: {0}", pla.CPR);
            Console.ReadKey();
        }
    }
}
