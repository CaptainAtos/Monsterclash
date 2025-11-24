
using System.Data;
using System.Text;

namespace Monsterclash
{
    internal class Game
    {
        private List<Monster> m_availableMonsters = new List<Monster>();
        private List<Monster> m_selectedMonsters = new List<Monster>();

        public void Init()
        {
            InitiateMonsterlist();
        }

        public void Run() 
        {
            Init();
            Console.WriteLine("Der Kampf startet! Die Monster treten jetzt abwechselnd gegeneinander an, drücke Enter um den Kampf zu beginnen");
            Console.ReadLine();
            RoundCounter();
        
        }

        //public void End()

        private void InitiateMonsterlist()
        {
            Monster a = new Ghost("Mittagserscheinung", 2, 2, 2, 2, 2);
            Monster b = new Witch("Babajaga", 2, 2, 2, 2, 2);
            Monster c = new Skeleton("Knorge", 2, 2, 2, 2);

            m_availableMonsters.Add(a);
            m_availableMonsters.Add(b);
            m_availableMonsters.Add(c);

            DisplayAvailableMonster();
            HandleMonsterSelection();

            DisplayAvailableMonster();
            DisplaySelectedMonster();
            HandleMonsterSelection();

            DisplaySelectedMonster();
        }

        private void HandleMonsterSelection()
        {
            Console.WriteLine("Bitte wähle ein Monster aus und bestätige mit Enter:");
            string input = Console.ReadLine()!;

            while (true)
            {
                if (InputHelpers.CheckUserInputIntRange(input, 0, m_availableMonsters.Count, out int choice) == true)
                {
                    Console.WriteLine($"Monster {m_availableMonsters[choice - 1].Name}? Gute Wahl");
                    SelectMonster(m_availableMonsters[choice - 1]);
                    break;
                }

                Console.WriteLine("Falsche Wahl, bitte noch mal:");
                input = Console.ReadLine()!;
            }
        }

        private void SelectMonster(Monster _selected)
        {
            m_availableMonsters.Remove(_selected);
            m_selectedMonsters.Add(_selected);
        }

        private void DisplayAvailableMonster()
        {
            Console.WriteLine("Liste aller Monster:");
            for (int i = 0; i < m_availableMonsters.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {m_availableMonsters[i].Name}");
            }
        }

        private void DisplaySelectedMonster()
        {
            Console.WriteLine("Deine ausgewählten Monster:");
            for (int i = 0; i < m_selectedMonsters.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {m_selectedMonsters[i].Name}");
            }
        }

        public void RoundCounter() 
        {
            int _round = 0;
            Monster M1 = m_selectedMonsters[0];
            Monster M2 = m_selectedMonsters[1];
            
            while (M1.IsAlive && M2.IsAlive) 
            {
                Console.WriteLine($"\n===== Runde {_round} =====");
                AttackLoop(M1, M2);
                _round++;
                Console.WriteLine("Weiter mit Enter");
                Console.ReadLine();
            }

            if (M1.IsAlive) 
            {
                Console.WriteLine($"{M1.Name} hat gewonnen!");
            }
            else 
            {
                Console.WriteLine($"{M2.Name} hat gewonnen");
            }

        
        }


        private void AttackLoop(Monster M1, Monster M2) 
        {
            Monster first = M1;
            Monster second = M2;

            // Wählt aus welches Monster zuerst angreifen darf anhand seine "Speedpoints"
            if (M1.m_SP > M2.m_SP) 
            {
                first = M1;
                second = M2;
            }
            else if (M2.m_SP > M1.m_SP)
            {
                first = M2;
                second = M1;
            }
            else
            { // Wenn beide Monster die selben "Speedpoints" darf der mit den höheren "Attackpoints" angreifen
                if (M1.m_AP > M2.m_AP)
                {
                    first = M1;
                    second = M2;
                }
                else if (M1.m_AP < M2.m_AP)
                {
                    first = M2;
                    second = M1;
                }
            }
            first.Attack(second);
            if (!second.IsAlive) return;
            second.Attack(first);
        }

        //private bool CheckForWinning()

    }
}
