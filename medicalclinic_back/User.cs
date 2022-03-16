using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medicalclinic_back
{
    public class User
    {
        private int attempt = 4;
        public int Attempt { get { return attempt; } set { attempt = value; } }
        public string wrongData()
        {
            this.Attempt--;
            return "Nieprawidłowy login lub hasło! " + this.Attempt;
        }      
        public bool checkAttempt()
        {
            if (this.Attempt == 1)
                return true;
            return false;
        }

        public string showInfo()
        {
            return "Nie udało się zalogować po kilku próbach! Nałożono karę czasową";
        }
    }
}
