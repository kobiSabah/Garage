using System;
using System.Collections.Generic;
using System.Threading;
using GarageLogic;

namespace GarageUI
{
    public class ConsoleUI
    {
        private const int k_CarWheelsAmount = 4;
        private const int k_TruckWheelsAmount = 16;
        private const int k_MotorcycleWheelsAmount = 2;
        private readonly GarageLogic.GarageLogic r_GarageLogic = new GarageLogic.GarageLogic();

        private enum eMenuOption
        {
            InsertVehicle = 1,
            AllVehicleLicensePlate,
            ChangeCarStatus,
            InflateTire,
            FillFuel,
            ChargeVehicle,
            FullDetails,
            LeaveTheGarage
        }

        public void Initialize()
        {
            while (true)
            {
                ConsoleMsg.MenuOptions();
                string request;
                do
                {
                    request = Console.ReadLine();
                }
                while(!ValidationInput.CheckGarageMenuInput(request));

                int result;
                int.TryParse(request, out result);
                getMenuRequest((eMenuOption)result);
            }
        }

        private void getMenuRequest(eMenuOption i_Request)
        {
            switch(i_Request)
            {
                case eMenuOption.InsertVehicle:
                    insertVehicle();
                    break;
                case eMenuOption.AllVehicleLicensePlate:
                    getListOfVehiclesInGarage();
                    break;
                case eMenuOption.ChangeCarStatus:
                    changeVehicleStatus();
                    break;
                case eMenuOption.InflateTire:
                    inflateTireToMax();
                    break;
                case eMenuOption.FillFuel:
                    fillFuel();
                    break;
                case eMenuOption.ChargeVehicle:
                    chargeElectricVehicle();
                    break;
                case eMenuOption.FullDetails:
                    fullVehicleDetails();
                    break;
                case eMenuOption.LeaveTheGarage:
                    leaveGarage();
                    break;
            }
        }

        private void leaveGarage()
        {
            ConsoleMsg.Leave();
            Thread.Sleep(2000);
            Environment.Exit(0);
        }

        private void inflateTireToMax()
        {
            string licenseNumber = getLicenseNumber();
            ConsoleMsg.InflateTire();
            r_GarageLogic.InflateTire(licenseNumber);
        }

        private string getLicenseNumber()
        {
            ConsoleMsg.LicenseNumber();
            string licenseNumber = Console.ReadLine();
            while (!ValidationInput.CheckLicenseNumber(licenseNumber))
            {
                ConsoleMsg.LicenseNumber();
                licenseNumber = Console.ReadLine();
            }

            return licenseNumber;
        }

