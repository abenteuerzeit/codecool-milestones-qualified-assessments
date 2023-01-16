namespace CSharpMilestone
{
     public sealed class Cat : Pet
    {
        private string sound;
        private List<PetFood> diet; 
        private int foodCapacity;
        private int foodEaten = 0;
        public PetFeedingStatus Status { get; private set; }
       
        protected Cat(string name, string breed) : base(name, breed)
        {
            this.sound = "Meow";
            this.foodCapacity = 2;
            this.diet = new List<PetFood>() { PetFood.Meat };
            this.Status = PetFeedingStatus.StillHungry;
        }
        public override string GetPetSound() => sound;
        public override string GetDescription() => $"This is a {this.Breed} called {this.Name}, which makes a sound: {this.sound}";
        public override PetFeedingStatus Feed(PetFood food, int amount)
        {
            if (!diet.Contains(food))
            {
                this.Status = PetFeedingStatus.WrongFood;
                return this.Status;
            }
            foodEaten += amount;
            return this.Status = foodEaten > foodCapacity ? PetFeedingStatus.FullyFed : PetFeedingStatus.StillHungry;
        }
    }
}