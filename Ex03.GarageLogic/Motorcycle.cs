﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private const int k_LicenseTypeIndex = 1;
        private const int k_EngineCapacityIndex = 0;
        private const int k_TireAmount = 2;
        private const int k_MaxAirPressure = 33;
        private const eFuelType k_FuelType = eFuelType.Octan98;
        private const float k_MaxFuelAmountInLiter = 5.5f;
        private const float k_MaxBatteryTime = 2.5f;
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public eLicenseType LicenseType { get { return m_LicenseType; } }
        public int EngineCapacity { get { return m_EngineCapacity; } }

        public Motorcycle(string i_LicenseNumber) : base(i_LicenseNumber)
        {
        }

        public override eFuelType FuelType { get { return k_FuelType; } }
        public override float MaxFuelAmount { get { return k_MaxFuelAmountInLiter; } }
        public override float MaxBatteryTime { get { return k_MaxBatteryTime; } }
        public override int NumberOfTires { get { return k_TireAmount; } }
        public override float MaxTireAirPressure { get { return k_MaxAirPressure; } }

        public override void CheckAndInsertSpecificData()
        {
            eLicenseType licenseType;
            int engineCapacity;

            if (eLicenseType.TryParse(m_SpecieficDetailsForEachKind[k_LicenseTypeIndex], out licenseType))
            {
                m_LicenseType = licenseType;
            }
            else
            {
                throw new FormatException("License type is not valid.");
            }

            if (int.TryParse(m_SpecieficDetailsForEachKind[k_EngineCapacityIndex], out engineCapacity))
            {
                if(engineCapacity < 0)
                {
                    throw new ArgumentException("The engine capacity should be positive");
                }
                m_EngineCapacity = engineCapacity;
            }
            else
            {
                throw new FormatException("Egine capacity should be a number.");
            }
        }

        public override string[] SpecificData()
        {
            return new string[] { "License Type (A1,AA,B1,A) ", "Engine Capacity" };
        }
    }


}
