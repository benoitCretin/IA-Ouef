using IA.Model;
using IA.Network;
using IA.Strategies;

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();

        Connection.OuvrirConnexion();



        string message = Connection.RecevoirMessage();
        Connection.EnvoyerMessage("OUEF");

        IStrategie strat = new StrategyLootingStack();
        strat.Executer();

        Connection.FermerConnexion();
    }
}
