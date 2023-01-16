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

    /*
    
write a set of classes 
Please assure, that all your code (except for the using declarations) are within the CSharpMilestone namespace, 
otherwise the unit tests will not work. 
Pay very close attention to the naming of your classes, fields, properties and methods, 
as having invalid casing or typos will cause the tests to fail. 
Follow the standard C# coding conventions: https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions

By default, all classes, methods, fields, properties should be available to access by anyone (other classes, assemblies, etc), unless the requirements state otherwise.

Write a class called Vehicle, that will serve as a abase for all vehicle types implemented later. 
This class should contain two string auto-properties: 
Brand and Model, that can only be accessed by this class and its deriving classes. 
This class can't be instantiated. 
There should be a VehicleType method called GetVehicleType, which returns the proper enum value for every child class (at this point it shouldn't be implemented). There should also be a similar method, GetVehicleRange that receives parameters FuelType fuelType, int amount and returns an integer value, representing a distance in kilometres. There also should be a one implemented string method, called GetDescription, that returns a description of given pet. Examples of expected return values: This is Ford Mustang which moves on Land or This is Boeing 200 which moves on Air

There should be a second layer in the class hierarchy, consisting of classes that still can't be instantiated, but implement the GetVehicleType method (it should also be assured, that this method can't be overriden again by the child classes in the third layer). These classes should be Car and Aircraft.

There should be 3 car classes: GasolineCar, DieselCar and ElectricCar. GasolineCar runs on gasoline (efficiency: 15 km per unit) or LPG (20 km per unit). DieselCar runs on diesel - duh - (30 km per unit) and ElectricCar runs on Electricity (50 km per unit).

There should be 2 aircraft classes: Helicopter and Airplane. Both run on Jet fuel, with Helicopter having an efficiency of 75 km per unit, while Airplane gets 100 km per unit.

In case of an invalid fuel being passed as the parameter to GetVehicleRange, an ArgumentOutOfRangeException should be thrown.
    */

       public abstract class Vehicle
    {
        protected string Brand { get; set; }
        protected string Model { get; set; }

        protected Vehicle(string brand, string model)
        {
            Brand = brand;
            Model = model;
        }

        public abstract VehicleType GetVehicleType();

        public virtual int GetVehicleRange(FuelType fuelType, int amount)
        {
            switch (fuelType)
            {
                case FuelType.Gasoline:
                    return 15 * amount;
                case FuelType.LPG:
                    return 20 * amount;
                case FuelType.Diesel:
                    return 30 * amount;
                case FuelType.Electricity:
                    return 50 * amount;
                case FuelType.Jet:
                    return 75 * amount;
                default:
                    throw new ArgumentOutOfRangeException("Invalid fuel type");
            }
        }

        public virtual string GetDescription()
        {
            return $"This is {Brand} {Model} which moves on {GetVehicleType()}";
        }
    }

    public abstract class Car : Vehicle
    {
        public Car(string brand, string model) : base(brand, model)
        {
        }

        public override VehicleType GetVehicleType()
        {
            return VehicleType.Land;
        }

        public abstract int GetVehicleRange(FuelType fuelType, int amount);
    }

    public class GasolineCar : Car
    {
        public GasolineCar(string brand, string model) : base(brand, model)
        {
        }

        public override int GetVehicleRange(FuelType fuelType, int amount)
        {
            switch (fuelType)
            {
                case FuelType.Gasoline:
                    return 15 * amount;
                case FuelType.LPG:
                    return 20 * amount;
                default:
                    throw new ArgumentOutOfRangeException("Invalid fuel type for GasolineCar");
            }
        }
    }

    public class DieselCar : Car
    {
        public DieselCar(string brand, string model) : base(brand, model)
        {
        }

        public override int GetVehicleRange(FuelType fuelType, int amount)
        {
            if (fuelType == FuelType.Diesel)
                return 30 * amount;
            else
                throw new ArgumentOutOfRangeException("Invalid fuel type for DieselCar");
        }
    }

    public class ElectricCar : Car
    {
        public ElectricCar(string brand, string model) : base(brand, model)
        {
        }

        public override int GetVehicleRange(FuelType fuelType, int amount)
        {
            if (fuelType == FuelType.Electricity)
                return 50 * amount;
            else
                throw new ArgumentOutOfRangeException("Invalid fuel type for ElectricCar");
        }
    }

    public abstract class Aircraft : Vehicle
    {
    protected Aircraft(string brand, string model) : base(brand, model)
    {
    }

    public override VehicleType GetVehicleType()
    {
        return VehicleType.Air;
    }

    public override int GetVehicleRange(FuelType fuelType, int amount)
    {
        if (fuelType != FuelType.Jet)
            throw new ArgumentOutOfRangeException(nameof(fuelType), "Invalid fuel type for aircraft");

        return amount * 75;
    }
}

public class Helicopter : Aircraft
{
    public Helicopter(string brand, string model) : base(brand, model)
    {
    }

    public override string GetDescription()
    {
        return $"This is {Brand} {Model} which moves on {GetVehicleType()}";
    }
}

public class Airplane : Aircraft
{
    public Airplane(string brand, string model) : base(brand, model)
    {
    }

    public override int GetVehicleRange(FuelType fuelType, int amount)
    {
        if (fuelType != FuelType.Jet)
            throw new ArgumentOutOfRangeException(nameof(fuelType), "Invalid fuel type for aircraft");

        return amount * 100;
    }

    public override string GetDescription()
    {
        return $"This is {Brand} {Model} which moves on {GetVehicleType()}";
    }
}




}
