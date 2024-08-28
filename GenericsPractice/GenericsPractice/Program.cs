namespace Generics
{
    //class Example
    //{
    //    //public static void ShowArray<T>(T[] arr)
    //    //{
    //    //    for (int i = 0; i < arr.Length; i++) { 
    //    //        Console.WriteLine(arr[i]);
    //    //    }
    //    //}

    //    // this below method is known as generic method as we can pass any datatype to it
    //    public static bool Check<T>(T a, T b)
    //    {
    //        return a.Equals(b);
    //    }
    //}

    class GenExample<T>
    {
        T hel;

        public GenExample(T hel)
            { this.hel = hel; 
        }
    }


    class program
    {
        static void Main(string[] args)
        {
            
            //int[] arr = new int[3];
            //arr[0] = 1; arr[1] = 2; arr[2] = 3;

            //Console.WriteLine(Example.Check(10, "10"));

            GenExample<int> g1 = new GenExample<int>(1);
        }
    }

}
