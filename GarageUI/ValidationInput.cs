namespace GarageUI
{
    internal static class ValidationInput
    {
        private const int k_NumberOfDigitInPhoneNumber = 10;
        private const int k_MaxNumberOfDigitInLicensePlate = 9;
        private const int k_MinNumberOfDigitInLicensePlate = 6;
        private const int k_NumberOfVehicles = 3;
        private const int k_NumberOfMenuOptions = 8;
        private const int k_NumberOfFilterOptions = 4;
        private const int k_NumberOfStatusOptions = 3;

        public static bool CheckEnergyPercentage(string i_InputToCheck)
        {
            float energyPercentage;
            bool isValid = float.TryParse(i_InputToCheck, out energyPercentage);

            if(isValid)
            {
                isValid = energyPercentage > 0 && energyPercentage <= 100;
            }

            if(!isValid)
            {
                ConsoleMsg.EnergyPercentageError();
            }

            return isValid;
        }

        public static bool CheckGarageMenuInput(string i_InputToCheck)
        {
            int result;
            bool isValid = int.TryParse(i_InputToCheck, out result);

            if(isValid)
            {
                isValid = result > 0 && result <= k_NumberOfMenuOptions;
            }

            if(!isValid)
            {
                ConsoleMsg.ErrorMenuMsg();
            }

            return isValid;
        }

        public static bool CheckLicenseNumber(string i_InputToCheck)
        {
            bool isValid = i_InputToCheck.Length <= k_MaxNumberOfDigitInLicensePlate && 
                           i_InputToCheck.Length >= k_MinNumberOfDigitInLicensePlate;

            if (isValid)
            {
                for (int i = 0; i < i_InputToCheck.Length; i++)
                {
                    if (!char.IsDigit(i_InputToCheck[i]))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (!isValid)
            {
                ConsoleMsg.ErrorLicenseNumber();
            }

            return isValid;
        }

        public static bool CheckCapacity(string i_InputToCheck)
        {
            bool isValid = i_InputToCheck.Length > 0;

            if (isValid)
            {
                for (int i = 0; i < i_InputToCheck.Length; i++)
                {
                    if (!char.IsDigit(i_InputToCheck[i]))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (!isValid)
            {
                ConsoleMsg.ErrorAmount();
            }

            return isValid;
        }

        public static bool TypeRangeCheck(string i_InputToCheck)
        {
            int result;
            bool isValid = int.TryParse(i_InputToCheck, out result);

            if (isValid)
            {
                isValid = result > 0 && result <= k_NumberOfFilterOptions;
            }

            if (!isValid)
            {
                ConsoleMsg.ErrorMenuMsg();
            }

            return isValid;
        }

        public static bool VehicleStatusCheck(string i_InputToCheck)
        {
            int result;
            bool isValid = int.TryParse(i_InputToCheck, out result);

            if (isValid)
            {
                isValid = result > 0 && result <= k_NumberOfStatusOptions;
            }

            if (!isValid)
            {
                ConsoleMsg.ErrorMenuMsg();
            }

            return isValid;
        }

        public static bool CheckDangerousMaterialsInput(string i_InputToCheck)
        {
            bool isValid = i_InputToCheck.Length == 1;

            if (isValid)
            {
                isValid = char.ToUpper(i_InputToCheck[0]) == 'Y' || char.ToUpper(i_InputToCheck[0]) == 'N';
            }

            if (!isValid)
            {
                ConsoleMsg.ErrorMsgInput();
            }

            return isValid;
        }

        public static bool CheckVehicleTypeRange(string i_InputToCheck)
        {
            int result;
            bool isValid = int.TryParse(i_InputToCheck, out result);

            if (isValid)
            {
                isValid = result > 0 && result <= k_NumberOfVehicles;
            }

            if (!isValid)
            {
                ConsoleMsg.ErrorMenuMsg();
            }

            return isValid;
        }

        public static bool CheckEnergyTypeRange(string i_InputToCheck)
        {
            bool isValid = i_InputToCheck.Length == 1;

            if (isValid)
            {
                isValid = char.IsDigit(i_InputToCheck[0]);

                if (i_InputToCheck[0] < '1' || i_InputToCheck[0] > '2')
                {
                    isValid = false;
                }
            }

            if (!isValid)
            {
                ConsoleMsg.ErrorMenuMsg();
            }

            return isValid;
        }

        public static bool CheckOwnersName(string i_InputToCheck)
        {
            bool isValid = i_InputToCheck.Length > 0;

            if (isValid)
            {
                for (int i = 0; i < i_InputToCheck.Length; i++)
                {
                    if (char.IsDigit(i_InputToCheck[i]))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (!isValid)
            {
                ConsoleMsg.ErrorNameMsg();
            }

            return isValid;
        }

        public static bool CheckOwnersPhoneNumber(string i_InputToCheck)
        {
            bool isValid = i_InputToCheck.Length == k_NumberOfDigitInPhoneNumber;

            if (isValid)
            {
                for (int i = 0; i < i_InputToCheck.Length; i++)
                {
                    if (!char.IsDigit(i_InputToCheck[i]))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (!isValid)
            {
                ConsoleMsg.ErrorPhoneNumberMsg();
            }

            return isValid;
        }

        public static bool CheckModelName(string i_InputToCheck)
        {
            bool isValid = i_InputToCheck.Length > 0;

            if (isValid)
            {
                for (int i = 0; i < i_InputToCheck.Length; i++)
                {
                    if (char.IsDigit(i_InputToCheck[i]))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (!isValid)
            {
                ConsoleMsg.ErrorNameMsg();
            }

            return isValid;
        }

        public static bool CheckNumbersOfDoors(string i_InputToCheck)
        {
            bool isValid = i_InputToCheck.Length == 1;
            if (isValid)
            {
                isValid = char.IsDigit(i_InputToCheck[0]);

                if (i_InputToCheck[0] < '2' || i_InputToCheck[0] > '5')
                {
                    isValid = false;
                }
            }

            if (!isValid)
            {
                ConsoleMsg.ErrorAmount();
            }

            return isValid;
        }

        public static bool CheckLicenseType(string i_InputToCheck)
        {
            int result;
            bool isValid = int.TryParse(i_InputToCheck, out result);

            if(isValid)
            {
                isValid = result > 0 && result < 5;
            }

            if(!isValid)
            {
                ConsoleMsg.LicenseTypeError();
            }

            return isValid;
        }

        public static bool CheckEngineCapacity(string i_InputToCheck)
        {
            int result;
            bool isValid = int.TryParse(i_InputToCheck, out result);

            if(isValid)
            {
                isValid = result > 0;
            }

            if(!isValid)
            {
                ConsoleMsg.EngineCapacityError();
            }

            return isValid;
        }
    }
}
