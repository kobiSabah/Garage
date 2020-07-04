using System;

namespace GarageUI
{
    internal static class ConsoleMsg
    {
        public static void MenuOptions()
        {
            Console.WriteLine(@"
===========================
|| Welcome to the Garage ||
===========================
Please choose one of the following:
(1)-- > Insert a car.
(2)-- > Get a list of all cars that are in the garage.
(3)-- > Change a status of a car.
(4)-- > Fill wheels of a vehicle to the max.
(5)-- > Fill fuel of a vehicle.
(6)-- > Charge an electric vehicle.
(7)-- > Check a full status of a vehicle.
(8)-- > Leave the garage.
");
        }

        public static void SearchFilter()
        {
            Console.WriteLine(@"
Choose searching filter : 
1) Repairing.
2) Fixed.
3) Paid.
4) None.
");
        }

        public static void VehicleStatus()
        {
            Console.WriteLine(@"
Choose vehicle status : 
1) Repairing.
2) Fixed.
3) Paid.
");
        }

        // Vehicle details
        public static void VehicleMsg()
        {
            Console.WriteLine(@"
===========================
|| Vehicle basic Details ||
===========================
");
        }

        public static void ModelName()
        {
            Console.WriteLine("Type model name : ");
        }

        public static void LicenseNumber()
        {
            Console.WriteLine("Type license number : ");
        }

        public static void VehicleType()
        {
            Console.WriteLine(@"
Choose type of vehicle to insert :
1) Car.
2) Truck.
3) Motorcycle.
");
        }

        // Energy storage details
        public static void EnergyMsg()
        {
            Console.WriteLine(@"
====================
|| Energy storage ||
====================
");
        }

        public static void AmountToCharge()
        {
            Console.WriteLine("Type minutes to charge : ");
        }

        public static void EnergyPercentage()
        {
            Console.WriteLine("Type your current energy percentage");
        }

        public static void EnergyStorage()
        {
            Console.WriteLine(@"
Choose Energy storage :
1) Fuel.
2) Electric.
");
        }

        public static void FuelType()
        {
            Console.WriteLine(@"
Choose fuel type : 
1) Soler.
2) Octan 95.
3) Octan 96.
4) Octan 98.
");
        }

        // Tire Details
        public static void WheelsMsg()
        {
            Console.WriteLine(@"
====================
|| Tire Details ||
====================
");
        }

        public static void ManufacturerName()
        {
            Console.WriteLine("Type manufacture name : ");
        }

        public static void CurrentAirPressure()
        {
            Console.WriteLine("Type the current tire pressure");
        }

        public static void InflateTire()
        {
            Console.WriteLine("Inflating...");
        }

        // Car details
        public static void Color()
        {
            Console.WriteLine(@"
Choose car color :
1) Red.
2) Black.
3) White.
4) Silver.
");
        }

        public static void DoorNumber()
        {
            Console.WriteLine("Type the number of doors :");
        }

        // Truck details
        public static void ContainDangerousMaterials()
        {
            Console.WriteLine("The truck contain dangerous materials ? Y/N");
        }

        // Motorcycle details
        public static void LicenseType()
        {
            Console.WriteLine(@"
Choose license type:
1) A.
2) A1.
3) AA.
4) B.
");
        }

        public static void EngineCapacity()
        {
            Console.WriteLine("Type engine capacity : ");
        }

        // Registration Details
        public static void RegistrationMsg()
        {
            Console.WriteLine(@"
======================
||Registration form ||
======================
");
        }

        public static void CostumerName()
        {
            Console.WriteLine("Type costumer name :");
        }

        public static void CostumerPhoneNumber()
        {
            Console.WriteLine("Type costumer phone number : ");
        }

        public static void CargoCapacity()
        {
            Console.WriteLine("Type cargo capacity : ");
        }

        public static void Leave()
        {
            Console.WriteLine("Have a good day!");
        }

        // Error msg
        public static void EngineCapacityError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: invalid engine capacity try again");
            Console.ResetColor();
        }

        public static void ErrorPhoneNumberMsg()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
***** Wrong input *****
Please write valid phone number (only 10 Digits) 
");
            Console.ResetColor();
        }

        public static void LicenseTypeError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: invalid license type please try again.");
            Console.ResetColor();
        }

        public static void ErrorMenuMsg()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
Wrong input
Please choose one of the options 
");
            Console.ResetColor();
        }

        public static void ErrorLicenseNumber()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
Wrong input
Please enter correct license number (only digits and maximum amount --> 8 digits)
");
            Console.ResetColor();
        }

        public static void ErrorAmount()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
***** Wrong input *****
Please enter correct amount 
");
            Console.ResetColor();
        }

        public static void ErrorMsgInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
***** Wrong input *****
Please choose one of the options :
Y --> yes
N --> no
");
            Console.ResetColor();
        }

        public static void ErrorNameMsg()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
***** Wrong input *****
Please write valid name (only English Letters) 
");
            Console.ResetColor();
        }

        public static void EnergyPercentageError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Invalid percentage, Try again.");
            Console.ResetColor();
        }

        public static void EmptyGarage()
        {
            Console.WriteLine("There is no vehicle with that status.");
        }

        public static void VehicleInGarage()
        {
            Console.WriteLine("This is the list of all the vehicles in the garage");
        }
    }
}
