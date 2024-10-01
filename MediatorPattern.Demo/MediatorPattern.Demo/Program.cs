using MediatorPattern.Demo;

internal class Program
{
    private static void Main(string[] args)
    {

        var callCenter = new CabCallCenter();

        var passenger1 = new Passenger("Passenger1", "123 Street", 10) ;
        var passenger2 = new Passenger("Passenger2", "125 Street", 20) ;

        var cab1 = new Cab("Cab1",11,true);
        var cab2 = new Cab("Cab2", 12, false);

        callCenter.BookCab(passenger1);
        callCenter.BookCab(passenger2);

        Console.ReadLine();
        

        
    }
}