/*
 *Визначити клас з ім'ям Airport, який містить такі поля:
• назву пункту призначення;
• номер рейсу;
• тип літака.
І методи:
• введення даних масив з n елементів типу Airport;
• упорядкувати масив за спаданням номера рейсу;
• виведення номера рейсів і типів літаків, що вилітають у пункт, назва якого збіглася з назвою,
введеною користувачем.
 */
using System;
using System.Text;
using System.Linq;

namespace Task12.Airport
{
    public class Airport
    {
        public string Destination { get; set; }
        public int FlightNumber { get; set; }
        public string TypeOfAirCraft { get; set; }

        public Airport() { }

        public Airport(string destination, int flynumber, string typeofaircraft)
        { 
            Destination = destination;
            FlightNumber = flynumber;
            TypeOfAirCraft = typeofaircraft;
        }

        public Airport this[int index] 
        {
            get {return this[index];}
            set {this[index] = value;}
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            int n = 5;
            Airport[] airports = new Airport[n];
            //List<Airport> airports = new List<Airport>();

            //for(int i=0; i < n; i++)
            //{
            //    airports[i] = new Airport();
            //}

            airports[0] = new Airport("Kyiv", 1201, "Boing 777");
            airports[1] = new Airport("Berlin", 1202, "Boing 666");
            airports[2] = new Airport("Warshava", 1208, "Boing 555");
            airports[3] = new Airport("Paris", 1203, "Boing 899");
            airports[4] = new Airport("Lviv", 1205, "Boing 567");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{airports[i].Destination}, {airports[i].FlightNumber}, {airports[i].TypeOfAirCraft}");
            }
            Console.WriteLine(new string('-', 50));

//-----
            Array.Sort(airports, (a, b) => b.FlightNumber.CompareTo(a.FlightNumber));
           
           for(int i=0; i < n; i++)
            {
                Console.WriteLine($"{airports[i].Destination}, {airports[i].FlightNumber}, {airports[i].TypeOfAirCraft}");
            }
            Console.WriteLine(new string('-', 50));
//-----
            var sortedFlightNumber = from p in airports
                orderby p.FlightNumber
                select p;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{airports[i].Destination}, {airports[i].FlightNumber}, {airports[i].TypeOfAirCraft}");
            }
            Console.WriteLine(new string('-', 50));
//-----
            Console.WriteLine("Ведіть номер рейсу для вибірки");
            int number = int.Parse(Console.ReadLine());

            var selectedFlightNumber = from p in airports
                                       where p.FlightNumber == number
                                       select p;

                Console.WriteLine($"{ selectedFlightNumber.First().Destination}, {selectedFlightNumber.First().FlightNumber}, {selectedFlightNumber.First().TypeOfAirCraft}");
//-----


            Console.WriteLine("I'm, here!");
        }
    }
}
