namespace Monsterclash
{
    internal class Program
    {
        static void Main()
        {
            Game game = new Game();

            game.Run();
            //game.End();

            Console.ReadKey();
        }
    }
}
