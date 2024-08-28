using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    internal class Circle
    {
        static float _PI = 3.141F;
        int _Radius;

        public Circle(int radius)
        {
            this._Radius = radius;
        }

        public float CalculateArea()
        {
            return _PI * this._Radius * this._Radius;
        }
    }
}
