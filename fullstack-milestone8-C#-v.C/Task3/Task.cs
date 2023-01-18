using System;
using System.Linq;
using System.Collections.Generic;

namespace CSharpMilestone
{
    public enum ScreenType : byte
    {
        LCD,
        LED,
        QLED,
        OLED,
        MiniLED
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }

    public class TV : Item
    {
        public int Size { get; set; }
        public ScreenType ScreenType { get; set; }
        public int Resolution { get; set; }
    }

    public class Soundbar : Item
    {
        public int Channels { get; set; }
        public bool HasSubwoofer { get; set; }
    }
    
    public interface IDAO<T> where T : Item
    {
        void Seed(IEnumerable<T> data);
        bool Create(T obj);
        T Read(int id);
        IEnumerable<T> ReadAll();
        bool Update(T obj)
        {
         return Delete(obj.Id) && Create(obj);
        }
        bool Delete(int Id);
    }
    
    public interface ITVDAO : IDAO<TV>
    {
     IEnumerable<TV> GetTVs(int minSize, int maxSize, ScreenType screenType, int minRes );
    }
    
        public interface ISoundbarDAO : IDAO<Soundbar>
    {
     IEnumerable<Soundbar> GetSoundbars(int minChannels, int maxChannels, bool hasSubwoofer);
    }
    
    public class TVDAO : ITVDAO
    {
     private HashSet<TV> _tvs = new HashSet<TV>();
     public void Seed(IEnumerable<TV> data) => _tvs = data.ToHashSet();
     public bool Create(TV obj) =>  _tvs.Add(obj);
     public TV Read(int id) => _tvs.SingleOrDefault(tv => tv.Id == id);
     public IEnumerable<TV> ReadAll() => _tvs;
     public bool Update(TV obj) => Delete(obj.Id) && Create(obj);
     public bool Delete(int Id)
     {
      var tv = Read(Id);
      return tv != null ? _tvs.Remove(tv) : false;
     } 
     public IEnumerable<TV> GetTVs(int minSize, int maxSize, ScreenType screenType, int minRes ) => _tvs.Where(tv => tv.Size >= minSize && tv.Size <= maxSize && tv.ScreenType == screenType && tv.Resolution == minRes);
    }
    
        
    public class SoundbarDAO : ISoundbarDAO
    {
     private HashSet<Soundbar> _s = new HashSet<Soundbar>();
     public void Seed(IEnumerable<Soundbar> data) => _s = data.ToHashSet();
     public bool Create(Soundbar obj) =>  _s.Add(obj);
     public Soundbar Read(int id) => _s.SingleOrDefault(s => s.Id == id);
     public IEnumerable<Soundbar> ReadAll() => _s;
     public bool Update(Soundbar obj) => Delete(obj.Id) && Create(obj);
     public bool Delete(int Id)
     {
      var s = Read(Id);
      return s != null ? _s.Remove(s) : false;
     } 
     public IEnumerable<Soundbar> GetSoundbars (int minChannels, int maxChannels, bool hasSubwoofer) => _s.Where(s => s.Channels >= minChannels && s.Channels <= maxChannels && s.HasSubwoofer == hasSubwoofer);
    }
}
