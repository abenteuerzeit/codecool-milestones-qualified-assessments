
namespace CSharpMilestone
{
    public class Citizen
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public int BirthYear {get; set;}
        public string BirthCountry {get; set;}
        
        public Citizen(string firstName, string lastName, int birthYear, string birthCountry)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthYear = birthYear;
            this.BirthCountry = birthCountry;
        }
        
        public string GetDisplayInfo(string currentCountry)
        {
            var same = $"{FirstName} {LastName} born in {BirthYear} - Status: Citizen of {BirthCountry}";
            var diff = $"{FirstName} {LastName} born in {BirthYear} - Status: Immigrant from {BirthCountry}";
            return currentCountry == BirthCountry ? same : diff;
        }
        
        public int GetAge(int currentYear)
        {
            return currentYear - BirthYear;
        }
    }
}
