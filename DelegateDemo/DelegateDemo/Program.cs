// See https://aka.ms/new-console-template for more information

namespace DelegateDemo
{
    delegate int OpterationDelegate(int param1, int param2);
    public class Delegate
    {
        static int Add(int p1, int p2)
        {
            return p1 + p2;
        }


        static int Multiply(int p1, int p2)
        {
            return p1 * p2;
        }
        static void Main(string[] args)
        {
            OpterationDelegate d1 = Add;
            int result = d1(1,6);

            Console.WriteLine(result);

            d1 = Multiply;
            result = d1(1, 5);

            Console.WriteLine(result);

        }

    }
    

}
