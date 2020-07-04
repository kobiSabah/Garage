using System;

namespace GarageLogic
{
    public class RegistrationForm
    {
        private string m_Name;
        private string m_PhoneNumber;
        private eVehicleStatus m_VehicleStatus;
        private Vehicle m_Vehicle;

        public enum eVehicleStatus
        {
            Repairing = 1,
            Fixed,
            Paid
        }
        
        public RegistrationForm(RegistrationForm i_RegistrationCopy)
        {
            m_Name = i_RegistrationCopy.Name;
            m_VehicleStatus = i_RegistrationCopy.Status;
            m_PhoneNumber = i_RegistrationCopy.m_PhoneNumber;
            m_Vehicle = i_RegistrationCopy.m_Vehicle;
        }

        public RegistrationForm()
        {
            m_VehicleStatus = eVehicleStatus.Repairing;
        }

        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                m_Name = value;
            }
        }

        public string PhoneNumberNumber
        {
            set
            {
                m_PhoneNumber = value;
            }
        }

        public eVehicleStatus Status
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }

            set
            {
                m_Vehicle = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
@"
=====================
|| Vehicle details ||
=====================
{0}
==========================
|| Registration Details ||
==========================
Costumer name : {1}
Costumer phone number : {2}
Vehicle status : {3}
===========================",
                m_Vehicle,
                m_Name,
                m_PhoneNumber,
                Enum.GetName(typeof(eVehicleStatus), m_VehicleStatus));
        }
    }
}
