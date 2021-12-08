using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicConsoleApp
{
    class Doctor:Employee,IComparable
    {
        public int numbersOfPatients;
        public int birthYear;
  
        public Doctor(int numbersOfPatients, int birthYear ) : base()
        {
            this.numbersOfPatients = numbersOfPatients;
            this.birthYear = birthYear;   
        }
        public Doctor():base() { }
        public int CompareTo(object obj)
        {
            Doctor doctor = (Doctor)obj;
            if (this.numbersOfPatients < doctor.numbersOfPatients) return -1;
            if (this.numbersOfPatients > doctor.numbersOfPatients) return 1;
            return 0;
        }
        
    }
}