        private void chargeElectricVehicle()
        {
            string amount;
            string licenseNumber = getLicenseNumber();
            ConsoleMsg.AmountToCharge();
            do
            {
                amount = Console.ReadLine();
            }
            while(!ValidationInput.CheckCapacity(amount));
            try
            {
                float result;
                float.TryParse(amount, out result);
                r_GarageLogic.RechargeBattery(licenseNumber, result);
            }
            catch(ValueOutOfRangeException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            catch(ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        private void fillFuel()
        {
            string licenseNumber = getLicenseNumber();
            Console.WriteLine("Enter amount of fuel :");
            string fuelAmount = Console.ReadLine();
            while (!ValidationInput.CheckCapacity(fuelAmount))
            {
                Console.WriteLine("Enter amount of fuel : ");
                fuelAmount = Console.ReadLine();
            }

            try
            {
                float result;
                float.TryParse(fuelAmount, out result);
                r_GarageLogic.FillFuel(licenseNumber, getFuelType(), result);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        private Fuel.eFuelType getFuelType()
        {
            ConsoleMsg.FuelType();
            string userInput = Console.ReadLine();
            while (!ValidationInput.TypeRangeCheck(userInput))
            {
                ConsoleMsg.FuelType();
                userInput = Console.ReadLine();
            }

            int result;
            int.TryParse(userInput, out result);
            return (Fuel.eFuelType)result;
        }

        private void fullVehicleDetails()
        {
            string licenseNumber = getLicenseNumber();
            try
            {
                RegistrationForm registrationForm = r_GarageLogic.GetFullDetails(licenseNumber);
                Console.WriteLine(registrationForm.ToString());
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        private void changeVehicleStatus()
        {
            string licenseNumber = getLicenseNumber();
            RegistrationForm.eVehicleStatus newStatus = getStatus();
            try
            {
                r_GarageLogic.ChangeStatusOfVehicle(licenseNumber, newStatus);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        private RegistrationForm.eVehicleStatus getStatus()
        {
            ConsoleMsg.VehicleStatus();
            string status = Console.ReadLine();
            while (!ValidationInput.VehicleStatusCheck(status))
            {
                ConsoleMsg.VehicleStatus();
                status = Console.ReadLine();
            }

            int result;
            int.TryParse(status, out result);
            return (RegistrationForm.eVehicleStatus)result;
        }

        private void getListOfVehiclesInGarage()
        {
            eSearchFilter filter = getSearchFilter();
            List<string> vehicles = r_GarageLogic.ListOfAllVehiclesInTheGarage(filter);
            if(vehicles.Count == 0)
            {
                ConsoleMsg.EmptyGarage();
            }
            else
            {
                ConsoleMsg.VehicleInGarage();
                foreach(string licenseNumber in vehicles)
                {
                    Console.WriteLine(licenseNumber);
                }
            }
        }

        private eSearchFilter getSearchFilter()
        {
            ConsoleMsg.SearchFilter();
            string filter = Console.ReadLine();
            while (!ValidationInput.TypeRangeCheck(filter))
            {
                ConsoleMsg.SearchFilter();
                filter = Console.ReadLine();
            }

            int result;
            int.TryParse(filter, out result);
            return (eSearchFilter)result;
        }

        private Factory.eVehicleType getVehicleType()
        {
            ConsoleMsg.VehicleType();
            string input = Console.ReadLine();
            while (!ValidationInput.CheckVehicleTypeRange(input))
            {
                ConsoleMsg.VehicleType();
                input = Console.ReadLine();
            }

            int result;
            int.TryParse(input, out result);
            return (Factory.eVehicleType)result;
        }

        private void insertVehicle()
        {
            Factory.eVehicleType vehicleType = getVehicleType();
            ConsoleMsg.VehicleMsg();
            switch (vehicleType)
            {
                case Factory.eVehicleType.Car:
                    insertCar();
                    break;
                case Factory.eVehicleType.Truck:
                    insertTruck();
                    break;
                case Factory.eVehicleType.Motorcycle:
                    insertMotorcycle();
                    break;
            }
        }

        // $G$ DSN-002 (-10) The UI should not know Car\Truck\Motorcycle
        private void insertCar()
        {
            string modelName = getModelName();
            string licenseNumber = getLicenseNumber();
            Factory.eEnergyType energyType = GetEnergyType();
            EnergyStorage energyStorage = Factory.GenerateEnergyStorage(Factory.eVehicleType.Car, energyType);
            float energyPercentage = getEnergyPercentage();
            List<Tire> wheels = insertWheels(Factory.eVehicleType.Car, k_CarWheelsAmount);
            byte numberOfDoors = getNumberOfDoors();
            Car.eColor color = getCarColor();

            Car car = Factory.GenerateCar(modelName, licenseNumber, wheels, energyStorage, color, numberOfDoors, energyPercentage);

            try
            {
                r_GarageLogic.InsertVehicleToGarage(getOwnerDetails(car));
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        private void insertTruck()
        {
            string modelName = getModelName();
            string licenseNumber = getLicenseNumber();
            EnergyStorage energyStorage = Factory.GenerateEnergyStorage(Factory.eVehicleType.Truck, Factory.eEnergyType.Fuel);
            float energyPercentage = getEnergyPercentage();
            List<Tire> wheels = insertWheels(Factory.eVehicleType.Truck, k_TruckWheelsAmount);
            bool containDangerousMaterials = getIfContainDangerousMaterials();
            float cargoCapacity = getCargoCapacity();

            Truck truck = Factory.GenerateTruck(modelName, licenseNumber, wheels, energyStorage, containDangerousMaterials, cargoCapacity, energyPercentage);

            try
            {
                r_GarageLogic.InsertVehicleToGarage(getOwnerDetails(truck));
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        private void insertMotorcycle()
        {
            string modelName = getModelName();
            string licenseNumber = getLicenseNumber();
            Factory.eEnergyType energyType = GetEnergyType();
            EnergyStorage energyStorage = Factory.GenerateEnergyStorage(Factory.eVehicleType.Motorcycle, energyType);
            float energyPercentage = getEnergyPercentage();
            List<Tire> wheels = insertWheels(Factory.eVehicleType.Motorcycle, k_MotorcycleWheelsAmount);
            Motorcycle.eLicenseType licenseType = getLicenseType();
            int engineCapacity = getEngineCapacity();

            Motorcycle motorcycle = Factory.GenerateMotorcycle(modelName, licenseNumber, wheels, energyStorage, licenseType, engineCapacity, energyPercentage);
            try
            {
                r_GarageLogic.InsertVehicleToGarage(getOwnerDetails(motorcycle));
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        private int getEngineCapacity()
        {
            string engineCapacityStr;
            ConsoleMsg.EngineCapacity();
            do
            {
                engineCapacityStr = Console.ReadLine();
            }
            while(!ValidationInput.CheckEngineCapacity(engineCapacityStr));

            int result;
            int.TryParse(engineCapacityStr, out result);
            return result;
        }

        private Motorcycle.eLicenseType getLicenseType()
        {
            ConsoleMsg.LicenseType();
            string licenseTypeStr;
            do
            {
                licenseTypeStr = Console.ReadLine();
            }
            while(!ValidationInput.CheckLicenseType(licenseTypeStr));

            int result;
            int.TryParse(licenseTypeStr, out result);
            return (Motorcycle.eLicenseType)result;
        }

        private float getEnergyPercentage()
        {
            ConsoleMsg.EnergyMsg();
            ConsoleMsg.EnergyPercentage();
            string energyPercentageStr;
            do
            {
                energyPercentageStr = Console.ReadLine();
            }
            while(!ValidationInput.CheckEnergyPercentage(energyPercentageStr));

            float result;
            float.TryParse(energyPercentageStr, out result);
            return result;
        }

        private void setWheelsCurrentAirPressure(List<Tire> i_Wheels)
        {
            setWheelsCurrentAirPressure:
            float currentAirPressure = getCurrentAirPressure();
            foreach(Tire tire in i_Wheels)
            {
                try
                {
                    tire.CurrentAirPressure = currentAirPressure;
                }
                catch(ValueOutOfRangeException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    goto setWheelsCurrentAirPressure;
                }
            }
        }

        private Factory.eEnergyType GetEnergyType()
        {
            ConsoleMsg.EnergyStorage();
            string energyType = Console.ReadLine();
            while (!ValidationInput.CheckEnergyTypeRange(energyType))
            {
                ConsoleMsg.EnergyStorage();
                energyType = Console.ReadLine();
            }

            int result;
            int.TryParse(energyType, out result);
            return (Factory.eEnergyType) result;
        }

        private bool getIfContainDangerousMaterials()
        {
            ConsoleMsg.ContainDangerousMaterials();
            string containDangerousMaterials;
            do
            {
                containDangerousMaterials = Console.ReadLine();
            }
            while(!ValidationInput.CheckDangerousMaterialsInput(containDangerousMaterials));

            return containDangerousMaterials != null && char.ToUpper(containDangerousMaterials[0]) == 'Y';
        }

        private int getCargoCapacity()
        {
            ConsoleMsg.CargoCapacity();
            string cargoCapacity = Console.ReadLine();
            while (!ValidationInput.CheckCapacity(cargoCapacity))
            {
                ConsoleMsg.CostumerName();
                cargoCapacity = Console.ReadLine();
            }

            int result;
            int.TryParse(cargoCapacity, out result);
            return result;
        }

        private RegistrationForm getOwnerDetails(Vehicle i_CostumerVehicle)
        {
            ConsoleMsg.RegistrationMsg();
            RegistrationForm registration = new RegistrationForm();
            string ownerName = getOwnerName();
            string phoneNumber = getOwnerPhoneNumber();

            registration.Name = ownerName;
            registration.PhoneNumberNumber = phoneNumber;
            registration.Vehicle = i_CostumerVehicle;

            return registration;
        }

        private string getOwnerName()
        {
            ConsoleMsg.CostumerName();
            string ownersName = Console.ReadLine();
            while (!ValidationInput.CheckOwnersName(ownersName))
            {
                ConsoleMsg.CostumerName();
                ownersName = Console.ReadLine();
            }

            return ownersName;
        }

        private string getOwnerPhoneNumber()
        {
            ConsoleMsg.CostumerPhoneNumber();
            string phoneNumber = Console.ReadLine();
            while (!ValidationInput.CheckOwnersPhoneNumber(phoneNumber))
            {
                ConsoleMsg.CostumerPhoneNumber();
                phoneNumber = Console.ReadLine();
            }

            return phoneNumber;
        }

        private Car.eColor getCarColor()
        {
            ConsoleMsg.Color();
            string colorToCheck = Console.ReadLine();
            while (!ValidationInput.TypeRangeCheck(colorToCheck))
            {
                ConsoleMsg.Color();
                colorToCheck = Console.ReadLine();
            }

            int result;
            int.TryParse(colorToCheck, out result);

            return (Car.eColor)result;
        }

        private string getModelName()
        {
            ConsoleMsg.ModelName();
            string modelName = Console.ReadLine();
            while (!ValidationInput.CheckModelName(modelName))
            {
                ConsoleMsg.ModelName();
                modelName = Console.ReadLine();
            }

            return modelName;
        }

        private byte getNumberOfDoors()
        {
            ConsoleMsg.DoorNumber();
            string numOfDoors = Console.ReadLine();
            while (!ValidationInput.CheckNumbersOfDoors(numOfDoors))
            {
                ConsoleMsg.DoorNumber();
                numOfDoors = Console.ReadLine();
            }

            byte result;
            byte.TryParse(numOfDoors, out result);
            return result;
        }

        private List<Tire> insertWheels(Factory.eVehicleType i_VehicleType, int i_NumberOfWheels)
        {
            ConsoleMsg.WheelsMsg();
            string tireManufacturer = getManufacturerName();
            List<Tire> wheels = Factory.GenerateVehicleTire(
                i_VehicleType,
                i_NumberOfWheels,
                tireManufacturer);
            setWheelsCurrentAirPressure(wheels);

            return wheels;
        }

        private string getManufacturerName()
        {
            string manufacturerName;
            ConsoleMsg.ManufacturerName();
            do
            {
                manufacturerName = Console.ReadLine();
            }
            while(!ValidationInput.CheckModelName(manufacturerName));
                
            return manufacturerName;
        }

        private float getCurrentAirPressure()
        {
            ConsoleMsg.CurrentAirPressure();
            string airPressure = Console.ReadLine();
            while (!ValidationInput.CheckCapacity(airPressure))
            {
                ConsoleMsg.ManufacturerName();
                airPressure = Console.ReadLine();
            }

            float result;
            float.TryParse(airPressure, out result);
            return result;
        }
    }
}
