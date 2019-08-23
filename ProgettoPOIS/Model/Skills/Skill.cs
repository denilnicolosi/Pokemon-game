using System;

namespace ProgettoPOIS.Model
{
    public abstract class Skill
    {
        private string _name;
        private int _expEarned;

        public string Name { get => _name; set => _name = value; }
        public int ExpEarned { get => _expEarned; set => _expEarned = value; }
        
        public Skill(string name, int expEarned)
        {
            Name = name;
            ExpEarned = expEarned;
        }


    }
}
