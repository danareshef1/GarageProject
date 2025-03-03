﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const int k_CarColorIndex = 1;
        private const int k_HowManyDoorsIndex = 0;
        private const int k_TireAmount = 5;
        private const int k_MaxAirPressure = 31;
        private const eFuelType k_FuelType = eFuelType.Octan95;
        private const float k_MaxFuelAmountInLiter = 45f;
        private const float k_MaxBatteryTime = 3.5f;
        private readonly int r_MinDoorAmount = 2;
        private readonly int r_MaxDoorAmount = 5;
        private eCarColor m_CarColor;
        private int m_HowManyDoors;


        public eCarColor CarColor { get { return m_CarColor; } }
        public int HowManyDoors { get { return m_HowManyDoors; } }


        public Car(string i_LicenseNumber) : base(i_LicenseNumber)
        {

        }

        public override eFuelType FuelType { get { return k_FuelType; } }
        public override float MaxFuelAmount { get { return k_MaxFuelAmountInLiter; } }
        public override float MaxBatteryTime { get { return k_MaxBatteryTime; } }
        public override int NumberOfTires { get { return k_TireAmount; } }
        public override float MaxTireAirPressure { get { return k_MaxAirPressure; } }

        public override void CheckAndInsertSpecificData()
        {
            int doorsNum;
            eCarColor carColor;

            if (int.TryParse(m_SpecieficDetailsForEachKind[k_HowManyDoorsIndex], out doorsNum))
            {
                if (doorsNum > r_MinDoorAmount || doorsNum < r_MaxDoorAmount)
                {
                     throw new ValueOutOfRangeException(r_MaxDoorAmount, r_MinDoorAmount);
                }
                else
                {
                    m_HowManyDoors = doorsNum;
                }
            }
            else
            {
                  throw new FormatException("Door amount should be a number.");
            }

            if (eCarColor.TryParse(m_SpecieficDetailsForEachKind[k_CarColorIndex], out carColor))
            {
                m_CarColor = carColor;
            }
            else
            {
                throw new FormatException("Not valid color.");
            }
        }

        public override string[] SpecificData()
        {
            return new string[] { "Car Color (Black, White, Black, Yellow)", "How Many Doors (2-5)" };
        }

    }
}
