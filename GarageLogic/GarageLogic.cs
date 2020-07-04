using System;
using System.Collections.Generic;

namespace GarageLogic
{
    public enum eSearchFilter
    {
        Repairing = 1,
        Fixed,
        Paid,
        None
    }

    public class GarageLogic
    {
        private readonly List<RegistrationForm> r_CostumerDetail;

        public GarageLogic()
        {
            r_CostumerDetail = new List<RegistrationForm>();
        }

        public void InsertVehicleToGarage(RegistrationForm i_RegistrationForm)
        {
            if(checkIfExist(i_RegistrationForm.Vehicle.LicenseNumber))
            {
                throw new Exception("The vehicle is already in the garage, Vehicle status change to repairing.");
            }

            r_CostumerDetail.Add(i_RegistrationForm);
        }

        public List<string> ListOfAllVehiclesInTheGarage(eSearchFilter i_FilterStatus)
        {
            List<string> listOfVehicles = new List<string>();

            if (i_FilterStatus == eSearchFilter.None)
            {
                foreach (RegistrationForm costumer in r_CostumerDetail)
                {
                    listOfVehicles.Add(costumer.Vehicle.LicenseNumber);
                }
            }
            else
            {
                RegistrationForm.eVehicleStatus status = (RegistrationForm.eVehicleStatus)i_FilterStatus;
                foreach (RegistrationForm costumer in r_CostumerDetail)
                {
                    if (costumer.Status == status)
                    {
                        listOfVehicles.Add(costumer.Vehicle.LicenseNumber);
                    }
                }
            }

            return listOfVehicles;
        }

        public void ChangeStatusOfVehicle(string i_LicenseNumber, RegistrationForm.eVehicleStatus i_NewStatus)
        {
            if(!checkIfExist(i_LicenseNumber))
            {
                throw new Exception("The vehicle was not found.");
            }

            foreach (RegistrationForm costumer in r_CostumerDetail)
            {
                if (costumer.Vehicle.LicenseNumber == i_LicenseNumber)
                {
                    costumer.Status = i_NewStatus;
                }
            }
        }

        public void InflateTire(string i_LicenseNumber)
        {
            if (!checkIfExist(i_LicenseNumber))
            {
                throw new Exception("The vehicle was not found.");
            }

            foreach (RegistrationForm costumer in r_CostumerDetail)
            {
                if(costumer.Vehicle.LicenseNumber == i_LicenseNumber)
                {
                    foreach(Tire wheel in costumer.Vehicle.Wheels)
                    {
                        wheel.Inflate(wheel.MaxPressure - wheel.CurrentAirPressure);
                    }

                    break;
                }
            }
        }

        public void FillFuel(string i_LicenseNumber, Fuel.eFuelType i_FuelType, float i_AmountOfFuel)
        {
            if (!checkIfExist(i_LicenseNumber))
            {
                throw new Exception("The vehicle was not found.");
            }

            foreach (RegistrationForm costumer in r_CostumerDetail)
            {
                if (costumer.Vehicle.LicenseNumber == i_LicenseNumber)
                {
                    if (costumer.Vehicle.EnergyStorage is Fuel)
                    {
                        costumer.Vehicle.FillEnergyStorage(i_AmountOfFuel, i_FuelType);
                        break;
                    }

                    throw new ArgumentException("Error: This is electric vehicle");
                }
            }
        }

        public void RechargeBattery(string i_LicenseNumber, float i_Amount)
        {
            if (!checkIfExist(i_LicenseNumber))
            {
                throw new Exception("The vehicle was not found.");
            }

            foreach (RegistrationForm costumer in r_CostumerDetail)
            {
                if (costumer.Vehicle.LicenseNumber == i_LicenseNumber)
                {
                    if(costumer.Vehicle.EnergyStorage is Electric)
                    {
                        costumer.Vehicle.FillEnergyStorage(i_Amount);
                    }
                    else
                    {
                        throw new ArgumentException("Error: That vehicle run with gus");
                    }
                }
            }
        }

        private bool checkIfExist(string i_LicenseNumberToCheck)
        {
            bool isExist = false;

            foreach (RegistrationForm costumer in r_CostumerDetail)
            {
                if (costumer.Vehicle.LicenseNumber == i_LicenseNumberToCheck)
                {
                    costumer.Status = RegistrationForm.eVehicleStatus.Repairing;
                    isExist = true;
                    break;
                }
            }

            return isExist;
        }

        public RegistrationForm GetFullDetails(string i_LicenseNumber)
        {
            RegistrationForm vehicleDetails = null;

            if (!checkIfExist(i_LicenseNumber))
            {
                throw new Exception("The vehicle was not found.");
            }

            foreach (RegistrationForm costumer in r_CostumerDetail)
            {
                if (costumer.Vehicle.LicenseNumber == i_LicenseNumber)
                {
                    vehicleDetails = costumer;
                    break;
                }
            }

            return vehicleDetails;
        }
    }
}