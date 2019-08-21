namespace ProgettoPOIS.Skills
{
    abstract class Skill
    {
        private string _name;
        private int _expEarned;

        protected string Name { get => _name; set => _name = value; }
        public int ExpEarned { get => _expEarned; set => _expEarned = value; }
        
        public Skill(string name, int expEarned)
        {
            Name = name;
            ExpEarned = expEarned;
        }


        public abstract void doSkill();

    }
}
