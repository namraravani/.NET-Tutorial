using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    public class Class4 : Calculator
    {
        public override void Run()
        {
            Console.WriteLine("This is the new run method from the child Class");
        }

        public new void Walk()
        {
            Console.WriteLine("This is the new walk method from the child Class");
        }


        
    }
}
