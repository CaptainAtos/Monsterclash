namespace Monsterclash
{
    internal class Program
    {
        static void Main()
        {
            Monster pikachu = new FlyingMonsters(10,10,50,90);
            Monster flegmon = new MagicMonster(50,50,50,50);

            pikachu.Attack(flegmon);

            Console.ReadKey();
        }
    }
}
