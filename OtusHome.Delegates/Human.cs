using System;

namespace OtusHome.Delegates
{
    public class Human
    {
        private string name;
        private DateTime birthdate;
        
        public string Name
        {
            get => name;
            set => name = value;
        }

        public DateTime Birthdate
        {
            get => birthdate;
            set => birthdate = value;
        }

        public override string ToString()
        {
            return $"{name}: {birthdate.ToShortDateString()}";
        }
    }
}