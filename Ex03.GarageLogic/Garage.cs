﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleDataInGarage> m_Vehicles = new Dictionary<string, VehicleDataInGarage>();

        public Dictionary<string, VehicleDataInGarage> Vehicles { get { return m_Vehicles; } }

        public Dictionary<string, VehicleDataInGarage> GetLicenseNumberList(eCarStatus i_StatusToPresentBy)
        {
            Dictionary<string, VehicleDataInGarage> vehiclesByStatus = new Dictionary<string, VehicleDataInGarage>();

            foreach (KeyValuePair<string, VehicleDataInGarage> vehicle in m_Vehicles)
            {
                if (vehicle.Value.CarStatus == i_StatusToPresentBy)
                {
                    vehiclesByStatus[vehicle.Key] = vehicle.Value;
                }
            }

            return vehiclesByStatus;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eCarStatus i_NewCarStatus)
        {
            //ToDo = check if no vehicle in the garage
            m_Vehicles[i_LicenseNumber].CarStatus = i_NewCarStatus;
        }

        public void InfaltionToMax(string i_LicenseNumber)
        {
            //ToDo = check if no vehicle in the garage
            foreach (Vehicle.Tire tire in m_Vehicles[i_LicenseNumber].Vehicle.Tires)
            {
                tire.Infaltion(tire.MaxTirePressue);
            }
        }


        public void FuelingVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_FuelAmount)
        {
            m_Vehicles[i_LicenseNumber].Vehicle.Engine.FillEngine(i_FuelAmount, i_FuelType);
        }

        public void ChargeVehicle(string i_LicenseNumber, float i_MinutesToCharge)
        {
            m_Vehicles[i_LicenseNumber].Vehicle.Engine.FillEngine(i_MinutesToCharge, eFuelType.None);
        }

        public Vehicle CheckIfTheVehicleIsInGarage(string i_LicenseNumber)
        {
            Vehicle existVehicle = null;
            if (m_Vehicles.ContainsKey(i_LicenseNumber))
            {
                existVehicle = m_Vehicles[i_LicenseNumber].Vehicle;
            }
            return existVehicle;
        }

        public void AddVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            m_Vehicles[i_Vehicle.LicenseNumber] = new VehicleDataInGarage(i_Vehicle, i_OwnerName, i_OwnerPhoneNumber);
        }

        public void ChangeVehicleStatusToInRepair(string i_LicenseNumber)
        {
            m_Vehicles[i_LicenseNumber].CarStatus = eCarStatus.InRepair;
        }
    }

}
