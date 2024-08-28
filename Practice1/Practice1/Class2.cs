using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    public abstract class AbsClass
    {
        public abstract void Add(int num1, int num2);
        public abstract int Subtract(int num1, int num2);

        public void multiplication(int num1,int num2)
        {
            Console.WriteLine("Hello This is the non abstract method");
        }
        
    }
}
