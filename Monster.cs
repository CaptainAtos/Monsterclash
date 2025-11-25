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
        public float CurrentHP 
        {
            get 
            {
                return m_currentHP;
            }
        }

        public float AP 
        {
            get 
            {
                return m_AP;
            }
        }

        public float SP 
        {
            get 
            {
                return m_SP;
            }
        }


        protected float m_maxHP; // Start Lebenspunkte
        protected float m_currentHP; // Aktuelle HP
        protected float m_AP; // Angriffspunkte
        protected float m_DP; // Verteildigungspunkte
        protected float m_SP; // Geschwindigkeitspunkte
        protected string m_name;
        public bool IsAlive => m_currentHP > 0;

        public Monster(string _name, float _HP, float _AP, float _DP, float _SP)
        {
            m_maxHP = _HP;
            m_currentHP = _HP;
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
        public void Attack( Monster _defender) // Monster1, attackiere Monster2!!
        {
            float dmg = m_AP / _defender.m_DP * 2; //Formel zur Berechnung der AP des Angreifers in Bezug auf die DP des Verteildigers.

            Console.WriteLine($"Das Monster {Name}, greift {_defender.Name} an!");
            

            _defender.TakeDamage(dmg, _defender);
        }

        public void TakeDamage(float _dmg, Monster _defender)
        {
            m_currentHP -= _dmg; // HP = HP - _DMG;
            Console.WriteLine($"Dem Monster {Name} wurden {_dmg} Lebenspunkte abgezogen es hat noch {m_currentHP} HP!");
            _defender.MakeNoise();

            if (!IsAlive)
            {
                Console.WriteLine("Dieses Monster wurde besiegt!");
            }
        }

        public void SetMonsterPoints()
        {
            int InputHP;
            int InputAP;
            int InputDP;
            int InputSP;

            Console.WriteLine("Gib die Lebenspunkte deines Monsters an zwischen 1 - 100");
            string consoleInput = Console.ReadLine()!;

            InputHelpers.CheckUserInputIntRange(consoleInput, 1, 100, out InputHP);
            m_currentHP = InputHP;

            Console.WriteLine("Gib die Angriffspunkte deines Monsters an zwischen 20 - 80");
            consoleInput = Console.ReadLine()!;

            InputHelpers.CheckUserInputIntRange(consoleInput, 20, 80, out InputAP);
            m_AP = InputAP;

            Console.WriteLine("Gib die Verteidigungspunkte deines Monsters an zwischen 20 - 80");


            //TODO



        }

    }

    public class Ghost : Monster
    {
        public override void MakeNoise()
        {
            Console.WriteLine("Auuaaa Buuuuhuuuuu!");
        }
        public Ghost(string _name, float _HP = 0, float _AP = 0, float _DP = 0, float _SP = 0) : base(_name, _HP, _AP, _DP, _SP)
        {

        }
    }

    public class Witch : Monster
    {
        protected float m_MP; // MagicPoints
        public override void MakeNoise()
        {
            Console.WriteLine("Auuuuu! Dafür kommst du in meinen Kochtopf!");
        }

        public Witch(string _name, float _HP = 0, float _AP = 0, float _DP = 0, float _SP = 0, float _MP = 50) : base(_name, _HP, _AP, _DP, _SP)
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

        public Skeleton(string _name, float _HP = 0, float _AP = 0, float _DP = 0, float _SP = 0) : base(_name, _HP, _AP, _DP, _SP)
        {

        }

    }
}
