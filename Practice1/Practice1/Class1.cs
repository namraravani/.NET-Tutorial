using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    public class Calculator
    {
        public Calculator()
        {
            Console.WriteLine("Deafult Constructor is Being Called");
        }

        public Calculator(int a,int b)
        {
            Console.WriteLine("Parametrized Constructor is being Called");
        }

        public virtual void Run()
        {
            Console.WriteLine("Hello thi is the Run Method");
        }

        public void Walk()
        {
            Console.WriteLine("This is the walk Method");
        }
    }
}
