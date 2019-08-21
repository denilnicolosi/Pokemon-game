using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoPOIS.Model
{
    class Attack : Skill
    {
        int _damage;

        public int Damage { get => _damage; set => _damage = value; }


        public Attack(string name, int damage, int expEarned) : base(name, expEarned)
        {
            _damage = damage;
        }

        public override void doSkill()
        {
            throw new NotImplementedException();
        }
    }
}
