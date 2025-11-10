namespace Monsterclash
{
    internal class Program
    {
        static void Main()
        {
            Game game = new Game();

            game.Init();
            //game.Run();
            //game.End();

            Console.ReadKey();
        }
    }
}
