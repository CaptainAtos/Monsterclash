
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

        //public void Run()

        //public void End()

        private void InitiateMonsterlist()
        {
            Monster a = new Ghost("Bla", 2, 2, 2, 2, 2);
            Monster b = new Ghost("Blubb", 2, 2, 2, 2, 2);
            Monster c = new Ghost("Bartosz", 2, 2, 2, 2, 2);

            m_availableMonsters.Add(a);
            m_availableMonsters.Add(b);
            m_availableMonsters.Add(c);

            DisplayAvailableMonster();
            HandleMonsterSelection();

            DisplayAvailableMonster();
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
                    Console.WriteLine($"Monster {m_availableMonsters[choice-1].Name}? Coole wahl");
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
            Console.WriteLine("Liste deiner Monster:");
            for (int i = 0; i < m_selectedMonsters.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {m_selectedMonsters[i].Name}");
            }
        }


        //private void AttackLoop()

        //private bool CheckForWinning()

    }
}
