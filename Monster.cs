using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsterclash
{
    public abstract class Monster
    {
        /// <summary>
        /// Name des Monsters
        /// </summary>
        public string Name
        {
            get                        // public GetName()
            {                          // {
                return m_name;         //   return m_name;
            }                          // }

            private set                // private SetName(string _value)
            {                          // {
               m_name = value;         //   m_name = _value;
            }                          // }
        }

        protected float m_HP; // Lebenspunkte
        protected float m_AP; // Angriffspunkte
        protected float m_DP; // Verteildigungspunkte
        protected float m_SP; // Geschwindigkeitspunkte
        protected string m_name;

        public Monster(string _name,float _HP, float _AP, float _DP, float _SP) 
        {
            m_HP = _HP;
            m_AP = _AP;
            m_DP = _DP;
            m_SP = _SP;
            m_name = _name;
        }
        public abstract void MakeNoise();
        

        /// <summary>
        /// Attackiert ein anderes Monster mit seiner Attacke
        /// </summary>
        /// <param name="_defender">Das andere Monster</param>
        public void Attack(Monster _defender) // Monster1, attackiere Monster2!!
        {
            float dmg = m_AP / _defender.m_DP * 10; //Formel zur Berechnung der AP des Angreifers in Bezug auf die DP des Verteildigers.

            Console.WriteLine($"Ich bin {Name}, greife jetzt {_defender.Name} an und ziehe {dmg} Lebenspunkte ab!");

            _defender.TakeDamage(dmg);
        }
        
        public void TakeDamage(float _dmg)
        {
            m_HP -= _dmg; // HP = HP - _DMG;
            Console.WriteLine($"Ich bin {Name} und mir wurden {_dmg} Lebenspunkte abgezogen und ich habe nur noch {m_HP}!");
        }
    }

    public class Ghost : Monster
    {
        protected float m_DoP; // Dodgepoints
        public override void MakeNoise()
        {
            Console.WriteLine("BuuuuuuuuHhhhhh Hehehehe");
        }
        public Ghost(string _name, float _HP, float _AP, float _DP, float _SP, float _DoP) : base(_name, _HP, _AP, _DP, _SP)
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

        public Witch(string _name, float _HP, float _AP, float _DP, float _SP, float _MP) : base(_name, _HP, _AP, _DP, _SP) 
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

        public Skeleton(string _name, float _HP, float _AP, float _DP, float _SP) :base(_name, _HP, _AP, _DP, _SP) 
        {
        
         }



    }
}
