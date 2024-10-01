using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern.Demo
{
    internal interface ICabCallCenter
    {
        void Register(ICab cab);

        void BookCab(IPassenger passenger);
    }

    internal class CabCallCenter : ICabCallCenter
    {
        private readonly Dictionary<string, ICab> cabs = new Dictionary<string, ICab>();
        public void BookCab(IPassenger passenger)
        {
            foreach (var cab in cabs.Values.Where(c => c.IsFree))
            {
                if (IsWithin5MileRadius(cab.Currentlocation, passenger.location))
                {
                    cab.Assign(passenger.Name,passenger.Address);
                    passenger.AcKnowledge(cab.Name);
                }
            }
        }

        public void Register(ICab cab)
        {
            if (!cabs.ContainsValue(cab)) cabs.Add(cab.Name, cab);
        }

        private bool IsWithin5MileRadius(int cabLocation,int passengerLocation)
            => Math.Abs(cabLocation - passengerLocation) < 5;
    }


}
