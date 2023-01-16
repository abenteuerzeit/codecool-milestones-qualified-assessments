using System.Collections.Generic;
using System.Linq;

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
        void Seed(IEnumerable<T> collection);
        bool Create(T item);
        T Read(int id);
        IEnumerable<T> ReadAll();
        bool Update(T item);
        bool Delete(int id);
    }
    
    public interface ITVDAO : IDAO<TV>
    {
        IEnumerable<TV> GetTVs(int minSize, int maxSize, ScreenType screenType, int minResolution);
    }

    public interface ISoundbarDAO : IDAO<Soundbar>
    {
        IEnumerable<Soundbar> GetSoundbars(int minChannels, int maxChannels, bool hasSubwoofer);
    }
    
    public class TVDAO : ITVDAO
    {
        private HashSet<TV> _db = new HashSet<TV>();

        public bool Create(TV item)
        {
            return _db.Add(item);
        }

        public bool Delete(int id)
        {
            var item = Read(id);
            return _db.Remove(item);
        }

        public IEnumerable<TV> ReadAll()
        {
            return _db;
        }

        public TV Read(int id)
        {
            return _db.FirstOrDefault(i => i.Id == id);
        }

        public bool Update(TV item)
        {
            var current = Read(item.Id);
            if (current == null)
            {
                return false;
            }

            _db.Remove(current);
            _db.Add(item);

            return true;
        }

        public void Seed(IEnumerable<TV> items)
        {
            _db = new HashSet<TV>(items);
        }

        public IEnumerable<TV> GetTVs(int minSize, int maxSize, ScreenType screenType, int minResolution)
        {
            return _db.Where(i => i.Size >= minSize && i.Size <= maxSize && i.ScreenType == screenType && i.Resolution >= minResolution);
        }
    }
    
    class SoundbarDAO : ISoundbarDAO
    {
        private HashSet<Soundbar> _soundbars = new HashSet<Soundbar>();

        public bool Create(Soundbar soundbar)
        {
            return _soundbars.Add(soundbar);
        }

        public bool Delete(int id)
        {
            return _soundbars.RemoveWhere(s => s.Id == id) > 0;
        }

        public IEnumerable<Soundbar> GetSoundbars(int minChannels, int maxChannels, bool hasSubwoofer)
        {
            return _soundbars.Where(s => s.Channels >= minChannels && s.Channels <= maxChannels && s.HasSubwoofer == hasSubwoofer);
        }

        public Soundbar Read(int id)
        {
            return _soundbars.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Soundbar> ReadAll()
        {
            return _soundbars;
        }

        public bool Update(Soundbar soundbar)
        {
            Soundbar oldSoundbar = _soundbars.FirstOrDefault(s => s.Id == soundbar.Id);
            if (oldSoundbar == null)
            {
                return false;
            }
            _soundbars.Remove(oldSoundbar);
            _soundbars.Add(soundbar);
            return true;
        }

        public void Seed(IEnumerable<Soundbar> soundbars)
        {
            _soundbars = new HashSet<Soundbar>(soundbars);
        }
    }


 

}
