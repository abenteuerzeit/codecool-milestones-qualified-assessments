using System;
namespace CSharpMilestone
{
    public enum FuelType
    {
        Gasoline,
        LPG,
        Diesel,
        Electricity,
        Jet
    }

    public enum VehicleType
    {
        Land,
        Water,
        Air,
        Cosmic
    }
    
    public abstract class Vehicle
    {
        public string Brand {get; set;}
        public string Model {get; set;}
        public abstract VehicleType GetVehicleType();
        public abstract int GetVehicleRange(FuelType fuelType, int amount);
        public string GetDescription()
        {
            return $"This is {Brand} {Model} which moves on {this.GetVehicleType()}";
        }
    }
    
    public abstract class Car : Vehicle
    {
        public sealed override VehicleType GetVehicleType()
                {
                    return VehicleType.Land;
                }
    }
    
    public abstract class Aircraft : Vehicle
    {
        public sealed override VehicleType GetVehicleType()
                {
                    return VehicleType.Air;
                }
    }
    
    public class GasolineCar : Car
    {
        public GasolineCar(string brand, string model)
        {
        Brand = brand;
        Model = model;
        }
        public override int GetVehicleRange(FuelType fuelType, int amount)
        {
        if (fuelType != FuelType.Gasoline)
        {
        throw new ArgumentOutOfRangeException();
        }
        return 15 * amount;
        }


    }
    
        public class DieselCar : Car
    {
            public DieselCar(string brand, string model)
        {
        Brand = brand;
        Model = model;
        }
        public override int GetVehicleRange(FuelType fuelType, int amount)
        {
        if (fuelType != FuelType.Diesel)
        {
        throw new ArgumentOutOfRangeException();
        }
        return 30 * amount;
        }
    }
    
       public class ElectricCar : Car
    {
            public ElectricCar(string brand, string model)
        {
        Brand = brand;
        Model = model;
        }
        public override int GetVehicleRange(FuelType fuelType, int amount)
        {
        if (fuelType != FuelType.Electricity)
        {
        throw new ArgumentOutOfRangeException();
        }
        return 50 * amount;
        }
    }
    
    public class Helicopter : Aircraft
    {
                public Helicopter(string brand, string model)
        {
        Brand = brand;
        Model = model;
        }
    public override int GetVehicleRange(FuelType fuelType, int amount)
        {
        if (fuelType != FuelType.Jet)
        {
        throw new ArgumentOutOfRangeException();
        }
        return 75 * amount;
        }
    }
    
    public class Airplane : Aircraft
    {
                public Airplane(string brand, string model)
        {
        Brand = brand;
        Model = model;
        }
    public override int GetVehicleRange(FuelType fuelType, int amount)
        {
        if (fuelType != FuelType.Jet)
        {
        throw new ArgumentOutOfRangeException();
        }
        return 100 * amount;
        }
    }
}
