namespace CSharpMilestone
{
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
    
    public abstract class Pet
    {
        protected string Name {get; set;}
        protected string Breed {get; set;}
        public abstract string GetPetSound();
        public abstract PetFeedingStatus Feed(PetFood food, int amount);
        public abstract string GetDescription();
    
        protected Pet(string name, string breed)
        {
            Name = name;
            Breed = breed;
        }
    }   
}