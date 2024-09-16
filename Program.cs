
using System;
namespace Police___Firefighter
{
    public abstract class PublickServant
        {
            public int PensionAmount { get; set; }
            public DriveToPlaceOfInterestDelegate DriveToPlaceOfInterest { get; set; }
            
            public delegate void DriveToPlaceOfInterestDelegate();
        }

    public interface IPerson
        {
            string Name { get; set; }
            int Age { get; set; }
        }

    public class Firefighter : PublickServant, IPerson
    {
        public Firefighter(string name, int age)
        {
            this.Name = name;
            this.Age = age;

            this.DriveToPlaceOfInterest += delegate
            {
                Console.WriteLine("Driving the firetruck");
                GetInFiretruck();
                TurnOnSiren();
                FollowDirections();
            };
        }
        
        public string Name { get; set; }
        public int Age { get; set; }
        private void GetInFiretruck() { }
        private void TurnOnSiren() { }
        private void FollowDirections() { }
    }
    //public override void DriveToPlaceOfInterest()
    //{
    //    GetInFiretruck();
    //    TurnOnSiren();
    //    Followdirections();

    public class PoliceOfficer : PublickServant, IPerson
    {
        private bool _hasEmergency = false;
        public PoliceOfficer(string name, int age, bool hasEmergency = false)
        {
            this.Name = name;
            this.Age = age;
            this._hasEmergency = hasEmergency;

            if (this.HasEmergency)
            {
                this.DriveToPlaceOfInterest += delegate
                {
                    Console.WriteLine("Driving the police car with siren");
                    GetInPoliceCar();
                    TurnOnSiren();
                    FollowDirections();
                };
            }
            else
            {
                this.DriveToPlaceOfInterest += delegate
                {
                    Console.WriteLine("Driving the police car with siren");
                    GetInPoliceCar();
                    FollowDirections();
                };
            }
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public bool HasEmergency
        {
            get { return _hasEmergency; }
            set { _hasEmergency = value; }
        }

        private void GetInPoliceCar() { }
        private void TurnOnSiren() { }
        private void FollowDirections() { }

    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            Firefighter firefighter = new Firefighter("Joe Carrington", 35);
            firefighter.PensionAmount = 5000;

            PrintNameAndAge(firefighter);
            PrintPensionAmount(firefighter);

            firefighter.DriveToPlaceOfInterest();

            PoliceOfficer officer = new PoliceOfficer("Jane Hope", 32);
            officer.PensionAmount = 5500;

            PrintNameAndAge(officer);
            PrintPensionAmount(officer);

            officer.DriveToPlaceOfInterest();

            officer = new PoliceOfficer("John Valor", 32, true);
            PrintNameAndAge(officer);
            officer.DriveToPlaceOfInterest();
            Console.ReadLine();
        }
                
        static void PrintNameAndAge(IPerson person)
        {
            Console.WriteLine("Name: " + person.Name);
            Console.WriteLine("Age: " + person.Age);
        }

        static void PrintPensionAmount(PublickServant servant)
        {
            if (servant is Firefighter)
                Console.WriteLine("Pension of firefighter: " + servant.PensionAmount);
            else if (servant is PoliceOfficer)
                Console.WriteLine("Pension of officer: " + servant.PensionAmount);
        }
    }
}