namespace CSharpMilestone
{
    public abstract class Pet
    {
        protected string Name { get; }
        protected string Breed { get; }
        protected Pet(string name, string breed)
        {
            Name = name;
            Breed = breed;
        }

        public abstract string GetPetSound();
        public abstract PetFeedingStatus Feed(PetFood food, int amount);
        public virtual string GetDescription() => $"This is a {Breed} called {Name}, which makes a sound: {GetPetSound()}";
    }

    public class Dog : Pet
    {
        public Dog(string name, string breed) : base(name, breed) { }
        public override string GetPetSound() => "Woof";
        public override PetFeedingStatus Feed(PetFood food, int amount) => food == PetFood.Meat 
            ? (amount >= 5  ? PetFeedingStatus.FullyFed : PetFeedingStatus.StillHungry) 
            : PetFeedingStatus.WrongFood;
    }

    public class Cat : Pet
    {
        public Cat(string name, string breed) : base(name, breed) { }
        public override string GetPetSound() => "Meow";
        public override PetFeedingStatus Feed(PetFood food, int amount) => 
        food == PetFood.Meat 
            ? (amount >= 2 ? PetFeedingStatus.FullyFed : PetFeedingStatus.StillHungry) 
            : PetFeedingStatus.WrongFood;
    }

    public class Parrot : Pet
    {
        public Parrot(string name, string breed) : base(name, breed) { }
        public override string GetPetSound() => "Squawk";
        public override PetFeedingStatus Feed(PetFood food, int amount) => 
            (food == PetFood.Meat && amount >= 2) || (food == PetFood.Grain && amount >= 4) 
            ? PetFeedingStatus.FullyFed : PetFeedingStatus.WrongFood;
    }

    public sealed class TalkingParrot : Parrot
    {
        public TalkingParrot(string name, string breed) : base(name, breed) { }
        public override string GetPetSound() => "Hello";
        public override PetFeedingStatus Feed(PetFood food, int amount) => food != PetFood.Meat 
            ? base.Feed(food, amount) : PetFeedingStatus.WrongFood;
    }

    public enum PetFood
    {
        Meat,
        Grain
    }

    public enum PetFeedingStatus
    {
        FullyFed,
        StillHungry,
        WrongFood
    }
}
