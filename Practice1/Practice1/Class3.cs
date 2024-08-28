using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    internal class Child : AbsClass
    {
        public override void Add(int num1, int num2)
        {
            Console.WriteLine("Hello this is the function of the abstract Class");
        }

        public override int Subtract(int num1, int num2)
        {
            Console.WriteLine("Hello this is the function of the abstract Class");
            return num1 - num2;
        }

    }
}
