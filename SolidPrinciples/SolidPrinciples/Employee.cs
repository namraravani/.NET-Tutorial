using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class Employee
    {
        public virtual int CalculateSalary()
        {
            return 10000;
        }

        public virtual int CalculateBonus()
        {
            return 1000;
        }
    }


    public class PermenantEmployee : Employee
    {
        public override int CalculateSalary() 
        {
            return 20000;
        }
    }

    public class ContractualEmployee : Employee
    {
        public override int CalculateSalary()
        {
            return 20000;
        }

        public override int CalculateBonus()
        {
            throw new NotImplementedException();
        }
    }


}
