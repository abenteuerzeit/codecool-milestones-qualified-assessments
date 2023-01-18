using System;
using System.Collections.Generic;
using System.Linq;

/*
Computer Shop
Please note, that at the moment, Qualified only supports C# 8 - features from C# 9, 10 and further are not available. If you're unsure whether given language feature is supported or not, please refer to Microsoft's changelogs:
https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9
https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10

In this challenge, your task is to implement a Data Access Layer for an online computer shop. The shop sells CPUs, GPUs and disk drives and its backend should allow accessing and filtering these items. The selected architecture is DAO (Data Access Object).
Please assure, that all your code (except for the using declarations) are within the CSharpMilestone namespace, otherwise the unit tests will not work. Pay very close attention to the naming of your classes, fields, properties and methods, as having invalid casing or typos will cause the tests to fail. Follow the standard C# coding conventions: https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
By default, all classes, methods, fields, properties should be available to access by anyone (other classes, assemblies, etc), unless the requirements state otherwise.

IDAO interface requirements:

Implement a generic interface IDAO which will serve as a template for all Data Access Objects.
IDAO should only be allowed to use with Item objects or its derived classes. In the requirements below, all mentions of "object" or "collection" refer to given DAO's target type.
IDAO should define the following CRUD methods:
Seed - takes an IEnumerable collection to initialize the database. Doesn't return anything.
Create - accepts an object that is then added to the collection (unless it's already in it). Returns a bool value, whether the object has been successfully added to the database.
Read - accepts an int id that is used to search for an object in the database, and then returns it. If not found, should return null.
ReadAll - returns an IEnumerable collection of all objects in the database.
Update - accepts an object that is supposed to replace an object already existing in the database, that has the same id. Returns a bool value, whether the object has been successfully updated in the database.
Delete - accepts an int id that is used to search for an object in the database and then deleted from it. Returns a bool value, whether the object has been successfully deleted from the database.
ICPUDAO interface requirements:

Implement an interface ICPUDAO which will serve as a base of a DAO, that supplies CPU items.
ICPUDAO should inherit from IDAO<CPU>
ICPUDAO should define a method GetCPUs, that returns an IEnumerable collection of CPUs after filtering them with the following criteria (in this order): minimum frequency (Integer), maximum frequency (Integer), minimum amount of cores (Integer), maximum amount of cores (Integer), cooling included (Boolean).
IGPUDAO interface requirements:

Implement an interface IGPUDAO which will serve as a base of a DAO, that supplies GPU items.
IGPUDAO should inherit from IDAO<GPU>
IGPUDAO should define a method GetGPUs, that returns an IEnumerable collection of GPUs after filtering them with the following criteria (in this order): minimum frequency (Integer), maximum frequency (Integer), minimum VRAM (Integer), maximum VRAM (Integer), has raytracing (Boolean).
DAO fake database classes:

Create two DAO classes, that will simulate a database behaviour with use of a HashSet (which must be encapsulated from external access, therefore set as private, and initialized as empty upon instantiation of the class).
CPUDAO should implement the ICPUDAO interface
GPUDAO should implement the IGPUDAO interface
Implement all interface methods in all classes, according to the logic descriptions above.

*/
namespace CSharpMilestone
{
    public class Item
    {
        public int Id { get; set; }
        public int Price { get; set; }
    }

    public class CPU : Item
    {
        public int Cores { get; set; }
        public double Frequency { get; set; }
        public bool CoolingIncluded { get; set; }
    }

    public class GPU : Item
    {
        public double Frequency { get; set; }
        public int VRAM { get; set; }
        public bool HasRaytracing { get; set; }
    }

    public interface IDAO<T> where T : Item
    {
        void Seed(IEnumerable<T> collection);
        bool Create(T obj);
        T Read(int id);
        IEnumerable<T> ReadAll();
        bool Update(T obj);
        bool Delete(int id);
    }

    public interface ICPUDAO : IDAO<CPU>
    {
        IEnumerable<CPU> GetCPUs(double minFrequency, double maxFrequency, int minCores, int maxCores, bool coolingIncluded);
    }

    public interface IGPUDAO : IDAO<GPU>
    {
        IEnumerable<GPU> GetGPUs(double minFrequency, double maxFrequency, int minVRAM, int maxVRAM, bool hasRaytracing);
    }

    public class CPUDAO : ICPUDAO
    {
        private HashSet<CPU> _cpuDatabase = new HashSet<CPU>();

        public void Seed(IEnumerable<CPU> collection)
        {
            _cpuDatabase = new HashSet<CPU>(collection);
        }

        public bool Create(CPU obj)
        {
            return _cpuDatabase.Add(obj);
        }

        public CPU Read(int id)
        {
            return _cpuDatabase.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<CPU> ReadAll()
        {
            return _cpuDatabase;
        }

        public bool Update(CPU obj)
        {
            var existing = _cpuDatabase.FirstOrDefault(x => x.Id == obj.Id);
            if (existing == null) return false;

            _cpuDatabase.Remove(existing);
            return _cpuDatabase.Add(obj);
        }

        public bool Delete(int id)
        {
            var existing = _cpuDatabase.FirstOrDefault(x => x.Id == id);
            if (existing == null) return false;

            return _cpuDatabase.Remove(existing);
        }

        public IEnumerable<CPU> GetCPUs(double minFrequency, double maxFrequency, int minCores, int maxCores, bool coolingIncluded)
        {
            return _cpuDatabase.Where(x => x.Frequency >= minFrequency && x.Frequency <= maxFrequency && x.Cores >= minCores && x.Cores <= maxCores && x.CoolingIncluded == coolingIncluded);
        }
    }

        public class GPUDAO : IGPUDAO
    {
        private HashSet<GPU> _gpuDatabase = new HashSet<GPU>();

        public void Seed(IEnumerable<GPU> collection)
        {
            _gpuDatabase = new HashSet<GPU>(collection);
        }

        public bool Create(GPU obj)
        {
            return _gpuDatabase.Add(obj);
        }

        public GPU Read(int id)
        {
            return _gpuDatabase.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GPU> ReadAll()
        {
            return _gpuDatabase;
        }

        public bool Update(GPU obj)
        {
            var existing = _gpuDatabase.FirstOrDefault(x => x.Id == obj.Id);
            if (existing == null) return false;

            _gpuDatabase.Remove(existing);
            return _gpuDatabase.Add(obj);
        }

        public bool Delete(int id)
        {
            var existing = _gpuDatabase.FirstOrDefault(x => x.Id == id);
            if (existing == null) return false;

            return _gpuDatabase.Remove(existing);
        }

        public IEnumerable<GPU> GetGPUs(double minFrequency, double maxFrequency, int minVRAM, int maxVRAM, bool hasRaytracing)
        {
            return _gpuDatabase.Where(x => x.Frequency >= minFrequency && x.Frequency <= maxFrequency && x.VRAM >= minVRAM && x.VRAM <= maxVRAM && x.HasRaytracing == hasRaytracing);
        }
    }
}

