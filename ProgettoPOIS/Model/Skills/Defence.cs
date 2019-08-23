using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoPOIS.Model
{
    public class Defence : Skill
    {
        private int _healthEarned;

        public int HealthEarned { get => _healthEarned; set => _healthEarned = value; }

        public Defence(string name, int healthEarned, int expEarned) : base(name, expEarned)
        {
            HealthEarned = healthEarned;
        }
    
    }
}
