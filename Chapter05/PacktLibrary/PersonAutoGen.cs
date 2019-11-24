namespace Packt.Shared
{
    public partial class Person
    {
        // a property defined using C# 1-5 syntax
        public string Origin
        {
            get
            {
                return $"{Name} was born on {HomePlanet}";
            }
        }
        // two properties defined using C# 6+ lambda expression syntax
        public string Greeting => $"{Name} says 'Hello!'";
        public int Age => System.DateTime.Today.Year - DateOfBirth.Year;
    }
}