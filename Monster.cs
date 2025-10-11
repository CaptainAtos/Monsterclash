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

            Console.WriteLine("Hallo Welt! Ich bin geboren!");
        
        }
        public void MakeNoise()
        {

        }

        public void Attack(Monster _defender) //Pikachu, attackiere Flegmon!!
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

    public class FlyingMonsters : Monster
    {
        private float DOP; // DodgePoints

        public FlyingMonsters(float _HP, float _AP, float _DP, float _SP) : base(_HP, _AP, _DP, _SP)
        {
            
        }
    }

    public class MagicMonster : FlyingMonsters
    {
        private float MP; // Manapunkte

        public MagicMonster(float _HP, float _AP, float _DP, float _SP) : base(_HP, _AP, _DP, _SP)
        {

        }
    }

    public class HerrdesWaldes : MagicMonster
    {
        public HerrdesWaldes(float _HP, float _AP, float _DP, float _SP) : base(_HP, _AP, _DP, _SP)
        {

        }
    }

    public class Drache : MagicMonster
    {
        public Drache(float _HP, float _AP, float _DP, float _SP) : base(_HP, _AP, _DP, _SP)
        {

        }
    }

    public class Pestjungfrau : MagicMonster
    {
        public Pestjungfrau(float _HP, float _AP, float _DP, float _SP) : base(_HP, _AP, _DP, _SP)
        {

        }
    }

    public class Golem : Monster
    {
        public Golem(float _HP, float _AP, float _DP, float _SP) : base(_HP, _AP, _DP, _SP)
        {

        }
    }

    public class Wyvern : Monster
    {
        public Wyvern(float _HP, float _AP, float _DP, float _SP) : base(_HP, _AP, _DP, _SP)
        {

        }
    }

    public class Troll : Monster
    {
        public Troll(float _HP, float _AP, float _DP, float _SP) : base(_HP, _AP, _DP, _SP)
        {

        }
    }

}
