namespace CSharpMilestone
{
     public sealed class TalkingParrot : Parrot
    {
       
        protected Parrot(string name, string breed) : base(name, breed)
        {
            this.sound = "Hello";
        }
    }
}