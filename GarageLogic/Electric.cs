namespace GarageLogic
{
    public class Electric : EnergyStorage
    {
        public Electric(float i_MaxBatteryHour)
            : base(i_MaxBatteryHour)
        {
        }

        public override void Fill(float i_Amount)
        {
            float hourConvert = convertToHours(i_Amount);
            EnergyRemain += hourConvert;
            CalculatePercentage();
        }

        private float convertToHours(float i_Amount)
        {
            float hourConvert;

            if (i_Amount > 60)
            {
                hourConvert = (i_Amount / 60) + ((i_Amount % 60) * (1 / 60f));
            }
            else
            {
                hourConvert = i_Amount * (1 / 60f);
            }

            return hourConvert;
        }

        public override string ToString()
        {
            return string.Format(
                @"
===========================
|| Energy storage details||
===========================
Energy Type : Electric engine
Battery capacity : {0} hours
Current battery power : {1} hours
===========================",
                MaxCapacity,
                EnergyRemain);
        }
    }
}