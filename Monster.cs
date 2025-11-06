using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsterclash
{
    public abstract class Monster
    {
        protected float m_HP; // Lebenspunkte
        protected float m_AP; // Angriffspunkte
        protected float m_DP; // Verteildigungspunkte
        protected float m_SP; // Geschwindigkeitspunkte

        public Monster(float _HP, float _AP, float _DP, float _SP) 
        {
            m_HP = _HP;
            m_AP = _AP;
            m_DP = _DP;
            m_SP = _SP;
        
        }
        public abstract void MakeNoise();
        

        public void Attack(Monster _defender) // Monster1, attackiere Monster2!!
        {
            float dmg = m_AP / _defender.m_DP * 10;

            Console.WriteLine($"Ich ziehe jetzt dem Defender {dmg} ab!");

            _defender.TakeDamage(dmg);
        }
        
        public void TakeDamage(float _dmg)
        {
            m_HP -= _dmg; // HP = HP - _DMG;
            Console.WriteLine($"Ich bin der Defender und mir wurde {_dmg} abgezogen und hab nur noch {m_HP}");
        }
    }

    public class Ghost : Monster
    {
        protected float m_DoP; // Dodgepoints

        public override void MakeNoise()
        {
            Console.WriteLine("BuuuuuuuuHhhhhh Hehehehe");
        }
        public Ghost(float _HP, float _AP, float _DP, float _SP, float _DoP) : base(_HP, _AP, _DP, _SP)
        {
            m_DoP = _DoP;
        }
    }

    public class Witch : Monster 
    {
        protected float m_MP; // MagicPoints
        public override void MakeNoise()
        {
            Console.WriteLine("Iieeehehehe wenn ich mit dir fertig bin, kommst du auch in meinem Kessel hehehe");
        }

        public Witch(float _HP, float _AP, float _DP, float _SP, float _MP) :base(_HP, _AP, _DP, _SP) 
        {
            m_MP = _MP;
        }
    }

    public class Skeleton : Monster 
    {
        public override void MakeNoise()
        {
            Console.WriteLine("*böses Knochengeklimper*");
        }

        public Skeleton(float _HP, float _AP, float _DP, float _SP) :base( _HP, _AP, _DP, _SP) 
        {
        
         }



    }
}
